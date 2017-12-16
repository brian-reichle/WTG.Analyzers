using System;
using System.CodeDom.Compiler;
using Microsoft.CodeAnalysis;
using WTG.Analyzers.Utils;

namespace WTG.Analyzers
{
	[GeneratedCode("EmitMatrix", "1.0")]
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

	[GeneratedCode("EmitMatrix", "1.0")]
	enum SimpleOpCode
	{
		Invalid = 0,
		#region InlineBrTarget

		/// <summary>
		/// beq
		/// </summary>
		Beq = 1,

		/// <summary>
		/// bge
		/// </summary>
		Bge = 2,

		/// <summary>
		/// bge.un
		/// </summary>
		Bge_Un = 3,

		/// <summary>
		/// bgt
		/// </summary>
		Bgt = 4,

		/// <summary>
		/// bgt.un
		/// </summary>
		Bgt_Un = 5,

		/// <summary>
		/// ble
		/// </summary>
		Ble = 6,

		/// <summary>
		/// ble.un
		/// </summary>
		Ble_Un = 7,

		/// <summary>
		/// blt
		/// </summary>
		Blt = 8,

		/// <summary>
		/// blt.un
		/// </summary>
		Blt_Un = 9,

		/// <summary>
		/// bne.un
		/// </summary>
		Bne_Un = 10,

		/// <summary>
		/// br
		/// </summary>
		Br = 11,

		/// <summary>
		/// brfalse
		/// </summary>
		Brfalse = 12,

		/// <summary>
		/// brtrue
		/// </summary>
		Brtrue = 13,

		/// <summary>
		/// leave
		/// </summary>
		Leave = 14,
		#endregion
		#region InlineField

		/// <summary>
		/// ldfld
		/// </summary>
		Ldfld = 15,

		/// <summary>
		/// ldflda
		/// </summary>
		Ldflda = 16,

		/// <summary>
		/// ldsfld
		/// </summary>
		Ldsfld = 17,

		/// <summary>
		/// ldsflda
		/// </summary>
		Ldsflda = 18,

		/// <summary>
		/// stfld
		/// </summary>
		Stfld = 19,

		/// <summary>
		/// stsfld
		/// </summary>
		Stsfld = 20,
		#endregion
		#region InlineI

		/// <summary>
		/// ldc.i4
		/// </summary>
		Ldc_I4 = 21,
		#endregion
		#region InlineI8

		/// <summary>
		/// ldc.i8
		/// </summary>
		Ldc_I8 = 22,
		#endregion
		#region InlineMethod

		/// <summary>
		/// call
		/// </summary>
		Call = 23,

		/// <summary>
		/// callvirt
		/// </summary>
		Callvirt = 24,

		/// <summary>
		/// jmp
		/// </summary>
		Jmp = 25,

		/// <summary>
		/// ldftn
		/// </summary>
		Ldftn = 26,

		/// <summary>
		/// ldvirtftn
		/// </summary>
		Ldvirtftn = 27,

		/// <summary>
		/// newobj
		/// </summary>
		Newobj = 28,
		#endregion
		#region InlineNone

		/// <summary>
		/// add
		/// </summary>
		Add = 29,

		/// <summary>
		/// add.ovf
		/// </summary>
		Add_Ovf = 30,

		/// <summary>
		/// add.ovf.un
		/// </summary>
		Add_Ovf_Un = 31,

		/// <summary>
		/// and
		/// </summary>
		And = 32,

		/// <summary>
		/// arglist
		/// </summary>
		Arglist = 33,

		/// <summary>
		/// break
		/// </summary>
		Break = 34,

		/// <summary>
		/// ceq
		/// </summary>
		Ceq = 35,

		/// <summary>
		/// cgt
		/// </summary>
		Cgt = 36,

		/// <summary>
		/// cgt.un
		/// </summary>
		Cgt_Un = 37,

		/// <summary>
		/// ckfinite
		/// </summary>
		Ckfinite = 38,

		/// <summary>
		/// clt
		/// </summary>
		Clt = 39,

		/// <summary>
		/// clt.un
		/// </summary>
		Clt_Un = 40,

		/// <summary>
		/// conv.i
		/// </summary>
		Conv_I = 41,

		/// <summary>
		/// conv.i1
		/// </summary>
		Conv_I1 = 42,

		/// <summary>
		/// conv.i2
		/// </summary>
		Conv_I2 = 43,

		/// <summary>
		/// conv.i4
		/// </summary>
		Conv_I4 = 44,

		/// <summary>
		/// conv.i8
		/// </summary>
		Conv_I8 = 45,

		/// <summary>
		/// conv.ovf.i
		/// </summary>
		Conv_Ovf_I = 46,

		/// <summary>
		/// conv.ovf.i.un
		/// </summary>
		Conv_Ovf_I_Un = 47,

		/// <summary>
		/// conv.ovf.i1
		/// </summary>
		Conv_Ovf_I1 = 48,

		/// <summary>
		/// conv.ovf.i1.un
		/// </summary>
		Conv_Ovf_I1_Un = 49,

		/// <summary>
		/// conv.ovf.i2
		/// </summary>
		Conv_Ovf_I2 = 50,

		/// <summary>
		/// conv.ovf.i2.un
		/// </summary>
		Conv_Ovf_I2_Un = 51,

		/// <summary>
		/// conv.ovf.i4
		/// </summary>
		Conv_Ovf_I4 = 52,

		/// <summary>
		/// conv.ovf.i4.un
		/// </summary>
		Conv_Ovf_I4_Un = 53,

		/// <summary>
		/// conv.ovf.i8
		/// </summary>
		Conv_Ovf_I8 = 54,

		/// <summary>
		/// conv.ovf.i8.un
		/// </summary>
		Conv_Ovf_I8_Un = 55,

		/// <summary>
		/// conv.ovf.u
		/// </summary>
		Conv_Ovf_U = 56,

		/// <summary>
		/// conv.ovf.u.un
		/// </summary>
		Conv_Ovf_U_Un = 57,

