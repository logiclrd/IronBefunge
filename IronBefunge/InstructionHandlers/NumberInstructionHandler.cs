﻿using System.Collections.Immutable;
using System.Globalization;

namespace IronBefunge.InstructionHandlers
{
	internal sealed class NumberInstructionHandler
		: InstructionHandler
	{
		internal const char ZeroInstruction = '0';
		internal const char OneInstruction = '1';
		internal const char TwoInstruction = '2';
		internal const char ThreeInstruction = '3';
		internal const char FourInstruction = '4';
		internal const char FiveInstruction = '5';
		internal const char SixInstruction = '6';
		internal const char SevenInstruction = '7';
		internal const char EightInstruction = '8';
		internal const char NineInstruction = '9';

		internal override ImmutableArray<char> GetInstructions() =>
			ImmutableArray.Create(NumberInstructionHandler.ZeroInstruction, 
				NumberInstructionHandler.OneInstruction, NumberInstructionHandler.TwoInstruction,
				NumberInstructionHandler.ThreeInstruction, NumberInstructionHandler.FourInstruction,
				NumberInstructionHandler.FiveInstruction, NumberInstructionHandler.SixInstruction,
				NumberInstructionHandler.SevenInstruction, NumberInstructionHandler.EightInstruction,
				NumberInstructionHandler.NineInstruction);

		internal override void OnHandle(ExecutionContext context)
		{
			if (this.Instructions.Contains(context.Current.Value))
			{
				context.Values.Push(int.Parse(
					new string(context.Current.Value, 1), CultureInfo.CurrentCulture));
			}
		}
	}
}