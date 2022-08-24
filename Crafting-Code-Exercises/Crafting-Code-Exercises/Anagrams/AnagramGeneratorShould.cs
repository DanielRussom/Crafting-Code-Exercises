using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crafting_Code_Exercises.Anagrams
{
    [TestClass]
    public class AnagramGeneratorShould
    {
        [TestMethod]
        [DataRow("A", "A", DisplayName = "Get all anagrams of letter A")]
        [DataRow("B", "B", DisplayName = "Get all anagrams of letter B")]
        [DataRow("C", "C", DisplayName = "Get all anagrams of letter C")]
        [DataRow("AB", "AB", "BA", DisplayName = "Get all anagrams of letters AB")]
        [DataRow("BA", "AB", "BA", DisplayName = "Get all anagrams of letters BA")]
        [DataRow("CD", "CD", "DC", DisplayName = "Get all anagrams of letters CD")]
        [DataRow("EF", "EF", "FE", DisplayName = "Get all anagrams of letters EF")]
        [DataRow("ABC", "ABC", "ACB", "BCA", "BAC",  "CAB", "CBA", DisplayName = "Get all anagrams of letters ABC")]
        [DataRow("ACB", "ABC", "ACB", "BCA", "BAC",  "CAB", "CBA", DisplayName = "Get all anagrams of letters ACB")]
        [DataRow("BCA", "ABC", "ACB", "BCA", "BAC",  "CAB", "CBA", DisplayName = "Get all anagrams of letters BCA")]
        [DataRow("DEF", "DEF", "DFE", "EFD", "EDF",  "FDE", "FED", DisplayName = "Get all anagrams of letters DEF")]
        [DataRow("biro", "biro", "bior", "brio", "broi", "boir", "bori", "ibro", "ibor", "irbo", "irob", "iobr", "iorb", "rbio", "rboi", "ribo", "riob", "roib", "robi", "obir", "obri", "oibr", "oirb", "orbi", "orib", DisplayName = "Get all anagrams of letters biro")]
        public void Get_all_anagrams_of_letters(string input, params string[] expectedResult)
        {
            var generator = new AnagramGenerator();

            var result = generator.Generate(input);

            CollectionAssert.AreEquivalent(expectedResult.ToList(), result, string.Join(", ", result));
        }
    }
}
