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
        static void getUserInput(Dictionary<char, string> translator)
        {
            var nextCode = true;
            while (nextCode){
                string input;
                Console.WriteLine("Please use an phrase!");
                input = Console.ReadLine();
                input = input.ToUpper();
                Console.WriteLine("Your output is: " + translate(translator, input));
                Console.WriteLine("Do you want to convert another word? (yes) or (no)");
                var command = Console.ReadLine();
                if (command == "no"){
                    nextCode = false;
                } ;
                
              }
                Console.WriteLine("Press enter to end.");
                Console.ReadLine();
        
        }
       
          static string translate(Dictionary<char, string> morseCode, string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char character in input)
            {
                if (morseCode.ContainsKey(character))
                {
                    stringBuilder.Append(morseCode[character] + " ");
                }
                else if (character == ' ')
                {
                    stringBuilder.Append("/ ");
                }
                else
                {
                    stringBuilder.Append(character + " ");
                }
            }
            return stringBuilder.ToString();
        }

        static void Main(string[] args)
        {
            var morseCode = new Dictionary<char, String>();
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
                    morseCode.Add(Convert.ToChar(key), value);
                    foreach (var phrase in morseCode)
                    {
                        Console.WriteLine($"key: {phrase.Key} value : {phrase.Value}");
                    }
                    Console.WriteLine(morseCode.Count);

                }

            }

            {


                getUserInput(morseCode);
            
            }
        }
    }
}

