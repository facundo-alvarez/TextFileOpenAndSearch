using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextFileOpenAndSearch
{
    class Program
    {
        static int Main(string[] args)
        {
            bool desiredKey1, desiredKey2 = false;
            string desiredText, query;
            var textWords = new List<string>();
            var queryResult = new List<string>();
            ConsoleKeyInfo keyInfo1, keyInfo2;

            do
            {
                Console.WriteLine("Choose a text file:\n a) Text 1\n b) Text 2\n c) Text 3\n d) Exit \n");
                keyInfo1 = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo1.Key)
                {
                    case ConsoleKey.A:
                        desiredText = "text1.txt";
                        textWords = PrintTextFile(desiredText);
                        desiredKey1 = true;
                        break;

                    case ConsoleKey.B:
                        desiredText = "text2.txt";
                        textWords = PrintTextFile(desiredText);
                        desiredKey1 = true;
                        break;

                    case ConsoleKey.C:
                        desiredText = "text3.txt";
                        textWords = PrintTextFile(desiredText);
                        desiredKey1 = true;
                        break;

                    case ConsoleKey.D:
                        return 0;

                    default:
                        Console.WriteLine("\nThats not an option...\n");
                        desiredKey1 = false;
                        break;
                }
            }
            while (!desiredKey1);

            do
            {
                Console.WriteLine("Choose a search:\n a) Full word\n b) Starts with\n c) Ends with\n d) Exit \n");
                keyInfo2 = Console.ReadKey();
                Console.WriteLine("\n-------------------------------");

                switch (keyInfo2.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Search word: ");
                        query = Console.ReadLine();
                        SearchWord(textWords, query);
                        desiredKey2 = true;
                        break;

                    case ConsoleKey.B:
                        Console.WriteLine("Search word that starts with: ");
                        query = Console.ReadLine();
                        SearchWordStarts(textWords, query);
                        desiredKey2 = true;
                        break;

                    case ConsoleKey.C:
                        Console.WriteLine("Search word that finish with: ");
                        query = Console.ReadLine();
                        SearchWordFinish(textWords, query);
                        desiredKey2 = true;
                        break;

                    case ConsoleKey.D:
                        return 0;

                    default:
                        Console.WriteLine("\nThats not an option...\n");
                        desiredKey2 = false;
                        break;
                }
            }
            while (!desiredKey2);


            Console.ReadKey();
            return 0;
        }



        static List<string> PrintTextFile(string s)
        {
            string line;
            var words = new List<string>();

            using (var sr = new StreamReader(s))
            {
                Console.WriteLine("-------------------------------");
                while ((line =sr.ReadLine()) != null)
                {
                    words.AddRange(line.Split(' '));  
                    Console.WriteLine(line);
                }
                Console.WriteLine("-------------------------------");
            }
            return words;
        }

        static void SearchWord(List<string> words, string query)
        {
            IEnumerable<string> wordsQuery = from word in words
                                             where word == query
                                             select word;
            Console.WriteLine("-------------------------------");
            if (wordsQuery.Any())
            {
                Console.WriteLine($"{wordsQuery.Count()} Words finded:\n");
                foreach (string word in wordsQuery)
                    Console.WriteLine(word);
            }
            else
                Console.WriteLine("0 Words finded...");
            Console.WriteLine("-------------------------------");
        }

        static void SearchWordStarts(List<string> words, string query)
        {
            IEnumerable<string> wordsQuery = from word in words
                                             where word.StartsWith(query)
                                             select word;
            Console.WriteLine("-------------------------------");
            if (wordsQuery.Any())
            {
                Console.WriteLine($"{wordsQuery.Count()} Words finded:\n");
                foreach (string word in wordsQuery)
                    Console.WriteLine(word);
            }
            else
                Console.WriteLine("0 Words finded...");
            Console.WriteLine("-------------------------------");
        }

        static void SearchWordFinish(List<string> words, string query)
        {
            IEnumerable<string> wordsQuery = from word in words
                                             where word.EndsWith(query)
                                             select word;
            Console.WriteLine("-------------------------------");
            if (wordsQuery.Any())
            {
                Console.WriteLine($"{wordsQuery.Count()} Words finded:\n");
                foreach (string word in wordsQuery)
                    Console.WriteLine(word);
            }
            else
                Console.WriteLine("0 Words finded...");
            Console.WriteLine("-------------------------------");
        }
    }
}