		/// <summary>
		/// conv.ovf.u1
		/// </summary>
		Conv_Ovf_U1 = 58,

		/// <summary>
		/// conv.ovf.u1.un
		/// </summary>
		Conv_Ovf_U1_Un = 59,

		/// <summary>
		/// conv.ovf.u2
		/// </summary>
		Conv_Ovf_U2 = 60,

		/// <summary>
		/// conv.ovf.u2.un
		/// </summary>
		Conv_Ovf_U2_Un = 61,

		/// <summary>
		/// conv.ovf.u4
		/// </summary>
		Conv_Ovf_U4 = 62,

		/// <summary>
		/// conv.ovf.u4.un
		/// </summary>
		Conv_Ovf_U4_Un = 63,

		/// <summary>
		/// conv.ovf.u8
		/// </summary>
		Conv_Ovf_U8 = 64,

		/// <summary>
		/// conv.ovf.u8.un
		/// </summary>
		Conv_Ovf_U8_Un = 65,

		/// <summary>
		/// conv.r.un
		/// </summary>
		Conv_R_Un = 66,

		/// <summary>
		/// conv.r4
		/// </summary>
		Conv_R4 = 67,

		/// <summary>
		/// conv.r8
		/// </summary>
		Conv_R8 = 68,

		/// <summary>
		/// conv.u
		/// </summary>
		Conv_U = 69,

		/// <summary>
		/// conv.u1
		/// </summary>
		Conv_U1 = 70,

		/// <summary>
		/// conv.u2
		/// </summary>
		Conv_U2 = 71,

		/// <summary>
		/// conv.u4
		/// </summary>
		Conv_U4 = 72,

		/// <summary>
		/// conv.u8
		/// </summary>
		Conv_U8 = 73,

		/// <summary>
		/// cpblk
		/// </summary>
		Cpblk = 74,

		/// <summary>
		/// div
		/// </summary>
		Div = 75,

		/// <summary>
		/// div.un
		/// </summary>
		Div_Un = 76,

		/// <summary>
		/// dup
		/// </summary>
		Dup = 77,

		/// <summary>
		/// endfilter
		/// </summary>
		Endfilter = 78,

		/// <summary>
		/// endfinally
		/// </summary>
		Endfinally = 79,

		/// <summary>
		/// initblk
		/// </summary>
		Initblk = 80,

		/// <summary>
		/// ldarg.0
		/// </summary>
		Ldarg_0 = 81,

		/// <summary>
		/// ldarg.1
		/// </summary>
		Ldarg_1 = 82,

		/// <summary>
		/// ldarg.2
		/// </summary>
		Ldarg_2 = 83,

		/// <summary>
		/// ldarg.3
		/// </summary>
		Ldarg_3 = 84,

		/// <summary>
		/// ldc.i4.0
		/// </summary>
		Ldc_I4_0 = 85,

		/// <summary>
		/// ldc.i4.1
		/// </summary>
		Ldc_I4_1 = 86,

		/// <summary>
		/// ldc.i4.2
		/// </summary>
		Ldc_I4_2 = 87,

		/// <summary>
		/// ldc.i4.3
		/// </summary>
		Ldc_I4_3 = 88,

		/// <summary>
		/// ldc.i4.4
		/// </summary>
		Ldc_I4_4 = 89,

		/// <summary>
		/// ldc.i4.5
		/// </summary>
		Ldc_I4_5 = 90,

		/// <summary>
		/// ldc.i4.6
		/// </summary>
		Ldc_I4_6 = 91,

		/// <summary>
		/// ldc.i4.7
		/// </summary>
		Ldc_I4_7 = 92,

		/// <summary>
		/// ldc.i4.8
		/// </summary>
		Ldc_I4_8 = 93,

		/// <summary>
		/// ldc.i4.m1
		/// </summary>
		Ldc_I4_M1 = 94,

		/// <summary>
		/// ldelem.i
		/// </summary>
		Ldelem_I = 95,

		/// <summary>
		/// ldelem.i1
		/// </summary>
		Ldelem_I1 = 96,

		/// <summary>
		/// ldelem.i2
		/// </summary>
		Ldelem_I2 = 97,

		/// <summary>
		/// ldelem.i4
		/// </summary>
		Ldelem_I4 = 98,

		/// <summary>
		/// ldelem.i8
		/// </summary>
		Ldelem_I8 = 99,

		/// <summary>
		/// ldelem.r4
		/// </summary>
		Ldelem_R4 = 100,

		/// <summary>
		/// ldelem.r8
		/// </summary>
		Ldelem_R8 = 101,

		/// <summary>
		/// ldelem.ref
		/// </summary>
		Ldelem_Ref = 102,

		/// <summary>
		/// ldelem.u1
		/// </summary>
		Ldelem_U1 = 103,

		/// <summary>
		/// ldelem.u2
		/// </summary>
		Ldelem_U2 = 104,

		/// <summary>
		/// ldelem.u4
		/// </summary>
		Ldelem_U4 = 105,

		/// <summary>
		/// ldind.i
		/// </summary>
		Ldind_I = 106,

		/// <summary>
		/// ldind.i1
		/// </summary>
		Ldind_I1 = 107,

		/// <summary>
		/// ldind.i2
		/// </summary>
		Ldind_I2 = 108,

		/// <summary>
		/// ldind.i4
		/// </summary>
		Ldind_I4 = 109,

		/// <summary>
		/// ldind.i8
		/// </summary>
		Ldind_I8 = 110,

		/// <summary>
		/// ldind.r4
		/// </summary>
		Ldind_R4 = 111,

		/// <summary>
		/// ldind.r8
		/// </summary>
		Ldind_R8 = 112,

		/// <summary>
		/// ldind.ref
		/// </summary>
		Ldind_Ref = 113,

		/// <summary>
		/// ldind.u1
		/// </summary>
		Ldind_U1 = 114,

		/// <summary>
		/// ldind.u2
		/// </summary>
		Ldind_U2 = 115,

		/// <summary>
		/// ldind.u4
		/// </summary>
		Ldind_U4 = 116,

