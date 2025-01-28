using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class Dictionary : IWordSource
    {
        private const string _filePath = "Dictionary.json";
        private static JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
        public Dictionary() {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
                List<string> dataList = new List<string>
{
    "apple",
    "banana",
    "basket",
    "beach",
    "board",
    "bread",
    "breeze",
    "cactus",
    "candle",
    "carrot",
    "cheese",
    "cloud",
    "couch",
    "crisp",
    "daisy",
    "delta",
    "donut",
    "dream",
    "eagle",
    "earth",
    "elbow",
    "fancy",
    "feast",
    "fridge",
    "frozen",
    "grape",
    "guard",
    "habit",
    "honey",
    "island",
    "juice",
    "laptop",
    "lumber",
    "mango",
    "mild",
    "moment",
    "muffin",
    "night",
    "onion",
    "pencil",
    "pizza",
    "plant",
    "puppy",
    "river",
    "rusty",
    "scarf",
    "toast",
    "trail",
    "tulip",
    "violin"
};
                File.WriteAllText(_filePath, JsonSerializer.Serialize(dataList, _options));
            }
        }
        public string SourceWord(string name, string name2)
        {
            System.Console.WriteLine($"{name} has been assigned a generated word, {name2} it is your turn to play! Press any key to continue...");
            System.Console.ReadLine();
            string fileContent = File.ReadAllText(_filePath);
            List<string> words = JsonSerializer.Deserialize<List<string>>(fileContent) ?? new List<string>();
            Random rng = new Random();
            return words[rng.Next(0, words.Count + 1)];
        }
    }
}
