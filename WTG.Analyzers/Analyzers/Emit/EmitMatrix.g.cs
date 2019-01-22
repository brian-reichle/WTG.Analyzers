using System;
using Microsoft.CodeAnalysis;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	enum OpCodeOperand
	{
		Invalid = 0,
		InlineBrTarget = 1,
		InlineField = 2,
		InlineI = 3,
		InlineI8 = 4,
		InlineMethod = 5,
		InlineNone = 6,
		InlineR = 7,
		InlineSig = 8,
		InlineString = 9,
		InlineSwitch = 10,
		InlineTok = 11,
		InlineType = 12,
		InlineVar = 13,
		ShortInlineBrTarget = 14,
		ShortInlineI = 15,
		ShortInlineR = 16,
		ShortInlineVar = 17,
	}

	[Flags]
	enum EmitMethod
	{
		None = 0,
		Emit = 1 << 0,
		Emit_Byte = 1 << 1,
		Emit_ConstructorInfo = 1 << 2,
		Emit_Double = 1 << 3,
		Emit_FieldInfo = 1 << 4,
		Emit_Int16 = 1 << 5,
		Emit_Int32 = 1 << 6,
		Emit_Int64 = 1 << 7,
		Emit_Label = 1 << 8,
		Emit_LabelArray = 1 << 9,
		Emit_LocalBuilder = 1 << 10,
		Emit_MethodInfo = 1 << 11,
		Emit_SByte = 1 << 12,
		Emit_SignatureHelper = 1 << 13,
		Emit_Single = 1 << 14,
		Emit_String = 1 << 15,
		Emit_Type = 1 << 16,
		EmitCall = 1 << 17,
		EmitCalli = 1 << 18,
	}

	enum OpCode
	{
		Invalid = 0,
		#region InlineBrTarget

		/// <summary>
		/// beq
		/// </summary>
		Beq = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bge
		/// </summary>
		Bge = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bge.un
		/// </summary>
		Bge_Un = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bgt
		/// </summary>
		Bgt = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bgt.un
		/// </summary>
		Bgt_Un = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// ble
		/// </summary>
		Ble = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// ble.un
		/// </summary>
		Ble_Un = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// blt
		/// </summary>
		Blt = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// blt.un
		/// </summary>
		Blt_Un = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bne.un
		/// </summary>
		Bne_Un = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// br
		/// </summary>
		Br = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// brfalse
		/// </summary>
		Brfalse = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// brtrue
		/// </summary>
		Brtrue = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// leave
		/// </summary>
		Leave = OpCodeOperand.InlineBrTarget
			| (EmitMethod.Emit_Label << 5),
		#endregion
		#region InlineField

		/// <summary>
		/// ldfld
		/// </summary>
		Ldfld = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),

		/// <summary>
		/// ldflda
		/// </summary>
		Ldflda = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),

		/// <summary>
		/// ldsfld
		/// </summary>
		Ldsfld = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),

		/// <summary>
		/// ldsflda
		/// </summary>
		Ldsflda = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),

		/// <summary>
		/// stfld
		/// </summary>
		Stfld = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),

		/// <summary>
		/// stsfld
		/// </summary>
		Stsfld = OpCodeOperand.InlineField
			| (EmitMethod.Emit_FieldInfo << 5),
		#endregion
		#region InlineI

		/// <summary>
		/// ldc.i4
		/// </summary>
		Ldc_I4 = OpCodeOperand.InlineI
			| (EmitMethod.Emit_Int32 << 5),
		#endregion
		#region InlineI8

		/// <summary>
		/// ldc.i8
		/// </summary>
		Ldc_I8 = OpCodeOperand.InlineI8
			| (EmitMethod.Emit_Int64 << 5),
		#endregion
		#region InlineMethod

		/// <summary>
		/// call
		/// </summary>
		Call = OpCodeOperand.InlineMethod
			| (EmitMethod.EmitCall << 5)
			| (EmitMethod.Emit_MethodInfo << 5)
			| (EmitMethod.Emit_ConstructorInfo << 5),

		/// <summary>
		/// callvirt
		/// </summary>
		Callvirt = OpCodeOperand.InlineMethod
			| (EmitMethod.EmitCall << 5)
			| (EmitMethod.Emit_MethodInfo << 5),

		/// <summary>
		/// jmp
		/// </summary>
		Jmp = OpCodeOperand.InlineMethod
			| (EmitMethod.Emit_MethodInfo << 5),

		/// <summary>
		/// ldftn
		/// </summary>
		Ldftn = OpCodeOperand.InlineMethod
			| (EmitMethod.Emit_MethodInfo << 5),

		/// <summary>
		/// ldvirtftn
		/// </summary>
		Ldvirtftn = OpCodeOperand.InlineMethod
			| (EmitMethod.Emit_MethodInfo << 5),

		/// <summary>
		/// newobj
		/// </summary>
		Newobj = OpCodeOperand.InlineMethod
			| (EmitMethod.Emit_ConstructorInfo << 5),
		#endregion
		#region InlineNone

		/// <summary>
		/// add
		/// </summary>
		Add = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// add.ovf
		/// </summary>
		Add_Ovf = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// add.ovf.un
		/// </summary>
		Add_Ovf_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// and
		/// </summary>
		And = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// arglist
		/// </summary>
		Arglist = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// break
		/// </summary>
		Break = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ceq
		/// </summary>
		Ceq = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// cgt
		/// </summary>
		Cgt = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// cgt.un
		/// </summary>
		Cgt_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ckfinite
		/// </summary>
		Ckfinite = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// clt
		/// </summary>
		Clt = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// clt.un
		/// </summary>
		Clt_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.i
		/// </summary>
		Conv_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.i1
		/// </summary>
		Conv_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.i2
		/// </summary>
		Conv_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.i4
		/// </summary>
		Conv_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.i8
		/// </summary>
		Conv_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i
		/// </summary>
		Conv_Ovf_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i.un
		/// </summary>
		Conv_Ovf_I_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i1
		/// </summary>
		Conv_Ovf_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i1.un
		/// </summary>
		Conv_Ovf_I1_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i2
		/// </summary>
		Conv_Ovf_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i2.un
		/// </summary>
		Conv_Ovf_I2_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i4
		/// </summary>
		Conv_Ovf_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i4.un
		/// </summary>
		Conv_Ovf_I4_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i8
		/// </summary>
		Conv_Ovf_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.i8.un
		/// </summary>
		Conv_Ovf_I8_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u
		/// </summary>
		Conv_Ovf_U = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u.un
		/// </summary>
		Conv_Ovf_U_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u1
		/// </summary>
		Conv_Ovf_U1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u1.un
		/// </summary>
		Conv_Ovf_U1_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u2
		/// </summary>
		Conv_Ovf_U2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u2.un
		/// </summary>
		Conv_Ovf_U2_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u4
		/// </summary>
		Conv_Ovf_U4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u4.un
		/// </summary>
		Conv_Ovf_U4_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u8
		/// </summary>
		Conv_Ovf_U8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.ovf.u8.un
		/// </summary>
		Conv_Ovf_U8_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.r.un
		/// </summary>
		Conv_R_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.r4
		/// </summary>
		Conv_R4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.r8
		/// </summary>
		Conv_R8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.u
		/// </summary>
		Conv_U = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.u1
		/// </summary>
		Conv_U1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.u2
		/// </summary>
		Conv_U2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.u4
		/// </summary>
		Conv_U4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// conv.u8
		/// </summary>
		Conv_U8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// cpblk
		/// </summary>
		Cpblk = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// div
		/// </summary>
		Div = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// div.un
		/// </summary>
		Div_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// dup
		/// </summary>
		Dup = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// endfilter
		/// </summary>
		Endfilter = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// endfinally
		/// </summary>
		Endfinally = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// initblk
		/// </summary>
		Initblk = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldarg.0
		/// </summary>
		Ldarg_0 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldarg.1
		/// </summary>
		Ldarg_1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldarg.2
		/// </summary>
		Ldarg_2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldarg.3
		/// </summary>
		Ldarg_3 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.0
		/// </summary>
		Ldc_I4_0 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.1
		/// </summary>
		Ldc_I4_1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.2
		/// </summary>
		Ldc_I4_2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.3
		/// </summary>
		Ldc_I4_3 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.4
		/// </summary>
		Ldc_I4_4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.5
		/// </summary>
		Ldc_I4_5 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.6
		/// </summary>
		Ldc_I4_6 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.7
		/// </summary>
		Ldc_I4_7 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.8
		/// </summary>
		Ldc_I4_8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldc.i4.m1
		/// </summary>
		Ldc_I4_M1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.i
		/// </summary>
		Ldelem_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.i1
		/// </summary>
		Ldelem_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.i2
		/// </summary>
		Ldelem_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.i4
		/// </summary>
		Ldelem_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.i8
		/// </summary>
		Ldelem_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.r4
		/// </summary>
		Ldelem_R4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.r8
		/// </summary>
		Ldelem_R8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.ref
		/// </summary>
		Ldelem_Ref = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.u1
		/// </summary>
		Ldelem_U1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.u2
		/// </summary>
		Ldelem_U2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldelem.u4
		/// </summary>
		Ldelem_U4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.i
		/// </summary>
		Ldind_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.i1
		/// </summary>
		Ldind_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.i2
		/// </summary>
		Ldind_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.i4
		/// </summary>
		Ldind_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.i8
		/// </summary>
		Ldind_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.r4
		/// </summary>
		Ldind_R4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.r8
		/// </summary>
		Ldind_R8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.ref
		/// </summary>
		Ldind_Ref = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.u1
		/// </summary>
		Ldind_U1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.u2
		/// </summary>
		Ldind_U2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldind.u4
		/// </summary>
		Ldind_U4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldlen
		/// </summary>
		Ldlen = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldloc.0
		/// </summary>
		Ldloc_0 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldloc.1
		/// </summary>
		Ldloc_1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldloc.2
		/// </summary>
		Ldloc_2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldloc.3
		/// </summary>
		Ldloc_3 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ldnull
		/// </summary>
		Ldnull = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// localloc
		/// </summary>
		Localloc = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// mul
		/// </summary>
		Mul = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// mul.ovf
		/// </summary>
		Mul_Ovf = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// mul.ovf.un
		/// </summary>
		Mul_Ovf_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// neg
		/// </summary>
		Neg = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// nop
		/// </summary>
		Nop = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// not
		/// </summary>
		Not = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// or
		/// </summary>
		Or = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// pop
		/// </summary>
		Pop = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// readonly.
		/// </summary>
		Readonly = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// refanytype
		/// </summary>
		Refanytype = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// rem
		/// </summary>
		Rem = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// rem.un
		/// </summary>
		Rem_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// ret
		/// </summary>
		Ret = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// rethrow
		/// </summary>
		Rethrow = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// shl
		/// </summary>
		Shl = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// shr
		/// </summary>
		Shr = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// shr.un
		/// </summary>
		Shr_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.i
		/// </summary>
		Stelem_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.i1
		/// </summary>
		Stelem_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.i2
		/// </summary>
		Stelem_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.i4
		/// </summary>
		Stelem_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.i8
		/// </summary>
		Stelem_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.r4
		/// </summary>
		Stelem_R4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.r8
		/// </summary>
		Stelem_R8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stelem.ref
		/// </summary>
		Stelem_Ref = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.i
		/// </summary>
		Stind_I = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.i1
		/// </summary>
		Stind_I1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.i2
		/// </summary>
		Stind_I2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.i4
		/// </summary>
		Stind_I4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.i8
		/// </summary>
		Stind_I8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.r4
		/// </summary>
		Stind_R4 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.r8
		/// </summary>
		Stind_R8 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stind.ref
		/// </summary>
		Stind_Ref = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stloc.0
		/// </summary>
		Stloc_0 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stloc.1
		/// </summary>
		Stloc_1 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stloc.2
		/// </summary>
		Stloc_2 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// stloc.3
		/// </summary>
		Stloc_3 = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// sub
		/// </summary>
		Sub = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// sub.ovf
		/// </summary>
		Sub_Ovf = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// sub.ovf.un
		/// </summary>
		Sub_Ovf_Un = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// tail.
		/// </summary>
		Tailcall = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// throw
		/// </summary>
		Throw = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// volatile.
		/// </summary>
		Volatile = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),

		/// <summary>
		/// xor
		/// </summary>
		Xor = OpCodeOperand.InlineNone
			| (EmitMethod.Emit << 5),
		#endregion
		#region InlineR

		/// <summary>
		/// ldc.r8
		/// </summary>
		Ldc_R8 = OpCodeOperand.InlineR
			| (EmitMethod.Emit_Double << 5),
		#endregion
		#region InlineSig

		/// <summary>
		/// calli
		/// </summary>
		Calli = OpCodeOperand.InlineSig
			| (EmitMethod.EmitCalli << 5)
			| (EmitMethod.Emit_SignatureHelper << 5),
		#endregion
		#region InlineString

		/// <summary>
		/// ldstr
		/// </summary>
		Ldstr = OpCodeOperand.InlineString
			| (EmitMethod.Emit_String << 5),
		#endregion
		#region InlineSwitch

		/// <summary>
		/// switch
		/// </summary>
		Switch = OpCodeOperand.InlineSwitch
			| (EmitMethod.Emit_LabelArray << 5),
		#endregion
		#region InlineTok

		/// <summary>
		/// ldtoken
		/// </summary>
		Ldtoken = OpCodeOperand.InlineTok
			| (EmitMethod.Emit_Type << 5)
			| (EmitMethod.Emit_FieldInfo << 5)
			| (EmitMethod.Emit_MethodInfo << 5),
		#endregion
		#region InlineType

		/// <summary>
		/// box
		/// </summary>
		Box = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// castclass
		/// </summary>
		Castclass = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// constrained.
		/// </summary>
		Constrained = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// cpobj
		/// </summary>
		Cpobj = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// initobj
		/// </summary>
		Initobj = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// isinst
		/// </summary>
		Isinst = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// ldelem
		/// </summary>
		Ldelem = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// ldelema
		/// </summary>
		Ldelema = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// ldobj
		/// </summary>
		Ldobj = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// mkrefany
		/// </summary>
		Mkrefany = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// newarr
		/// </summary>
		Newarr = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// refanyval
		/// </summary>
		Refanyval = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// sizeof
		/// </summary>
		Sizeof = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// stelem
		/// </summary>
		Stelem = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// stobj
		/// </summary>
		Stobj = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// unbox
		/// </summary>
		Unbox = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),

		/// <summary>
		/// unbox.any
		/// </summary>
		Unbox_Any = OpCodeOperand.InlineType
			| (EmitMethod.Emit_Type << 5),
		#endregion
		#region InlineVar

		/// <summary>
		/// ldarg
		/// </summary>
		Ldarg = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5),

		/// <summary>
		/// ldarga
		/// </summary>
		Ldarga = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5),

		/// <summary>
		/// ldloc
		/// </summary>
		Ldloc = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),

		/// <summary>
		/// ldloca
		/// </summary>
		Ldloca = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),

		/// <summary>
		/// starg
		/// </summary>
		Starg = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5),

		/// <summary>
		/// stloc
		/// </summary>
		Stloc = OpCodeOperand.InlineVar
			| (EmitMethod.Emit_Int16 << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),
		#endregion
		#region ShortInlineBrTarget

		/// <summary>
		/// beq.s
		/// </summary>
		Beq_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bge.s
		/// </summary>
		Bge_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bge.un.s
		/// </summary>
		Bge_Un_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bgt.s
		/// </summary>
		Bgt_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bgt.un.s
		/// </summary>
		Bgt_Un_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// ble.s
		/// </summary>
		Ble_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// ble.un.s
		/// </summary>
		Ble_Un_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// blt.s
		/// </summary>
		Blt_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// blt.un.s
		/// </summary>
		Blt_Un_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// bne.un.s
		/// </summary>
		Bne_Un_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// br.s
		/// </summary>
		Br_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// brfalse.s
		/// </summary>
		Brfalse_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// brtrue.s
		/// </summary>
		Brtrue_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),

		/// <summary>
		/// leave.s
		/// </summary>
		Leave_S = OpCodeOperand.ShortInlineBrTarget
			| (EmitMethod.Emit_Label << 5),
		#endregion
		#region ShortInlineI

		/// <summary>
		/// ldc.i4.s
		/// </summary>
		Ldc_I4_S = OpCodeOperand.ShortInlineI
			| (EmitMethod.Emit_SByte << 5),

		/// <summary>
		/// unaligned.
		/// </summary>
		Unaligned = OpCodeOperand.ShortInlineI
			| (EmitMethod.Emit_SByte << 5),
		#endregion
		#region ShortInlineR

		/// <summary>
		/// ldc.r4
		/// </summary>
		Ldc_R4 = OpCodeOperand.ShortInlineR
			| (EmitMethod.Emit_Single << 5),
		#endregion
		#region ShortInlineVar

		/// <summary>
		/// ldarg.s
		/// </summary>
		Ldarg_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5),

		/// <summary>
		/// ldarga.s
		/// </summary>
		Ldarga_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5),

		/// <summary>
		/// ldloc.s
		/// </summary>
		Ldloc_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),

		/// <summary>
		/// ldloca.s
		/// </summary>
		Ldloca_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),

		/// <summary>
		/// starg.s
		/// </summary>
		Starg_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5),

		/// <summary>
		/// stloc.s
		/// </summary>
		Stloc_S = OpCodeOperand.ShortInlineVar
			| (EmitMethod.Emit_Byte << 5)
			| (EmitMethod.Emit_LocalBuilder << 5),
		#endregion
	}

	static partial class EmitMatrix
	{
		public static OpCodeOperand GetOperand(this OpCode opCode) => (OpCodeOperand)((int)opCode & 0x1F);
		public static EmitMethod GetSupportedMethods(this OpCode opCode) => (EmitMethod)((int)opCode >> 5 & 0x7FFFF);

		public static OpCode GetOpCode(IFieldSymbol field)
		{
			if (field.ContainingType.IsMatch("System.Reflection.Emit.OpCodes"))
			{
				return GetOpCode(field.Name);
			}

			return OpCode.Invalid;
		}

		public static OpCode GetOpCode(string field)
		{
			switch (field)
			{
				case nameof(OpCode.Add): return OpCode.Add;
				case nameof(OpCode.Add_Ovf): return OpCode.Add_Ovf;
				case nameof(OpCode.Add_Ovf_Un): return OpCode.Add_Ovf_Un;
				case nameof(OpCode.And): return OpCode.And;
				case nameof(OpCode.Arglist): return OpCode.Arglist;
				case nameof(OpCode.Beq): return OpCode.Beq;
				case nameof(OpCode.Beq_S): return OpCode.Beq_S;
				case nameof(OpCode.Bge): return OpCode.Bge;
				case nameof(OpCode.Bge_S): return OpCode.Bge_S;
				case nameof(OpCode.Bge_Un): return OpCode.Bge_Un;
				case nameof(OpCode.Bge_Un_S): return OpCode.Bge_Un_S;
				case nameof(OpCode.Bgt): return OpCode.Bgt;
				case nameof(OpCode.Bgt_S): return OpCode.Bgt_S;
				case nameof(OpCode.Bgt_Un): return OpCode.Bgt_Un;
				case nameof(OpCode.Bgt_Un_S): return OpCode.Bgt_Un_S;
				case nameof(OpCode.Ble): return OpCode.Ble;
				case nameof(OpCode.Ble_S): return OpCode.Ble_S;
				case nameof(OpCode.Ble_Un): return OpCode.Ble_Un;
				case nameof(OpCode.Ble_Un_S): return OpCode.Ble_Un_S;
				case nameof(OpCode.Blt): return OpCode.Blt;
				case nameof(OpCode.Blt_S): return OpCode.Blt_S;
				case nameof(OpCode.Blt_Un): return OpCode.Blt_Un;
				case nameof(OpCode.Blt_Un_S): return OpCode.Blt_Un_S;
				case nameof(OpCode.Bne_Un): return OpCode.Bne_Un;
				case nameof(OpCode.Bne_Un_S): return OpCode.Bne_Un_S;
				case nameof(OpCode.Box): return OpCode.Box;
				case nameof(OpCode.Br): return OpCode.Br;
				case nameof(OpCode.Br_S): return OpCode.Br_S;
				case nameof(OpCode.Break): return OpCode.Break;
				case nameof(OpCode.Brfalse): return OpCode.Brfalse;
				case nameof(OpCode.Brfalse_S): return OpCode.Brfalse_S;
				case nameof(OpCode.Brtrue): return OpCode.Brtrue;
				case nameof(OpCode.Brtrue_S): return OpCode.Brtrue_S;
				case nameof(OpCode.Call): return OpCode.Call;
				case nameof(OpCode.Calli): return OpCode.Calli;
				case nameof(OpCode.Callvirt): return OpCode.Callvirt;
				case nameof(OpCode.Castclass): return OpCode.Castclass;
				case nameof(OpCode.Ceq): return OpCode.Ceq;
				case nameof(OpCode.Cgt): return OpCode.Cgt;
				case nameof(OpCode.Cgt_Un): return OpCode.Cgt_Un;
				case nameof(OpCode.Ckfinite): return OpCode.Ckfinite;
				case nameof(OpCode.Clt): return OpCode.Clt;
				case nameof(OpCode.Clt_Un): return OpCode.Clt_Un;
				case nameof(OpCode.Constrained): return OpCode.Constrained;
				case nameof(OpCode.Conv_I): return OpCode.Conv_I;
				case nameof(OpCode.Conv_I1): return OpCode.Conv_I1;
				case nameof(OpCode.Conv_I2): return OpCode.Conv_I2;
				case nameof(OpCode.Conv_I4): return OpCode.Conv_I4;
				case nameof(OpCode.Conv_I8): return OpCode.Conv_I8;
				case nameof(OpCode.Conv_Ovf_I): return OpCode.Conv_Ovf_I;
				case nameof(OpCode.Conv_Ovf_I_Un): return OpCode.Conv_Ovf_I_Un;
				case nameof(OpCode.Conv_Ovf_I1): return OpCode.Conv_Ovf_I1;
				case nameof(OpCode.Conv_Ovf_I1_Un): return OpCode.Conv_Ovf_I1_Un;
				case nameof(OpCode.Conv_Ovf_I2): return OpCode.Conv_Ovf_I2;
				case nameof(OpCode.Conv_Ovf_I2_Un): return OpCode.Conv_Ovf_I2_Un;
				case nameof(OpCode.Conv_Ovf_I4): return OpCode.Conv_Ovf_I4;
				case nameof(OpCode.Conv_Ovf_I4_Un): return OpCode.Conv_Ovf_I4_Un;
				case nameof(OpCode.Conv_Ovf_I8): return OpCode.Conv_Ovf_I8;
				case nameof(OpCode.Conv_Ovf_I8_Un): return OpCode.Conv_Ovf_I8_Un;
				case nameof(OpCode.Conv_Ovf_U): return OpCode.Conv_Ovf_U;
				case nameof(OpCode.Conv_Ovf_U_Un): return OpCode.Conv_Ovf_U_Un;
				case nameof(OpCode.Conv_Ovf_U1): return OpCode.Conv_Ovf_U1;
				case nameof(OpCode.Conv_Ovf_U1_Un): return OpCode.Conv_Ovf_U1_Un;
				case nameof(OpCode.Conv_Ovf_U2): return OpCode.Conv_Ovf_U2;
				case nameof(OpCode.Conv_Ovf_U2_Un): return OpCode.Conv_Ovf_U2_Un;
				case nameof(OpCode.Conv_Ovf_U4): return OpCode.Conv_Ovf_U4;
				case nameof(OpCode.Conv_Ovf_U4_Un): return OpCode.Conv_Ovf_U4_Un;
				case nameof(OpCode.Conv_Ovf_U8): return OpCode.Conv_Ovf_U8;
				case nameof(OpCode.Conv_Ovf_U8_Un): return OpCode.Conv_Ovf_U8_Un;
				case nameof(OpCode.Conv_R_Un): return OpCode.Conv_R_Un;
				case nameof(OpCode.Conv_R4): return OpCode.Conv_R4;
				case nameof(OpCode.Conv_R8): return OpCode.Conv_R8;
				case nameof(OpCode.Conv_U): return OpCode.Conv_U;
				case nameof(OpCode.Conv_U1): return OpCode.Conv_U1;
				case nameof(OpCode.Conv_U2): return OpCode.Conv_U2;
				case nameof(OpCode.Conv_U4): return OpCode.Conv_U4;
				case nameof(OpCode.Conv_U8): return OpCode.Conv_U8;
				case nameof(OpCode.Cpblk): return OpCode.Cpblk;
				case nameof(OpCode.Cpobj): return OpCode.Cpobj;
				case nameof(OpCode.Div): return OpCode.Div;
				case nameof(OpCode.Div_Un): return OpCode.Div_Un;
				case nameof(OpCode.Dup): return OpCode.Dup;
				case nameof(OpCode.Endfilter): return OpCode.Endfilter;
				case nameof(OpCode.Endfinally): return OpCode.Endfinally;
				case nameof(OpCode.Initblk): return OpCode.Initblk;
				case nameof(OpCode.Initobj): return OpCode.Initobj;
				case nameof(OpCode.Isinst): return OpCode.Isinst;
				case nameof(OpCode.Jmp): return OpCode.Jmp;
				case nameof(OpCode.Ldarg): return OpCode.Ldarg;
				case nameof(OpCode.Ldarg_0): return OpCode.Ldarg_0;
				case nameof(OpCode.Ldarg_1): return OpCode.Ldarg_1;
				case nameof(OpCode.Ldarg_2): return OpCode.Ldarg_2;
				case nameof(OpCode.Ldarg_3): return OpCode.Ldarg_3;
				case nameof(OpCode.Ldarg_S): return OpCode.Ldarg_S;
				case nameof(OpCode.Ldarga): return OpCode.Ldarga;
				case nameof(OpCode.Ldarga_S): return OpCode.Ldarga_S;
				case nameof(OpCode.Ldc_I4): return OpCode.Ldc_I4;
				case nameof(OpCode.Ldc_I4_0): return OpCode.Ldc_I4_0;
				case nameof(OpCode.Ldc_I4_1): return OpCode.Ldc_I4_1;
				case nameof(OpCode.Ldc_I4_2): return OpCode.Ldc_I4_2;
				case nameof(OpCode.Ldc_I4_3): return OpCode.Ldc_I4_3;
				case nameof(OpCode.Ldc_I4_4): return OpCode.Ldc_I4_4;
				case nameof(OpCode.Ldc_I4_5): return OpCode.Ldc_I4_5;
				case nameof(OpCode.Ldc_I4_6): return OpCode.Ldc_I4_6;
				case nameof(OpCode.Ldc_I4_7): return OpCode.Ldc_I4_7;
				case nameof(OpCode.Ldc_I4_8): return OpCode.Ldc_I4_8;
				case nameof(OpCode.Ldc_I4_M1): return OpCode.Ldc_I4_M1;
				case nameof(OpCode.Ldc_I4_S): return OpCode.Ldc_I4_S;
				case nameof(OpCode.Ldc_I8): return OpCode.Ldc_I8;
				case nameof(OpCode.Ldc_R4): return OpCode.Ldc_R4;
				case nameof(OpCode.Ldc_R8): return OpCode.Ldc_R8;
				case nameof(OpCode.Ldelem): return OpCode.Ldelem;
				case nameof(OpCode.Ldelem_I): return OpCode.Ldelem_I;
				case nameof(OpCode.Ldelem_I1): return OpCode.Ldelem_I1;
				case nameof(OpCode.Ldelem_I2): return OpCode.Ldelem_I2;
				case nameof(OpCode.Ldelem_I4): return OpCode.Ldelem_I4;
				case nameof(OpCode.Ldelem_I8): return OpCode.Ldelem_I8;
				case nameof(OpCode.Ldelem_R4): return OpCode.Ldelem_R4;
				case nameof(OpCode.Ldelem_R8): return OpCode.Ldelem_R8;
				case nameof(OpCode.Ldelem_Ref): return OpCode.Ldelem_Ref;
				case nameof(OpCode.Ldelem_U1): return OpCode.Ldelem_U1;
				case nameof(OpCode.Ldelem_U2): return OpCode.Ldelem_U2;
				case nameof(OpCode.Ldelem_U4): return OpCode.Ldelem_U4;
				case nameof(OpCode.Ldelema): return OpCode.Ldelema;
				case nameof(OpCode.Ldfld): return OpCode.Ldfld;
				case nameof(OpCode.Ldflda): return OpCode.Ldflda;
				case nameof(OpCode.Ldftn): return OpCode.Ldftn;
				case nameof(OpCode.Ldind_I): return OpCode.Ldind_I;
				case nameof(OpCode.Ldind_I1): return OpCode.Ldind_I1;
				case nameof(OpCode.Ldind_I2): return OpCode.Ldind_I2;
				case nameof(OpCode.Ldind_I4): return OpCode.Ldind_I4;
				case nameof(OpCode.Ldind_I8): return OpCode.Ldind_I8;
				case nameof(OpCode.Ldind_R4): return OpCode.Ldind_R4;
				case nameof(OpCode.Ldind_R8): return OpCode.Ldind_R8;
				case nameof(OpCode.Ldind_Ref): return OpCode.Ldind_Ref;
				case nameof(OpCode.Ldind_U1): return OpCode.Ldind_U1;
				case nameof(OpCode.Ldind_U2): return OpCode.Ldind_U2;
				case nameof(OpCode.Ldind_U4): return OpCode.Ldind_U4;
				case nameof(OpCode.Ldlen): return OpCode.Ldlen;
				case nameof(OpCode.Ldloc): return OpCode.Ldloc;
				case nameof(OpCode.Ldloc_0): return OpCode.Ldloc_0;
				case nameof(OpCode.Ldloc_1): return OpCode.Ldloc_1;
				case nameof(OpCode.Ldloc_2): return OpCode.Ldloc_2;
				case nameof(OpCode.Ldloc_3): return OpCode.Ldloc_3;
				case nameof(OpCode.Ldloc_S): return OpCode.Ldloc_S;
				case nameof(OpCode.Ldloca): return OpCode.Ldloca;
				case nameof(OpCode.Ldloca_S): return OpCode.Ldloca_S;
				case nameof(OpCode.Ldnull): return OpCode.Ldnull;
				case nameof(OpCode.Ldobj): return OpCode.Ldobj;
				case nameof(OpCode.Ldsfld): return OpCode.Ldsfld;
				case nameof(OpCode.Ldsflda): return OpCode.Ldsflda;
				case nameof(OpCode.Ldstr): return OpCode.Ldstr;
				case nameof(OpCode.Ldtoken): return OpCode.Ldtoken;
				case nameof(OpCode.Ldvirtftn): return OpCode.Ldvirtftn;
				case nameof(OpCode.Leave): return OpCode.Leave;
				case nameof(OpCode.Leave_S): return OpCode.Leave_S;
				case nameof(OpCode.Localloc): return OpCode.Localloc;
				case nameof(OpCode.Mkrefany): return OpCode.Mkrefany;
				case nameof(OpCode.Mul): return OpCode.Mul;
				case nameof(OpCode.Mul_Ovf): return OpCode.Mul_Ovf;
				case nameof(OpCode.Mul_Ovf_Un): return OpCode.Mul_Ovf_Un;
				case nameof(OpCode.Neg): return OpCode.Neg;
				case nameof(OpCode.Newarr): return OpCode.Newarr;
				case nameof(OpCode.Newobj): return OpCode.Newobj;
				case nameof(OpCode.Nop): return OpCode.Nop;
				case nameof(OpCode.Not): return OpCode.Not;
				case nameof(OpCode.Or): return OpCode.Or;
				case nameof(OpCode.Pop): return OpCode.Pop;
				case nameof(OpCode.Readonly): return OpCode.Readonly;
				case nameof(OpCode.Refanytype): return OpCode.Refanytype;
				case nameof(OpCode.Refanyval): return OpCode.Refanyval;
				case nameof(OpCode.Rem): return OpCode.Rem;
				case nameof(OpCode.Rem_Un): return OpCode.Rem_Un;
				case nameof(OpCode.Ret): return OpCode.Ret;
				case nameof(OpCode.Rethrow): return OpCode.Rethrow;
				case nameof(OpCode.Shl): return OpCode.Shl;
				case nameof(OpCode.Shr): return OpCode.Shr;
				case nameof(OpCode.Shr_Un): return OpCode.Shr_Un;
				case nameof(OpCode.Sizeof): return OpCode.Sizeof;
				case nameof(OpCode.Starg): return OpCode.Starg;
				case nameof(OpCode.Starg_S): return OpCode.Starg_S;
				case nameof(OpCode.Stelem): return OpCode.Stelem;
				case nameof(OpCode.Stelem_I): return OpCode.Stelem_I;
				case nameof(OpCode.Stelem_I1): return OpCode.Stelem_I1;
				case nameof(OpCode.Stelem_I2): return OpCode.Stelem_I2;
				case nameof(OpCode.Stelem_I4): return OpCode.Stelem_I4;
				case nameof(OpCode.Stelem_I8): return OpCode.Stelem_I8;
				case nameof(OpCode.Stelem_R4): return OpCode.Stelem_R4;
				case nameof(OpCode.Stelem_R8): return OpCode.Stelem_R8;
				case nameof(OpCode.Stelem_Ref): return OpCode.Stelem_Ref;
				case nameof(OpCode.Stfld): return OpCode.Stfld;
				case nameof(OpCode.Stind_I): return OpCode.Stind_I;
				case nameof(OpCode.Stind_I1): return OpCode.Stind_I1;
				case nameof(OpCode.Stind_I2): return OpCode.Stind_I2;
				case nameof(OpCode.Stind_I4): return OpCode.Stind_I4;
				case nameof(OpCode.Stind_I8): return OpCode.Stind_I8;
				case nameof(OpCode.Stind_R4): return OpCode.Stind_R4;
				case nameof(OpCode.Stind_R8): return OpCode.Stind_R8;
				case nameof(OpCode.Stind_Ref): return OpCode.Stind_Ref;
				case nameof(OpCode.Stloc): return OpCode.Stloc;
				case nameof(OpCode.Stloc_0): return OpCode.Stloc_0;
				case nameof(OpCode.Stloc_1): return OpCode.Stloc_1;
				case nameof(OpCode.Stloc_2): return OpCode.Stloc_2;
				case nameof(OpCode.Stloc_3): return OpCode.Stloc_3;
				case nameof(OpCode.Stloc_S): return OpCode.Stloc_S;
				case nameof(OpCode.Stobj): return OpCode.Stobj;
				case nameof(OpCode.Stsfld): return OpCode.Stsfld;
				case nameof(OpCode.Sub): return OpCode.Sub;
				case nameof(OpCode.Sub_Ovf): return OpCode.Sub_Ovf;
				case nameof(OpCode.Sub_Ovf_Un): return OpCode.Sub_Ovf_Un;
				case nameof(OpCode.Switch): return OpCode.Switch;
				case nameof(OpCode.Tailcall): return OpCode.Tailcall;
				case nameof(OpCode.Throw): return OpCode.Throw;
				case nameof(OpCode.Unaligned): return OpCode.Unaligned;
				case nameof(OpCode.Unbox): return OpCode.Unbox;
				case nameof(OpCode.Unbox_Any): return OpCode.Unbox_Any;
				case nameof(OpCode.Volatile): return OpCode.Volatile;
				case nameof(OpCode.Xor): return OpCode.Xor;
			}

			return OpCode.Invalid;
		}
	}
}
