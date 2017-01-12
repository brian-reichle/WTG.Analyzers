﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public sealed class SuppressionAnalyzer : DiagnosticAnalyzer
	{
		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(new[]
		{
			Rules.RemovedOrphanedSuppressionsRule,
		});

		public override void Initialize(AnalysisContext context)
		{
			context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.CompilationUnit);
		}

		static void Analyze(SyntaxNodeAnalysisContext context)
		{
			SuppressionTargetLookup lookup = null;

			foreach (var attribute in FindGlobalSuppressionAttributes((CompilationUnitSyntax)context.Node, context.SemanticModel))
			{
				SuppressionScope scope;
				string target;

				if (TryDecodeAttribute(attribute, out scope, out target))
				{
					if (lookup == null)
					{
						lookup = new SuppressionTargetLookup(context.SemanticModel);
					}

					switch (scope)
					{
						case SuppressionScope.Namespace:
							if (!lookup.NamespaceExists(target))
							{
								context.ReportDiagnostic(
									Rules.CreateRemovedOrphanedSuppressionsDiagnostic(
										GetLocation(attribute),
										"namespace",
										target));
							}
							break;

						case SuppressionScope.Type:
							if (!lookup.TypeExists(target))
							{
								context.ReportDiagnostic(
									Rules.CreateRemovedOrphanedSuppressionsDiagnostic(
										GetLocation(attribute),
										"type",
										target));
							}
							break;

						case SuppressionScope.Member:
							if (!lookup.MemberExists(target))
							{
								context.ReportDiagnostic(
									Rules.CreateRemovedOrphanedSuppressionsDiagnostic(
										GetLocation(attribute),
										"member",
										target));
							}
							break;
					}
				}
			}
		}

		static Location GetLocation(AttributeSyntax attribute)
		{
			var attributeList = (AttributeListSyntax)attribute.Parent;

			if (attributeList == null || attributeList.Attributes.Count > 1)
			{
				return attribute.GetLocation();
			}

			return attributeList.GetLocation();
		}

		static IEnumerable<AttributeSyntax> FindGlobalSuppressionAttributes(CompilationUnitSyntax unit, SemanticModel model)
		{
			foreach (var attributeList in unit.AttributeLists)
			{
				foreach (var attribute in attributeList.Attributes)
				{
					var type = model.GetTypeInfo(attribute).Type;

					if (type != null && type.IsMatch("mscorlib", "System.Diagnostics.CodeAnalysis.SuppressMessageAttribute"))
					{
						yield return attribute;
					}
				}
			}
		}

		static bool TryDecodeAttribute(AttributeSyntax att, out SuppressionScope scope, out string target)
		{
			string scopeStr;
			string targetStr;

			if (att.GetPropertyValue(nameof(SuppressMessageAttribute.Scope)).TryGetStringValue(out scopeStr) &&
				att.GetPropertyValue(nameof(SuppressMessageAttribute.Target)).TryGetStringValue(out targetStr))
			{
				scope = TranslateScope(scopeStr);

				if (scope != SuppressionScope.Unknown)
				{
					target = targetStr;
					return true;
				}
			}

			scope = SuppressionScope.Unknown;
			target = null;
			return false;
		}

		static SuppressionScope TranslateScope(string scope)
		{
			switch (scope)
			{
				case "namespace": return SuppressionScope.Namespace;
				case "type": return SuppressionScope.Type;
				case "member": return SuppressionScope.Member;
				default: return SuppressionScope.Unknown;
			}
		}

		internal enum SuppressionScope
		{
			Unknown,
			Namespace,
			Type,
			Member,
		}
	}
}