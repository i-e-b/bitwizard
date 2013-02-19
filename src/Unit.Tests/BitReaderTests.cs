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
            _data = new byte[] { 0x81 };
            _subject = new BitReader(_data);
        }

        [Test]
        public void can_read_a_sequence_of_bits_as_boolean_values ()
        {
            Assert.That(_subject.GetFlag(), Is.True);
	        for (int i = 0; i < 6; i++)
	        {
                Assert.That(_subject.GetFlag(), Is.False);
	        }
            Assert.That(_subject.GetFlag(), Is.True);
        }
    }
}
