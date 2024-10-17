using Newtonsoft.Json;

namespace EnglishMalayalamDictionary
{
    class WordsRepo
    {
        public string RegionalLanguageWord { get; set; }
        public string EnglishEquivalentWord { get; set; }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonDataPath = "D:\\ProjectsLab\\DotNet\\DictionaryApp\\EnglishMalayalamDictionary\\EnglishMalayalamDictionary\\MyWords.json";
            List<WordsRepo> wordsList = LoadWordsFromJSONDataBank(jsonDataPath);
            Console.WriteLine("Hello! Happy to help!!!");
            while (true)
            {
                Console.Write("Please enter a word: ");
                string inputWord = Console.ReadLine().Trim().ToLower();
                WordsRepo word = wordsList.Find(w => w.RegionalLanguageWord.ToLower()==inputWord);
                if (word != null)
                {
                    Console.WriteLine($"The English word for “{word.RegionalLanguageWord}” is {word.EnglishEquivalentWord.ToUpper()}");
                }
                else
                {

                      Console.WriteLine($"Sorry, “{inputWord}” is not in the dictionary. Please try with another word");
                    
                }
                Console.Write("Are you looking for more words? [y/n] ");
                string userWantsToContinue = Console.ReadLine().Trim().ToLower();
                if (userWantsToContinue != "y")
                {
                    break;
                }
            }
        }

        public static List<WordsRepo> LoadWordsFromJSONDataBank(String jsonFilePath)
        {
            try
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<List<WordsRepo>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading JSON file: {ex.Message}");
                return new List<WordsRepo>();
            }
        }
    }
}
