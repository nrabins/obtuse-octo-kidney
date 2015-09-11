using NUnit.Framework;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{
    [TestFixture]
    class MnemonicSpellCheckerIBeforeETests
    {
        private ISpellChecker SpellChecker;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            SpellChecker = new MnemonicSpellCheckerIBeforeE();
        }

        [Test]
        public void Check_Word_That_Contains_I_Before_E_Is_Spelled_Correctly()
        {
            Assert.True(SpellChecker.Check("believe"));
            Assert.True(SpellChecker.Check("fierce"));
            Assert.True(SpellChecker.Check("collie"));
            Assert.True(SpellChecker.Check("die"));
            Assert.True(SpellChecker.Check("friend"));
            Assert.True(SpellChecker.Check("deceive"));
            Assert.True(SpellChecker.Check("ceiling"));
            Assert.True(SpellChecker.Check("receipt"));
        }

        [Test]
        public void Check_Word_That_Contains_I_Before_E_Is_Spelled_Incorrectly()
        {
            Assert.False(SpellChecker.Check("heir"));
            Assert.False(SpellChecker.Check("protein"));
            Assert.False(SpellChecker.Check("science"));
            Assert.False(SpellChecker.Check("seeing"));
            Assert.False(SpellChecker.Check("their"));
            Assert.False(SpellChecker.Check("veil"));
        }
    }
}