		/// <summary>
		/// ldlen
		/// </summary>
		Ldlen = 117,

		/// <summary>
		/// ldloc.0
		/// </summary>
		Ldloc_0 = 118,

		/// <summary>
		/// ldloc.1
		/// </summary>
		Ldloc_1 = 119,

		/// <summary>
		/// ldloc.2
		/// </summary>
		Ldloc_2 = 120,

		/// <summary>
		/// ldloc.3
		/// </summary>
		Ldloc_3 = 121,

		/// <summary>
		/// ldnull
		/// </summary>
		Ldnull = 122,

		/// <summary>
		/// localloc
		/// </summary>
		Localloc = 123,

		/// <summary>
		/// mul
		/// </summary>
		Mul = 124,

		/// <summary>
		/// mul.ovf
		/// </summary>
		Mul_Ovf = 125,

		/// <summary>
		/// mul.ovf.un
		/// </summary>
		Mul_Ovf_Un = 126,

		/// <summary>
		/// neg
		/// </summary>
		Neg = 127,

		/// <summary>
		/// nop
		/// </summary>
		Nop = 128,

		/// <summary>
		/// not
		/// </summary>
		Not = 129,

		/// <summary>
		/// or
		/// </summary>
		Or = 130,

		/// <summary>
		/// pop
		/// </summary>
		Pop = 131,

		/// <summary>
		/// readonly.
		/// </summary>
		Readonly = 132,

		/// <summary>
		/// refanytype
		/// </summary>
		Refanytype = 133,

		/// <summary>
		/// rem
		/// </summary>
		Rem = 134,

		/// <summary>
		/// rem.un
		/// </summary>
		Rem_Un = 135,

		/// <summary>
		/// ret
		/// </summary>
		Ret = 136,

		/// <summary>
		/// rethrow
		/// </summary>
		Rethrow = 137,

		/// <summary>
		/// shl
		/// </summary>
		Shl = 138,

		/// <summary>
		/// shr
		/// </summary>
		Shr = 139,

		/// <summary>
		/// shr.un
		/// </summary>
		Shr_Un = 140,

		/// <summary>
		/// stelem.i
		/// </summary>
		Stelem_I = 141,

		/// <summary>
		/// stelem.i1
		/// </summary>
		Stelem_I1 = 142,

		/// <summary>
		/// stelem.i2
		/// </summary>
		Stelem_I2 = 143,

		/// <summary>
		/// stelem.i4
		/// </summary>
		Stelem_I4 = 144,

		/// <summary>
		/// stelem.i8
		/// </summary>
		Stelem_I8 = 145,

		/// <summary>
		/// stelem.r4
		/// </summary>
		Stelem_R4 = 146,

		/// <summary>
		/// stelem.r8
		/// </summary>
		Stelem_R8 = 147,

		/// <summary>
		/// stelem.ref
		/// </summary>
		Stelem_Ref = 148,

		/// <summary>
		/// stind.i
		/// </summary>
		Stind_I = 149,

		/// <summary>
		/// stind.i1
		/// </summary>
		Stind_I1 = 150,

		/// <summary>
		/// stind.i2
		/// </summary>
		Stind_I2 = 151,

		/// <summary>
		/// stind.i4
		/// </summary>
		Stind_I4 = 152,

		/// <summary>
		/// stind.i8
		/// </summary>
		Stind_I8 = 153,

		/// <summary>
		/// stind.r4
		/// </summary>
		Stind_R4 = 154,

		/// <summary>
		/// stind.r8
		/// </summary>
		Stind_R8 = 155,

		/// <summary>
		/// stind.ref
		/// </summary>
		Stind_Ref = 156,

		/// <summary>
		/// stloc.0
		/// </summary>
		Stloc_0 = 157,

		/// <summary>
		/// stloc.1
		/// </summary>
		Stloc_1 = 158,

		/// <summary>
		/// stloc.2
		/// </summary>
		Stloc_2 = 159,

		/// <summary>
		/// stloc.3
		/// </summary>
		Stloc_3 = 160,

		/// <summary>
		/// sub
		/// </summary>
		Sub = 161,

		/// <summary>
		/// sub.ovf
		/// </summary>
		Sub_Ovf = 162,

		/// <summary>
		/// sub.ovf.un
		/// </summary>
		Sub_Ovf_Un = 163,

		/// <summary>
		/// tail.
		/// </summary>
		Tailcall = 164,

		/// <summary>
		/// throw
		/// </summary>
		Throw = 165,

		/// <summary>
		/// volatile.
		/// </summary>
		Volatile = 166,

		/// <summary>
		/// xor
		/// </summary>
		Xor = 167,
		#endregion
		#region InlineR

		/// <summary>
		/// ldc.r8
		/// </summary>
		Ldc_R8 = 168,
		#endregion
		#region InlineSig

		/// <summary>
		/// calli
		/// </summary>
		Calli = 169,
		#endregion
		#region InlineString

		/// <summary>
		/// ldstr
		/// </summary>
		Ldstr = 170,
		#endregion
		#region InlineSwitch

		/// <summary>
		/// switch
		/// </summary>
		Switch = 171,
		#endregion
		#region InlineTok

		/// <summary>
		/// ldtoken
		/// </summary>
		Ldtoken = 172,
		#endregion
		#region InlineType

		/// <summary>
		/// box
		/// </summary>
		Box = 173,

		/// <summary>
		/// castclass
		/// </summary>
		Castclass = 174,

		/// <summary>
		/// constrained.
		/// </summary>
		Constrained = 175,

		/// <summary>
		/// cpobj
		/// </summary>
		Cpobj = 176,

		/// <summary>
		/// initobj
		/// </summary>
		Initobj = 177,

		/// <summary>
		/// isinst
		/// </summary>
		Isinst = 178,

		/// <summary>
		/// ldelem
		/// </summary>
		Ldelem = 179,

		/// <summary>
		/// ldelema
		/// </summary>
		Ldelema = 180,

		/// <summary>
		/// ldobj
		/// </summary>
		Ldobj = 181,

