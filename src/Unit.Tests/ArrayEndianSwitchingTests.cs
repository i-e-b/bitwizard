using System.Runtime.InteropServices;
using BitWizard;
using NUnit.Framework;

namespace Unit.Tests
{
	[TestFixture]
	public class ArrayEndianSwitchingTests
	{
		readonly short[] _originalShorts = new short[4];
		readonly short[] _sourceShorts = new short[4];
		readonly short[] _swappedShorts = new short[4];

		readonly int[] _originalInts = new int[2];
		readonly int[] _sourceInts = new int[2];
		readonly int[] _swappedInts = new int[2];

		[SetUp]
		public void setup()
		{
			var source =
				new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
			var swapedInShorts =
				new byte[] { 0x02, 0x01, 0x04, 0x03, 0x06, 0x05, 0x08, 0x07 };
			var swapedInInts =
				new byte[] { 0x04, 0x03, 0x02, 0x01, 0x08, 0x07, 0x06, 0x05 };

			BytesToShorts(source, _sourceShorts);
			BytesToShorts(source, _originalShorts);
			BytesToShorts(swapedInShorts, _swappedShorts);

			BytesToInts(source, _sourceInts);
			BytesToInts(source, _originalInts);
			BytesToInts(swapedInInts, _swappedInts);
		}

		void BytesToShorts(byte[] source, short[] target)
		{
			var pin = GCHandle.Alloc(source, GCHandleType.Pinned);
			Marshal.Copy(pin.AddrOfPinnedObject(), target, 0, source.Length / 2);
			pin.Free();
		}
		void BytesToInts(byte[] source, int[] target)
		{
			var pin = GCHandle.Alloc(source, GCHandleType.Pinned);
			Marshal.Copy(pin.AddrOfPinnedObject(), target, 0, source.Length / 4);
			pin.Free();
		}

		[Test]
		public void can_reverse_byte_orders_in_16_bit_strides()
		{
			ArrayByteOrder.SwapOrder(_sourceShorts);
			Assert.That(_sourceShorts, Is.EquivalentTo(_swappedShorts));
			ArrayByteOrder.SwapOrder(_sourceShorts);
			Assert.That(_sourceShorts, Is.EquivalentTo(_originalShorts));
		}
		

		[Test]
		public void can_reverse_byte_orders_in_32_bit_strides()
		{
			ArrayByteOrder.SwapOrder(_sourceInts);
			Assert.That(_sourceInts, Is.EquivalentTo(_swappedInts));
			ArrayByteOrder.SwapOrder(_sourceInts);
			Assert.That(_sourceInts, Is.EquivalentTo(_originalInts));
		}
	}
}