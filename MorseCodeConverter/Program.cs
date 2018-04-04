using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var morseCode = new Dictionary<String, String>();
            const string MORSE_CODE_PATH = "../../morse.csv";
            using (var reader = new StreamReader(MORSE_CODE_PATH))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    var splitLine = line.Split(',');
                    var key = splitLine[0];
                    var value = splitLine[1];
                    Console.WriteLine(splitLine);
                    Console.WriteLine($"The key/value pair is {key}/{value}");
                    morseCode.Add(key, value);
                }
                Console.WriteLine(morseCode.Count);
            }
            Console.ReadLine();
        }
    }
}