		/// <summary>
		/// mkrefany
		/// </summary>
		Mkrefany = 182,

		/// <summary>
		/// newarr
		/// </summary>
		Newarr = 183,

		/// <summary>
		/// refanyval
		/// </summary>
		Refanyval = 184,

		/// <summary>
		/// sizeof
		/// </summary>
		Sizeof = 185,

		/// <summary>
		/// stelem
		/// </summary>
		Stelem = 186,

		/// <summary>
		/// stobj
		/// </summary>
		Stobj = 187,

		/// <summary>
		/// unbox
		/// </summary>
		Unbox = 188,

		/// <summary>
		/// unbox.any
		/// </summary>
		Unbox_Any = 189,
		#endregion
		#region InlineVar

		/// <summary>
		/// ldarg
		/// </summary>
		Ldarg = 190,

		/// <summary>
		/// ldarga
		/// </summary>
		Ldarga = 191,

		/// <summary>
		/// ldloc
		/// </summary>
		Ldloc = 192,

		/// <summary>
		/// ldloca
		/// </summary>
		Ldloca = 193,

		/// <summary>
		/// starg
		/// </summary>
		Starg = 194,

		/// <summary>
		/// stloc
		/// </summary>
		Stloc = 195,
		#endregion
		#region ShortInlineBrTarget

		/// <summary>
		/// beq.s
		/// </summary>
		Beq_S = 196,

		/// <summary>
		/// bge.s
		/// </summary>
		Bge_S = 197,

		/// <summary>
		/// bge.un.s
		/// </summary>
		Bge_Un_S = 198,

		/// <summary>
		/// bgt.s
		/// </summary>
		Bgt_S = 199,

		/// <summary>
		/// bgt.un.s
		/// </summary>
		Bgt_Un_S = 200,

		/// <summary>
		/// ble.s
		/// </summary>
		Ble_S = 201,

		/// <summary>
		/// ble.un.s
		/// </summary>
		Ble_Un_S = 202,

		/// <summary>
		/// blt.s
		/// </summary>
		Blt_S = 203,

		/// <summary>
		/// blt.un.s
		/// </summary>
		Blt_Un_S = 204,

		/// <summary>
		/// bne.un.s
		/// </summary>
		Bne_Un_S = 205,

		/// <summary>
		/// br.s
		/// </summary>
		Br_S = 206,

		/// <summary>
		/// brfalse.s
		/// </summary>
		Brfalse_S = 207,

		/// <summary>
		/// brtrue.s
		/// </summary>
		Brtrue_S = 208,

		/// <summary>
		/// leave.s
		/// </summary>
		Leave_S = 209,
		#endregion
		#region ShortInlineI

		/// <summary>
		/// ldc.i4.s
		/// </summary>
		Ldc_I4_S = 210,

		/// <summary>
		/// unaligned.
		/// </summary>
		Unaligned = 211,
		#endregion
		#region ShortInlineR

		/// <summary>
		/// ldc.r4
		/// </summary>
		Ldc_R4 = 212,
		#endregion
		#region ShortInlineVar

		/// <summary>
		/// ldarg.s
		/// </summary>
		Ldarg_S = 213,

		/// <summary>
		/// ldarga.s
		/// </summary>
		Ldarga_S = 214,

		/// <summary>
		/// ldloc.s
		/// </summary>
		Ldloc_S = 215,

		/// <summary>
		/// ldloca.s
		/// </summary>
		Ldloca_S = 216,

		/// <summary>
		/// starg.s
		/// </summary>
		Starg_S = 217,

		/// <summary>
		/// stloc.s
		/// </summary>
		Stloc_S = 218,
		#endregion
	}

	[Flags]
	[GeneratedCode("EmitMatrix", "1.0")]
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

	[GeneratedCode("EmitMatrix", "1.0")]
	enum OpCode
	{
		Invalid = 0,
		#region InlineBrTarget

		/// <summary>
		/// beq
		/// </summary>
		Beq = SimpleOpCode.Beq
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bge
		/// </summary>
		Bge = SimpleOpCode.Bge
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bge.un
		/// </summary>
		Bge_Un = SimpleOpCode.Bge_Un
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bgt
		/// </summary>
		Bgt = SimpleOpCode.Bgt
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bgt.un
		/// </summary>
		Bgt_Un = SimpleOpCode.Bgt_Un
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// ble
		/// </summary>
		Ble = SimpleOpCode.Ble
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// ble.un
		/// </summary>
		Ble_Un = SimpleOpCode.Ble_Un
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// blt
		/// </summary>
		Blt = SimpleOpCode.Blt
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// blt.un
		/// </summary>
		Blt_Un = SimpleOpCode.Blt_Un
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bne.un
		/// </summary>
		Bne_Un = SimpleOpCode.Bne_Un
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// br
		/// </summary>
		Br = SimpleOpCode.Br
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// brfalse
		/// </summary>
		Brfalse = SimpleOpCode.Brfalse
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// brtrue
		/// </summary>
		Brtrue = SimpleOpCode.Brtrue
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// leave
		/// </summary>
		Leave = SimpleOpCode.Leave
			| (OpCodeOperand.InlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),
		#endregion
		#region InlineField

		/// <summary>
		/// ldfld
		/// </summary>
		Ldfld = SimpleOpCode.Ldfld
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),

