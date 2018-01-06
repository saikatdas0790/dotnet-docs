using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilityLibraries
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            // Tests that we expect to return true.
            string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };
            foreach (var word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsTrue(result, string.Format($"Expected for '{word}': true; Actual: {result}"));
            }
        }

        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            //Tests that we expect to return false.
            string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " " };

            foreach (var word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsFalse(result, string.Format($"Expected for '{word}': false; Actual: {result}"));
            }
        }

        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string[] words = { string.Empty, null };
            foreach (var word in words)
            {
                bool result = StringLibrary.StartsWithUpper(word);
                Assert.IsFalse(result, string.Format($"Expected for '{word}': false; Actual: {result}"));
            }
        }
    }
}
