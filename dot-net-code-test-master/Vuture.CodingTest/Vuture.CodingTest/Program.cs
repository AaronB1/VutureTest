using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Vuture.CodingTest
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        //Task 1
        public int countLetters(string inputtedString, char inputtedChar) 
        {
            int count = 0;

            foreach (char c in inputtedString) 
            {
                if(c == inputtedChar)
                {
                    count++;
                }
            }

            return count;
        }

        //Task 2
        public bool palindromeCheck(string inputtedString)
        {
            int count = 0;
            string simpleString = Regex.Replace(inputtedString.ToLower(), "[^a-zA-Z0-9]", "");

            for (int i = 0; i < simpleString.Length; i++)
            {
                if (simpleString[i] == simpleString[simpleString.Length - (1 + i)])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine("The string: '" + inputtedString + "' isn't a palindrome");
                    return false;
                }
            }

            if (count == simpleString.Length)
            {
                Console.WriteLine("The string: '" + inputtedString + "' is a palindrome");
                return true;
            }
            else
            {
                Console.WriteLine("The string: '" + inputtedString + "' isn't a palindrome");
                return false;
            }
        }

        //Task 3A
        //Should this be comparing for the exact censored words or checking if they are contained in words?
        public int countNumCensoredWords(string[] censoredWords, string inputtedString)
        {
            int count = 0;
            int totalCount = 0;
            int wordTracker = 0;
            int[] numCensoredWords = new int[censoredWords.Length];

            inputtedString = Regex.Replace(inputtedString.ToLower(), "[^a-zA-Z\x20]", "");
            string[] inputtedWords = inputtedString.Split(' ');

            foreach (string word1 in censoredWords)
            {
                foreach (string word2 in inputtedWords)
                {
                    if (word2.Contains(word1))
                    {
                        count++;
                    }
                }
                numCensoredWords[wordTracker] = count;
                Console.WriteLine(word1 + ": " + numCensoredWords[wordTracker]);
                totalCount = totalCount + count;
                count = 0;
                wordTracker++;
            }
            Console.WriteLine("total: " + totalCount);

            return totalCount;
        }

        //Task 3B
        public string censorChosenWords(string[] censoredWords, string inputtedString)
        {
            string[] inputtedWords = inputtedString.Split(' ');

            foreach (string censoredWord in censoredWords)
            {
                string hiddenWord = censoredWord;
                char[] charArray = new char[censoredWord.Length];

                charArray[0] = hiddenWord[0];
                charArray[hiddenWord.Length - 1] = hiddenWord[hiddenWord.Length - 1];

                for (int i = 1; i < hiddenWord.Length - 1; i++)
                {
                    charArray[i] = '&';
                }

                hiddenWord = new string(charArray);

                for (int i = 0; i < inputtedWords.Length; i++)
                {
                    if (Regex.Replace(inputtedWords[i].ToLower(), "[^a-zA-Z']", "") == censoredWord.ToLower())
                    {
                        char[] inputtedWordCharArray = inputtedWords[i].ToCharArray();
                        for (int j = 1; j < censoredWord.Length - 1; j++)
                        {
                            inputtedWordCharArray[j] = '$';
                        }
                        inputtedWords[i] = new string(inputtedWordCharArray);
                    }
                }
            }

            inputtedString = string.Join(" ", inputtedWords);
            Console.WriteLine(inputtedString);

            return inputtedString;
        }

        //Task 3C
        //divides up the inputted string into the smaller string cutting it at every ' '
        //checks if any of these smaller strings are palindromes when non-alphabetical characters are removed
        public string censorPalindromes(string inputtedString)
        {
            Program p = new Program();

            string[] inputtedWords = inputtedString.Split(' ');

            for (int j = 0; j < inputtedWords.Length; j++)
            {
                if (p.palindromeCheck(Regex.Replace(inputtedWords[j].ToLower(), "[^a-zA-Z']", "")) == true)
                {
                    string simplifiedWord = Regex.Replace(inputtedWords[j].ToLower(), "[^a-zA-Z']", "");
                    char[] charArray = new char[inputtedWords[j].Length];

                    charArray[0] = inputtedWords[j][0];
                    charArray[simplifiedWord.Length - 1] = inputtedWords[j][simplifiedWord.Length - 1];
                    charArray[inputtedWords[j].Length - 1] = inputtedWords[j][simplifiedWord.Length - 1];

                    for (int i = 1; i < simplifiedWord.Length - 1; i++)
                    {
                        charArray[i] = '$';
                    }

                    inputtedWords[j] = new string(charArray);
                }
            }

            inputtedString = string.Join(" ", inputtedWords);
            Console.WriteLine(inputtedString);

            return inputtedString;
        }

        //Task 3D
        //via the terminal
        //Via a UI
        //using a .txt file

    }
}