		/// <summary>
		/// ldflda
		/// </summary>
		Ldflda = SimpleOpCode.Ldflda
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),

		/// <summary>
		/// ldsfld
		/// </summary>
		Ldsfld = SimpleOpCode.Ldsfld
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),

		/// <summary>
		/// ldsflda
		/// </summary>
		Ldsflda = SimpleOpCode.Ldsflda
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),

		/// <summary>
		/// stfld
		/// </summary>
		Stfld = SimpleOpCode.Stfld
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),

		/// <summary>
		/// stsfld
		/// </summary>
		Stsfld = SimpleOpCode.Stsfld
			| (OpCodeOperand.InlineField << 8)
			| (EmitMethod.Emit_FieldInfo << 13),
		#endregion
		#region InlineI

		/// <summary>
		/// ldc.i4
		/// </summary>
		Ldc_I4 = SimpleOpCode.Ldc_I4
			| (OpCodeOperand.InlineI << 8)
			| (EmitMethod.Emit_Int32 << 13),
		#endregion
		#region InlineI8

		/// <summary>
		/// ldc.i8
		/// </summary>
		Ldc_I8 = SimpleOpCode.Ldc_I8
			| (OpCodeOperand.InlineI8 << 8)
			| (EmitMethod.Emit_Int64 << 13),
		#endregion
		#region InlineMethod

		/// <summary>
		/// call
		/// </summary>
		Call = SimpleOpCode.Call
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.EmitCall << 13)
			| (EmitMethod.Emit_MethodInfo << 13)
			| (EmitMethod.Emit_ConstructorInfo << 13),

		/// <summary>
		/// callvirt
		/// </summary>
		Callvirt = SimpleOpCode.Callvirt
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.EmitCall << 13)
			| (EmitMethod.Emit_MethodInfo << 13),

		/// <summary>
		/// jmp
		/// </summary>
		Jmp = SimpleOpCode.Jmp
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.Emit_MethodInfo << 13),

		/// <summary>
		/// ldftn
		/// </summary>
		Ldftn = SimpleOpCode.Ldftn
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.Emit_MethodInfo << 13),

		/// <summary>
		/// ldvirtftn
		/// </summary>
		Ldvirtftn = SimpleOpCode.Ldvirtftn
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.Emit_MethodInfo << 13),

		/// <summary>
		/// newobj
		/// </summary>
		Newobj = SimpleOpCode.Newobj
			| (OpCodeOperand.InlineMethod << 8)
			| (EmitMethod.Emit_ConstructorInfo << 13),
		#endregion
		#region InlineNone

		/// <summary>
		/// add
		/// </summary>
		Add = SimpleOpCode.Add
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// add.ovf
		/// </summary>
		Add_Ovf = SimpleOpCode.Add_Ovf
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// add.ovf.un
		/// </summary>
		Add_Ovf_Un = SimpleOpCode.Add_Ovf_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// and
		/// </summary>
		And = SimpleOpCode.And
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// arglist
		/// </summary>
		Arglist = SimpleOpCode.Arglist
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// break
		/// </summary>
		Break = SimpleOpCode.Break
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ceq
		/// </summary>
		Ceq = SimpleOpCode.Ceq
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// cgt
		/// </summary>
		Cgt = SimpleOpCode.Cgt
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// cgt.un
		/// </summary>
		Cgt_Un = SimpleOpCode.Cgt_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ckfinite
		/// </summary>
		Ckfinite = SimpleOpCode.Ckfinite
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// clt
		/// </summary>
		Clt = SimpleOpCode.Clt
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// clt.un
		/// </summary>
		Clt_Un = SimpleOpCode.Clt_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.i
		/// </summary>
		Conv_I = SimpleOpCode.Conv_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.i1
		/// </summary>
		Conv_I1 = SimpleOpCode.Conv_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.i2
		/// </summary>
		Conv_I2 = SimpleOpCode.Conv_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.i4
		/// </summary>
		Conv_I4 = SimpleOpCode.Conv_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.i8
		/// </summary>
		Conv_I8 = SimpleOpCode.Conv_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i
		/// </summary>
		Conv_Ovf_I = SimpleOpCode.Conv_Ovf_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i.un
		/// </summary>
		Conv_Ovf_I_Un = SimpleOpCode.Conv_Ovf_I_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i1
		/// </summary>
		Conv_Ovf_I1 = SimpleOpCode.Conv_Ovf_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i1.un
		/// </summary>
		Conv_Ovf_I1_Un = SimpleOpCode.Conv_Ovf_I1_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i2
		/// </summary>
		Conv_Ovf_I2 = SimpleOpCode.Conv_Ovf_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i2.un
		/// </summary>
		Conv_Ovf_I2_Un = SimpleOpCode.Conv_Ovf_I2_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i4
		/// </summary>
		Conv_Ovf_I4 = SimpleOpCode.Conv_Ovf_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i4.un
		/// </summary>
		Conv_Ovf_I4_Un = SimpleOpCode.Conv_Ovf_I4_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i8
		/// </summary>
		Conv_Ovf_I8 = SimpleOpCode.Conv_Ovf_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.i8.un
		/// </summary>
		Conv_Ovf_I8_Un = SimpleOpCode.Conv_Ovf_I8_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u
		/// </summary>
		Conv_Ovf_U = SimpleOpCode.Conv_Ovf_U
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u.un
		/// </summary>
		Conv_Ovf_U_Un = SimpleOpCode.Conv_Ovf_U_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u1
		/// </summary>
		Conv_Ovf_U1 = SimpleOpCode.Conv_Ovf_U1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u1.un
		/// </summary>
		Conv_Ovf_U1_Un = SimpleOpCode.Conv_Ovf_U1_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u2
		/// </summary>
		Conv_Ovf_U2 = SimpleOpCode.Conv_Ovf_U2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u2.un
		/// </summary>
		Conv_Ovf_U2_Un = SimpleOpCode.Conv_Ovf_U2_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u4
		/// </summary>
		Conv_Ovf_U4 = SimpleOpCode.Conv_Ovf_U4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u4.un
		/// </summary>
		Conv_Ovf_U4_Un = SimpleOpCode.Conv_Ovf_U4_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u8
		/// </summary>
		Conv_Ovf_U8 = SimpleOpCode.Conv_Ovf_U8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.ovf.u8.un
		/// </summary>
		Conv_Ovf_U8_Un = SimpleOpCode.Conv_Ovf_U8_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.r.un
		/// </summary>
		Conv_R_Un = SimpleOpCode.Conv_R_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.r4
		/// </summary>
		Conv_R4 = SimpleOpCode.Conv_R4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.r8
		/// </summary>
		Conv_R8 = SimpleOpCode.Conv_R8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.u
		/// </summary>
		Conv_U = SimpleOpCode.Conv_U
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.u1
		/// </summary>
		Conv_U1 = SimpleOpCode.Conv_U1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.u2
		/// </summary>
		Conv_U2 = SimpleOpCode.Conv_U2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.u4
		/// </summary>
		Conv_U4 = SimpleOpCode.Conv_U4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// conv.u8
		/// </summary>
		Conv_U8 = SimpleOpCode.Conv_U8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// cpblk
		/// </summary>
		Cpblk = SimpleOpCode.Cpblk
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// div
		/// </summary>
		Div = SimpleOpCode.Div
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// div.un
		/// </summary>
		Div_Un = SimpleOpCode.Div_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// dup
		/// </summary>
		Dup = SimpleOpCode.Dup
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// endfilter
		/// </summary>
		Endfilter = SimpleOpCode.Endfilter
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// endfinally
		/// </summary>
		Endfinally = SimpleOpCode.Endfinally
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// initblk
		/// </summary>
		Initblk = SimpleOpCode.Initblk
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldarg.0
		/// </summary>
		Ldarg_0 = SimpleOpCode.Ldarg_0
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldarg.1
		/// </summary>
		Ldarg_1 = SimpleOpCode.Ldarg_1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldarg.2
		/// </summary>
		Ldarg_2 = SimpleOpCode.Ldarg_2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldarg.3
		/// </summary>
		Ldarg_3 = SimpleOpCode.Ldarg_3
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.0
		/// </summary>
		Ldc_I4_0 = SimpleOpCode.Ldc_I4_0
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.1
		/// </summary>
		Ldc_I4_1 = SimpleOpCode.Ldc_I4_1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.2
		/// </summary>
		Ldc_I4_2 = SimpleOpCode.Ldc_I4_2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.3
		/// </summary>
		Ldc_I4_3 = SimpleOpCode.Ldc_I4_3
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.4
		/// </summary>
		Ldc_I4_4 = SimpleOpCode.Ldc_I4_4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.5
		/// </summary>
		Ldc_I4_5 = SimpleOpCode.Ldc_I4_5
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.6
		/// </summary>
		Ldc_I4_6 = SimpleOpCode.Ldc_I4_6
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.7
		/// </summary>
		Ldc_I4_7 = SimpleOpCode.Ldc_I4_7
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.8
		/// </summary>
		Ldc_I4_8 = SimpleOpCode.Ldc_I4_8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldc.i4.m1
		/// </summary>
		Ldc_I4_M1 = SimpleOpCode.Ldc_I4_M1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.i
		/// </summary>
		Ldelem_I = SimpleOpCode.Ldelem_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.i1
		/// </summary>
		Ldelem_I1 = SimpleOpCode.Ldelem_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.i2
		/// </summary>
		Ldelem_I2 = SimpleOpCode.Ldelem_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.i4
		/// </summary>
		Ldelem_I4 = SimpleOpCode.Ldelem_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.i8
		/// </summary>
		Ldelem_I8 = SimpleOpCode.Ldelem_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.r4
		/// </summary>
		Ldelem_R4 = SimpleOpCode.Ldelem_R4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.r8
		/// </summary>
		Ldelem_R8 = SimpleOpCode.Ldelem_R8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.ref
		/// </summary>
		Ldelem_Ref = SimpleOpCode.Ldelem_Ref
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.u1
		/// </summary>
		Ldelem_U1 = SimpleOpCode.Ldelem_U1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.u2
		/// </summary>
		Ldelem_U2 = SimpleOpCode.Ldelem_U2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldelem.u4
		/// </summary>
		Ldelem_U4 = SimpleOpCode.Ldelem_U4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.i
		/// </summary>
		Ldind_I = SimpleOpCode.Ldind_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.i1
		/// </summary>
		Ldind_I1 = SimpleOpCode.Ldind_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.i2
		/// </summary>
		Ldind_I2 = SimpleOpCode.Ldind_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.i4
		/// </summary>
		Ldind_I4 = SimpleOpCode.Ldind_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.i8
		/// </summary>
		Ldind_I8 = SimpleOpCode.Ldind_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.r4
		/// </summary>
		Ldind_R4 = SimpleOpCode.Ldind_R4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.r8
		/// </summary>
		Ldind_R8 = SimpleOpCode.Ldind_R8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.ref
		/// </summary>
		Ldind_Ref = SimpleOpCode.Ldind_Ref
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.u1
		/// </summary>
		Ldind_U1 = SimpleOpCode.Ldind_U1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.u2
		/// </summary>
		Ldind_U2 = SimpleOpCode.Ldind_U2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldind.u4
		/// </summary>
		Ldind_U4 = SimpleOpCode.Ldind_U4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldlen
		/// </summary>
		Ldlen = SimpleOpCode.Ldlen
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldloc.0
		/// </summary>
		Ldloc_0 = SimpleOpCode.Ldloc_0
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldloc.1
		/// </summary>
		Ldloc_1 = SimpleOpCode.Ldloc_1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldloc.2
		/// </summary>
		Ldloc_2 = SimpleOpCode.Ldloc_2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldloc.3
		/// </summary>
		Ldloc_3 = SimpleOpCode.Ldloc_3
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ldnull
		/// </summary>
		Ldnull = SimpleOpCode.Ldnull
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// localloc
		/// </summary>
		Localloc = SimpleOpCode.Localloc
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// mul
		/// </summary>
		Mul = SimpleOpCode.Mul
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// mul.ovf
		/// </summary>
		Mul_Ovf = SimpleOpCode.Mul_Ovf
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// mul.ovf.un
		/// </summary>
		Mul_Ovf_Un = SimpleOpCode.Mul_Ovf_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// neg
		/// </summary>
		Neg = SimpleOpCode.Neg
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// nop
		/// </summary>
		Nop = SimpleOpCode.Nop
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// not
		/// </summary>
		Not = SimpleOpCode.Not
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// or
		/// </summary>
		Or = SimpleOpCode.Or
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// pop
		/// </summary>
		Pop = SimpleOpCode.Pop
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// readonly.
		/// </summary>
		Readonly = SimpleOpCode.Readonly
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// refanytype
		/// </summary>
		Refanytype = SimpleOpCode.Refanytype
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// rem
		/// </summary>
		Rem = SimpleOpCode.Rem
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// rem.un
		/// </summary>
		Rem_Un = SimpleOpCode.Rem_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// ret
		/// </summary>
		Ret = SimpleOpCode.Ret
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// rethrow
		/// </summary>
		Rethrow = SimpleOpCode.Rethrow
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// shl
		/// </summary>
		Shl = SimpleOpCode.Shl
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// shr
		/// </summary>
		Shr = SimpleOpCode.Shr
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// shr.un
		/// </summary>
		Shr_Un = SimpleOpCode.Shr_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.i
		/// </summary>
		Stelem_I = SimpleOpCode.Stelem_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.i1
		/// </summary>
		Stelem_I1 = SimpleOpCode.Stelem_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.i2
		/// </summary>
		Stelem_I2 = SimpleOpCode.Stelem_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.i4
		/// </summary>
		Stelem_I4 = SimpleOpCode.Stelem_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.i8
		/// </summary>
		Stelem_I8 = SimpleOpCode.Stelem_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.r4
		/// </summary>
		Stelem_R4 = SimpleOpCode.Stelem_R4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.r8
		/// </summary>
		Stelem_R8 = SimpleOpCode.Stelem_R8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stelem.ref
		/// </summary>
		Stelem_Ref = SimpleOpCode.Stelem_Ref
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.i
		/// </summary>
		Stind_I = SimpleOpCode.Stind_I
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.i1
		/// </summary>
		Stind_I1 = SimpleOpCode.Stind_I1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.i2
		/// </summary>
		Stind_I2 = SimpleOpCode.Stind_I2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.i4
		/// </summary>
		Stind_I4 = SimpleOpCode.Stind_I4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.i8
		/// </summary>
		Stind_I8 = SimpleOpCode.Stind_I8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.r4
		/// </summary>
		Stind_R4 = SimpleOpCode.Stind_R4
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.r8
		/// </summary>
		Stind_R8 = SimpleOpCode.Stind_R8
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stind.ref
		/// </summary>
		Stind_Ref = SimpleOpCode.Stind_Ref
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stloc.0
		/// </summary>
		Stloc_0 = SimpleOpCode.Stloc_0
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stloc.1
		/// </summary>
		Stloc_1 = SimpleOpCode.Stloc_1
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stloc.2
		/// </summary>
		Stloc_2 = SimpleOpCode.Stloc_2
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// stloc.3
		/// </summary>
		Stloc_3 = SimpleOpCode.Stloc_3
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// sub
		/// </summary>
		Sub = SimpleOpCode.Sub
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// sub.ovf
		/// </summary>
		Sub_Ovf = SimpleOpCode.Sub_Ovf
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// sub.ovf.un
		/// </summary>
		Sub_Ovf_Un = SimpleOpCode.Sub_Ovf_Un
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// tail.
		/// </summary>
		Tailcall = SimpleOpCode.Tailcall
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// throw
		/// </summary>
		Throw = SimpleOpCode.Throw
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// volatile.
		/// </summary>
		Volatile = SimpleOpCode.Volatile
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),

		/// <summary>
		/// xor
		/// </summary>
		Xor = SimpleOpCode.Xor
			| (OpCodeOperand.InlineNone << 8)
			| (EmitMethod.Emit << 13),
		#endregion
		#region InlineR

		/// <summary>
		/// ldc.r8
		/// </summary>
		Ldc_R8 = SimpleOpCode.Ldc_R8
			| (OpCodeOperand.InlineR << 8)
			| (EmitMethod.Emit_Double << 13),
		#endregion
		#region InlineSig

		/// <summary>
		/// calli
		/// </summary>
		Calli = SimpleOpCode.Calli
			| (OpCodeOperand.InlineSig << 8)
			| (EmitMethod.EmitCalli << 13)
			| (EmitMethod.Emit_SignatureHelper << 13),
		#endregion
		#region InlineString

		/// <summary>
		/// ldstr
		/// </summary>
		Ldstr = SimpleOpCode.Ldstr
			| (OpCodeOperand.InlineString << 8)
			| (EmitMethod.Emit_String << 13),
		#endregion
		#region InlineSwitch

		/// <summary>
		/// switch
		/// </summary>
		Switch = SimpleOpCode.Switch
			| (OpCodeOperand.InlineSwitch << 8)
			| (EmitMethod.Emit_LabelArray << 13),
		#endregion
		#region InlineTok

		/// <summary>
		/// ldtoken
		/// </summary>
		Ldtoken = SimpleOpCode.Ldtoken
			| (OpCodeOperand.InlineTok << 8)
			| (EmitMethod.Emit_Type << 13)
			| (EmitMethod.Emit_FieldInfo << 13)
			| (EmitMethod.Emit_MethodInfo << 13),
		#endregion
		#region InlineType

		/// <summary>
		/// box
		/// </summary>
		Box = SimpleOpCode.Box
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// castclass
		/// </summary>
		Castclass = SimpleOpCode.Castclass
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// constrained.
		/// </summary>
		Constrained = SimpleOpCode.Constrained
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// cpobj
		/// </summary>
		Cpobj = SimpleOpCode.Cpobj
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// initobj
		/// </summary>
		Initobj = SimpleOpCode.Initobj
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// isinst
		/// </summary>
		Isinst = SimpleOpCode.Isinst
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// ldelem
		/// </summary>
		Ldelem = SimpleOpCode.Ldelem
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// ldelema
		/// </summary>
		Ldelema = SimpleOpCode.Ldelema
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// ldobj
		/// </summary>
		Ldobj = SimpleOpCode.Ldobj
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// mkrefany
		/// </summary>
		Mkrefany = SimpleOpCode.Mkrefany
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// newarr
		/// </summary>
		Newarr = SimpleOpCode.Newarr
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// refanyval
		/// </summary>
		Refanyval = SimpleOpCode.Refanyval
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// sizeof
		/// </summary>
		Sizeof = SimpleOpCode.Sizeof
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// stelem
		/// </summary>
		Stelem = SimpleOpCode.Stelem
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// stobj
		/// </summary>
		Stobj = SimpleOpCode.Stobj
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// unbox
		/// </summary>
		Unbox = SimpleOpCode.Unbox
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),

		/// <summary>
		/// unbox.any
		/// </summary>
		Unbox_Any = SimpleOpCode.Unbox_Any
			| (OpCodeOperand.InlineType << 8)
			| (EmitMethod.Emit_Type << 13),
		#endregion
		#region InlineVar

		/// <summary>
		/// ldarg
		/// </summary>
		Ldarg = SimpleOpCode.Ldarg
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13),

		/// <summary>
		/// ldarga
		/// </summary>
		Ldarga = SimpleOpCode.Ldarga
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13),

		/// <summary>
		/// ldloc
		/// </summary>
		Ldloc = SimpleOpCode.Ldloc
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),

		/// <summary>
		/// ldloca
		/// </summary>
		Ldloca = SimpleOpCode.Ldloca
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),

		/// <summary>
		/// starg
		/// </summary>
		Starg = SimpleOpCode.Starg
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13),

		/// <summary>
		/// stloc
		/// </summary>
		Stloc = SimpleOpCode.Stloc
			| (OpCodeOperand.InlineVar << 8)
			| (EmitMethod.Emit_Int16 << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),
		#endregion
		#region ShortInlineBrTarget

		/// <summary>
		/// beq.s
		/// </summary>
		Beq_S = SimpleOpCode.Beq_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bge.s
		/// </summary>
		Bge_S = SimpleOpCode.Bge_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bge.un.s
		/// </summary>
		Bge_Un_S = SimpleOpCode.Bge_Un_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bgt.s
		/// </summary>
		Bgt_S = SimpleOpCode.Bgt_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bgt.un.s
		/// </summary>
		Bgt_Un_S = SimpleOpCode.Bgt_Un_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// ble.s
		/// </summary>
		Ble_S = SimpleOpCode.Ble_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// ble.un.s
		/// </summary>
		Ble_Un_S = SimpleOpCode.Ble_Un_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// blt.s
		/// </summary>
		Blt_S = SimpleOpCode.Blt_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// blt.un.s
		/// </summary>
		Blt_Un_S = SimpleOpCode.Blt_Un_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// bne.un.s
		/// </summary>
		Bne_Un_S = SimpleOpCode.Bne_Un_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// br.s
		/// </summary>
		Br_S = SimpleOpCode.Br_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// brfalse.s
		/// </summary>
		Brfalse_S = SimpleOpCode.Brfalse_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// brtrue.s
		/// </summary>
		Brtrue_S = SimpleOpCode.Brtrue_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),

		/// <summary>
		/// leave.s
		/// </summary>
		Leave_S = SimpleOpCode.Leave_S
			| (OpCodeOperand.ShortInlineBrTarget << 8)
			| (EmitMethod.Emit_Label << 13),
		#endregion
		#region ShortInlineI

		/// <summary>
		/// ldc.i4.s
		/// </summary>
		Ldc_I4_S = SimpleOpCode.Ldc_I4_S
			| (OpCodeOperand.ShortInlineI << 8)
			| (EmitMethod.Emit_SByte << 13),

		/// <summary>
		/// unaligned.
		/// </summary>
		Unaligned = SimpleOpCode.Unaligned
			| (OpCodeOperand.ShortInlineI << 8)
			| (EmitMethod.Emit_SByte << 13),
		#endregion
		#region ShortInlineR

		/// <summary>
		/// ldc.r4
		/// </summary>
		Ldc_R4 = SimpleOpCode.Ldc_R4
			| (OpCodeOperand.ShortInlineR << 8)
			| (EmitMethod.Emit_Single << 13),
		#endregion
		#region ShortInlineVar

		/// <summary>
		/// ldarg.s
		/// </summary>
		Ldarg_S = SimpleOpCode.Ldarg_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13),

		/// <summary>
		/// ldarga.s
		/// </summary>
		Ldarga_S = SimpleOpCode.Ldarga_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13),

		/// <summary>
		/// ldloc.s
		/// </summary>
		Ldloc_S = SimpleOpCode.Ldloc_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),

		/// <summary>
		/// ldloca.s
		/// </summary>
		Ldloca_S = SimpleOpCode.Ldloca_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),

		/// <summary>
		/// starg.s
		/// </summary>
		Starg_S = SimpleOpCode.Starg_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13),

		/// <summary>
		/// stloc.s
		/// </summary>
		Stloc_S = SimpleOpCode.Stloc_S
			| (OpCodeOperand.ShortInlineVar << 8)
			| (EmitMethod.Emit_Byte << 13)
			| (EmitMethod.Emit_LocalBuilder << 13),
		#endregion
	}

	static partial class EmitMatrix
	{
		[GeneratedCode("EmitMatrix", "1.0")]
		public static SimpleOpCode GetSimpleOpCode(this OpCode opCode) => (SimpleOpCode)((int)opCode & 0xFF);
		[GeneratedCode("EmitMatrix", "1.0")]
		public static OpCodeOperand GetOperand(this OpCode opCode) => (OpCodeOperand)((int)opCode >> 8 & 0x1F);
		[GeneratedCode("EmitMatrix", "1.0")]
		public static EmitMethod GetSupportedMethods(this OpCode opCode) => (EmitMethod)((int)opCode >> 13 & 0x7FFFF);

		[GeneratedCode("EmitMatrix", "1.0")]
		public static OpCode GetOpCode(IFieldSymbol field)
		{
			if (field.ContainingType.IsMatch("System.Reflection.Emit.OpCodes"))
			{
				return GetOpCode(field.Name);
			}

			return OpCode.Invalid;
		}

		[GeneratedCode("EmitMatrix", "1.0")]
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
