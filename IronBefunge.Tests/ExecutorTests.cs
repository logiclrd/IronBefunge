﻿using NUnit.Framework;
using System;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;

namespace IronBefunge.Tests
{
	public static class ExecutorTests
	{
		[Test]
		public static void CreateWithNullRandomizer()
		{
			using (var reader = new StringReader(string.Empty))
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					Assert.That(() => new Executor(ImmutableArray.Create<Cell>(), reader, writer, null),
						Throws.TypeOf<ArgumentNullException>());
				}
			}
		}

		[Test]
		public static void CreateWithNullReader()
		{
			using (var writer = new StringWriter(CultureInfo.CurrentCulture))
			{
				Assert.That(() => new Executor(ImmutableArray.Create<Cell>(), null, writer),
					Throws.TypeOf<ArgumentNullException>());
			}
		}

		[Test]
		public static void CreateWithNullWriter()
		{
			using (var reader = new StringReader(string.Empty))
			{
				Assert.That(() => new Executor(ImmutableArray.Create<Cell>(), reader, null),
					Throws.TypeOf<ArgumentNullException>());
			}
		}
	}
}