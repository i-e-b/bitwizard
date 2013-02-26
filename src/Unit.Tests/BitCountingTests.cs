using System;
using BitWizard;
using NUnit.Framework;

namespace Unit.Tests
{
	[TestFixture]
	public class BitCountingTests_Int
	{
		int[] cases;
		int[] count;
		const int SampleCount = 100;

		[SetUp]
		public void setup()
		{
			var rnd = new Random();
			cases = new int[SampleCount];
			count = new int[SampleCount];
			cases[0] = 0;
			count[0] = 0;
			cases[1] = -1;
			count[1] = 32;
			for (int i = 2; i < SampleCount; i++)
			{
				cases[i] = rnd.Next();
				count[i] = SimpleCount(cases[i]);
			}
		}

		int SimpleCount(int src)
		{
			var c = 0;
			for (int i = 0; i < 64; i++)
			{
				if (src % 2 == 1) c++;
				src >>= 1;
			}
			return c;
		}

		[Test]
		public void can_count_bits_in_an_int_with_efficient_method()
		{
			for (int i = 0; i < SampleCount; i++)
			{
				Console.WriteLine(cases[i].ToString("X") + " -> " + count[i]);
				Assert.That(BitCounter.Count(cases[i]), Is.EqualTo(count[i]));
			}
		}
		
		[Test]
		public void can_count_bits_in_a_long_with_efficient_method()
		{
			for (int i = 0; i < SampleCount; i++)
			{
				Console.WriteLine(cases[i].ToString("X") + " -> " + count[i]);
				Assert.That(BitCounter.Count((ulong)cases[i]), Is.EqualTo(count[i]));
			}
		}
	}
}