using System;
using BitWizard;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class BitReaderTests
    {
	    BitReader _subject;
	    byte[] _data;

	    [SetUp]
        public void setup()
        {
            _data = new byte[] { 0x82, 0xFF, 0xFF };
            _subject = new BitReader(_data);
        }

        [Test]
        public void can_read_a_sequence_of_bits_as_boolean_values ()
        {
            Assert.That(_subject.GetFlag(), Is.True);
	        for (int i = 0; i < 5; i++)
	        {
                Assert.That(_subject.GetFlag(), Is.False);
	        }
            Assert.That(_subject.GetFlag(), Is.True);
            Assert.That(_subject.GetFlag(), Is.False);
        }

        [Test]
        public void can_read_a_byte_aligned_UInt16 ()
        {
            _subject.SkipBytes(1);
            var result = (UInt16)_subject.GetInteger(16);
            Assert.That(result, Is.EqualTo(0xFFFF));
        }

        [Test]
        public void can_read_a_byte_unaligned_UInt16 ()
        {
            _subject.SkipBits(7);
            var result = (UInt16)_subject.GetInteger(16);
            Assert.That(result, Is.EqualTo(0x7FFF));
        }
    }
}
