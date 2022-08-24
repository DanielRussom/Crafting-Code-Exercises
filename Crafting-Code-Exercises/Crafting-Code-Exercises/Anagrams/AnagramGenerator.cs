namespace Crafting_Code_Exercises.Anagrams
{
    public class AnagramGenerator
    {
        public List<string> Generate(string input)
        {
            if (input.Length == 1) return new List<string> { input };

            if (input.Length == 2)
            {
                var reversedString = new string(input.Reverse().ToArray());
                return new List<string> { input, reversedString };
            }

            var anagrams = new List<string>();

            for (var index = 0; index < input.Length; index++)
            {
                var baseCharacter = input.Substring(index, 1);

                var prefix = input.Substring(0, index);
                var suffix = input.Substring(index + 1);
                var newInput = prefix + suffix;

                var tailAnagrams = Generate(newInput);

                foreach (var tailAnagram in tailAnagrams)
                {
                    var anagram = baseCharacter + tailAnagram;
                    anagrams.Add(anagram);
                }
            }

            return anagrams;
        }
    }
}