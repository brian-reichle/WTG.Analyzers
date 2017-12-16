namespace WTG.Analyzers
{
	static class EmitFixUtils
	{
		public static SuggestedFix SuggestAutoFix(OpCode opcode, EmitMethod actualMethod)
		{
			var operandType = opcode.GetOperand();

			switch (operandType)
			{
				case OpCodeOperand.InlineNone:
					return SuggestedFix.DeleteArgument;

				case OpCodeOperand.InlineI:
				case OpCodeOperand.InlineI8:
				case OpCodeOperand.InlineR:
				case OpCodeOperand.InlineVar:
				case OpCodeOperand.ShortInlineI:
				case OpCodeOperand.ShortInlineR:
				case OpCodeOperand.ShortInlineVar:
					{
						const EmitMethod Mask =
							EmitMethod.Emit_Byte
							| EmitMethod.Emit_SByte
							| EmitMethod.Emit_Int16
							| EmitMethod.Emit_Int32
							| EmitMethod.Emit_Int64
							| EmitMethod.Emit_Single
							| EmitMethod.Emit_Double;

						if ((Mask & actualMethod) != 0)
						{
							return SuggestedFix.ConvertArgument;
						}
					}
					break;
			}

			return SuggestedFix.NoAutoFix;
		}
	}
}
