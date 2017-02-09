﻿using System;
using Microsoft.CodeAnalysis;

namespace WTG.Analyzers.Utils
{
	public static class SymbolExtensions
	{
		public static bool IsMatch(this IMethodSymbol methodSymbol, string assemblyName, string fullTypeName, string methodName)
		{
			return methodSymbol.MetadataName == methodName
				&& IsMatch(methodSymbol.ContainingType, assemblyName, fullTypeName);
		}

		public static bool IsMatch(this ITypeSymbol typeSymbol, string assemblyName, string fullName)
		{
			ISymbol symbol = typeSymbol;
			var length = fullName.Length;

			while (true)
			{
				var index = fullName.LastIndexOf('+', length - 1);

				if (index < 0)
				{
					break;
				}

				if (string.Compare(symbol.MetadataName, 0, fullName, index + 1, length - index - 1, StringComparison.Ordinal) != 0)
				{
					return false;
				}

				length = index;
				symbol = symbol.ContainingType;

				if (symbol == null)
				{
					return false;
				}
			}

			if (symbol.ContainingType != null)
			{
				return false;
			}

			while (true)
			{
				var index = fullName.LastIndexOf('.', length - 1);

				if (index < 0)
				{
					break;
				}

				if (string.Compare(symbol.MetadataName, 0, fullName, index + 1, length - index - 1, StringComparison.Ordinal) != 0)
				{
					return false;
				}

				length = index;
				var ns = symbol.ContainingNamespace;

				if (ns.IsGlobalNamespace)
				{
					return false;
				}

				symbol = ns;
			}

			if (string.Compare(symbol.MetadataName, 0, fullName, 0, length, StringComparison.Ordinal) != 0)
			{
				return false;
			}

			var tmp = symbol.ContainingNamespace;

			if (!tmp.IsGlobalNamespace)
			{
				return false;
			}

			return IsMatch(symbol.ContainingAssembly, assemblyName);
		}

		public static bool IsMatch(this IAssemblySymbol assemblySymbol, string assemblyName)
		{
			return assemblySymbol.Identity.Name == assemblyName;
		}
	}
}