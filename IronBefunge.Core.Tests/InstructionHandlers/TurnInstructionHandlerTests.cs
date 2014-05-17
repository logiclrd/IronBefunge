﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IronBefunge.Core.InstructionHandlers;
using Xunit;

namespace IronBefunge.Core.Tests.InstructionHandlers
{
	public sealed class TurnInstructionHandlerTests
		: InstructionHandlerTests
	{
		internal override ReadOnlyCollection<char> GetExpectedHandledInstructions()
		{
			return new List<char>() { TurnInstructionHandler.LeftRightInstruction,
				TurnInstructionHandler.UpDownInstruction }.AsReadOnly();
		}

		internal override Type GetHandlerType()
		{
			return typeof(TurnInstructionHandler);
		}

		[Fact]
		public static void HandleGoingDown()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.UpDownInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					context.Values.Push(0);
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount - 1, context.Values.Count);
					Assert.Equal(Direction.Down, context.Direction);
				});
		}

		[Fact]
		public static void HandleGoingDownOrUpWithEmptyStack()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.UpDownInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount, context.Values.Count);
					Assert.Equal(Direction.Down, context.Direction);
				});
		}

		[Fact]
		public static void HandleGoingLeft()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.LeftRightInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					context.Values.Push(3);
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount - 1, context.Values.Count);
					Assert.Equal(Direction.Left, context.Direction);
				});
		}

		[Fact]
		public static void HandleGoingLeftOrRightWithEmptyStack()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.LeftRightInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount, context.Values.Count);
					Assert.Equal(Direction.Right, context.Direction);
				});
		}

		[Fact]
		public static void HandleGoingRight()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.LeftRightInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					context.Values.Push(0);
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount - 1, context.Values.Count);
					Assert.Equal(Direction.Right, context.Direction);
				});
		}

		[Fact]
		public static void HandleGoingUp()
		{
			var cells = new List<Cell>() { new Cell(
				new Point(0, 0), TurnInstructionHandler.UpDownInstruction) };

			var stackCount = 0;

			InstructionHandlerTests.Run(new TurnInstructionHandler(), cells, (context) =>
				{
					context.Values.Push(3);
					stackCount = context.Values.Count;
				}, (context, result) =>
				{
					Assert.Equal(stackCount - 1, context.Values.Count);
					Assert.Equal(Direction.Up, context.Direction);
				});
		}
	}
}
