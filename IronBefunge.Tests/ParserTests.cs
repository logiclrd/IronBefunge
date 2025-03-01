﻿using NUnit.Framework;

namespace IronBefunge.Tests;

public static class ParserTests
{
	[Test]
	public static void GetCellsWithMultipleLinesWithNoValues()
	{
		var lines = new string[] { "    ", string.Empty, "                   " };
		var cells = new Parser(lines).Parse();
		Assert.That(cells, Is.Empty);
	}

	[Test]
	public static void GetCellsWithMultipleLinesWithValues()
	{
		var lines = new string[] { "   <   ^#:  9              ", " ^ < ", " 3 5 :" };
		var cells = new Parser(lines).Parse();

		Assert.Multiple(() =>
		{
			Assert.That(cells.Length, Is.EqualTo(10), nameof(cells.Length));
			Assert.That(cells, Does.Contain(new Cell(new(3, 0), '<')), "<");
			Assert.That(cells, Does.Contain(new Cell(new(7, 0), '^')), "^");
			Assert.That(cells, Does.Contain(new Cell(new(8, 0), '#')), "#");
			Assert.That(cells, Does.Contain(new Cell(new(9, 0), ':')), ":");
			Assert.That(cells, Does.Contain(new Cell(new(12, 0), '9')), "9");
			Assert.That(cells, Does.Contain(new Cell(new(1, 1), '^')), "^");
			Assert.That(cells, Does.Contain(new Cell(new(3, 1), '<')), "<");
			Assert.That(cells, Does.Contain(new Cell(new(1, 2), '3')), "3");
			Assert.That(cells, Does.Contain(new Cell(new(3, 2), '5')), "5");
			Assert.That(cells, Does.Contain(new Cell(new(5, 2), ':')), ":");
		});
	}

	[Test]
	public static void GetCellsWithSingleLineWithNoValues()
	{
		var lines = new string[] { "    " };
		var cells = new Parser(lines).Parse();
		Assert.That(cells, Is.Empty);
	}

	[Test]
	public static void GetCellsWithSingleLineWithValues()
	{
		var lines = new string[] { "   <   ^#:  9              " };
		var cells = new Parser(lines).Parse();

		Assert.Multiple(() =>
		{
			Assert.That(cells.Length, Is.EqualTo(5));
			Assert.That(cells, Does.Contain(new Cell(new(3, 0), '<')), "<");
			Assert.That(cells, Does.Contain(new Cell(new(7, 0), '^')), "^");
			Assert.That(cells, Does.Contain(new Cell(new(8, 0), '#')), "#");
			Assert.That(cells, Does.Contain(new Cell(new(9, 0), ':')), ":");
			Assert.That(cells, Does.Contain(new Cell(new(12, 0), '9')), "9");
		});
	}

	[Test]
	public static void ParseWithNullArray()
	{
		var cells = new Parser(null).Parse();
		Assert.That(cells, Is.Empty);
	}

	[Test]
	public static void ParseWithNullLine()
	{
		var cells = new Parser(new string?[] { " ^ < ", null, " 3 5 :" }).Parse();
		Assert.That(cells.Length, Is.EqualTo(5));
	}
}