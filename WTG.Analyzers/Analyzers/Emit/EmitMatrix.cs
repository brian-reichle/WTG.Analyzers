using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.CodeAnalysis;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	partial class EmitMatrix
	{
		public static EmitMethod GetEmitMethod(IMethodSymbol method)
		{
			if (method.ContainingType.IsMatch("System.Reflection.Emit.ILGenerator"))
			{
				if (method.Name == nameof(ILGenerator.EmitCall))
				{
					return EmitMethod.EmitCall;
				}
				else if (method.Name == nameof(ILGenerator.EmitCalli))
				{
					return EmitMethod.EmitCalli;
				}
				else if (method.Name != nameof(ILGenerator.Emit))
				{
					return EmitMethod.None;
				}
				else if (method.Parameters.Length == 1)
				{
					return EmitMethod.Emit;
				}

				var argType = method.Parameters[1].Type;

				if (argType.Kind == SymbolKind.ArrayType)
				{
					return EmitMethod.Emit_LabelArray;
				}

				switch (argType.Name)
				{
					case nameof(Byte):
						return EmitMethod.Emit_Byte;
					case nameof(SByte):
						return EmitMethod.Emit_SByte;
					case nameof(Int16):
						return EmitMethod.Emit_Int16;
					case nameof(Int32):
						return EmitMethod.Emit_Int32;
					case nameof(MethodInfo):
						return EmitMethod.Emit_MethodInfo;
					case nameof(SignatureHelper):
						return EmitMethod.Emit_SignatureHelper;
					case nameof(ConstructorInfo):
						return EmitMethod.Emit_ConstructorInfo;
					case nameof(Type):
						return EmitMethod.Emit_Type;
					case nameof(Int64):
						return EmitMethod.Emit_Int64;
					case nameof(Single):
						return EmitMethod.Emit_Single;
					case nameof(Double):
						return EmitMethod.Emit_Double;
					case nameof(Label):
						return EmitMethod.Emit_Label;
					case nameof(FieldInfo):
						return EmitMethod.Emit_FieldInfo;
					case nameof(String):
						return EmitMethod.Emit_String;
					case nameof(LocalBuilder):
						return EmitMethod.Emit_LocalBuilder;
				}
			}

			return EmitMethod.None;
		}
	}
}
