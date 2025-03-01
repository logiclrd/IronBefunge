﻿using IronBefunge.InstructionHandlers;
using NUnit.Framework;
using System.Collections.Immutable;

namespace IronBefunge.Tests.InstructionHandlers;

public sealed class MathInstructionHandlerTests
	: InstructionHandlerTests
{
	internal override ImmutableArray<char> GetExpectedHandledInstructions() =>
		ImmutableArray.Create(MathInstructionHandler.AddInstruction,
			MathInstructionHandler.DivideInstruction, MathInstructionHandler.ModInstruction,
			MathInstructionHandler.MultiplyInstruction, MathInstructionHandler.SubtractInstruction);

	internal override Type GetHandlerType() => typeof(MathInstructionHandler);

	[Test]
	public static void HandleAdd()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.AddInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			context.Values.Push(7);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount - 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(10), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleAddWithOnlyOneValueOnTheStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.AddInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(3), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleAddWithEmptyStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.AddInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount + 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleDivide()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.DivideInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(7);
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount - 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(2), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleDivideWithOnlyOneValueOnTheStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.DivideInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleDivideWithEmptyStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.DivideInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount + 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleMod()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.ModInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(7);
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount - 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(1), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleModWithOnlyOneValueOnTheStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.ModInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleModWithEmptyStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.ModInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount + 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleMultiply()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.MultiplyInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			context.Values.Push(7);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount - 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(21), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleMultiplyWithOnlyOneValueOnTheStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.MultiplyInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleMultiplyWithEmptyStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.MultiplyInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount + 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleSubtract()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.SubtractInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			context.Values.Push(7);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount - 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(-4), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleSubtractWithOnlyOneValueOnTheStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.SubtractInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			context.Values.Push(3);
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(3), nameof(context.Values.Peek));
				 });
		});
	}

	[Test]
	public static void HandleSubtractWithEmptyStack()
	{
		var cells = new List<Cell>() { new Cell(
				new Point(0, 0), MathInstructionHandler.SubtractInstruction) };
		var stackCount = 0;

		InstructionHandlerTests.Run(new MathInstructionHandler(), cells, (context) =>
		{
			stackCount = context.Values.Count;
		}, (context, result) =>
		{
			Assert.Multiple(() =>
				 {
					 Assert.That(context.Values.Count, Is.EqualTo(stackCount + 1), nameof(context.Values.Count));
					 Assert.That(context.Values.Peek(), Is.EqualTo(0), nameof(context.Values.Peek));
				 });
		});
	}
}