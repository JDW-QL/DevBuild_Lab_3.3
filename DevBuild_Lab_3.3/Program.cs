using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DevBuild_Lab_3._3
{
    class Program
    {
        static bool Validate(string instr, Regex TestCase)
        {
            return TestCase.IsMatch(instr);
        }

        static string ReverseEachWord(string instr)
        {
            string outstr = "";
            Stack<char> word = new Stack<char>();

            for (int i = 0; i < instr.Length + 1; i++ ) // itereate through instr + 1 times
            {
                if (instr.Length != i && instr[i] != ' ') // if we are not at the end of the string and there is a non-space character in instr[i]
                    word.Push(instr[i]);                  // add character to stack
                else
                {
                    while (word.Count != 0)              // pop each stack character into outstr; reversing the order of the word
                    {
                        outstr += word.Pop();
                    }
                    if (instr.Length != i) // if we are not at the end of the string, add a space
                        outstr += " ";
                }
            }
            return outstr;
        }
        static string ReverseString(string instr)
        {
            string outstr = "";

            for (int i = instr.Length; i > 0; i--)
            {
                outstr += instr[i - 1];
            }
            return outstr;
        }

        static string ReverseWithStack(string instr)
        {
            string outstr = "";

            Stack<char> word = new Stack<char>();
            foreach(char c in instr)
            {
                word.Push(c);
            }
            foreach(char c in instr)
            {
                outstr += word.Pop();
            }

            return outstr;
        }
        static void Main(string[] args)
        {
            string inputWord;
            string outputWord;
            string choice = "";
            bool restart;
            Regex test = new Regex(@"^([a-zA-Z]||\s)+$");
            
            do
            {
                restart = true;

                Console.Clear();
                Console.Write("\n\nPlease enter a word you would like reversed: ");
                inputWord = Console.ReadLine();

                while (!Validate(inputWord, test))
                {
                    Console.Write("\nPlease enter in a valid string without numbers or special characters to be reversed: ");
                    inputWord = Console.ReadLine();
                }

                outputWord = ReverseString(inputWord);
                Console.WriteLine($"\nYour word in reverse is: {outputWord}");

                outputWord = ReverseWithStack(inputWord);
                Console.WriteLine($"\nYour word in reverse(stack) is: {outputWord}");

                outputWord = ReverseEachWord(inputWord);
                Console.WriteLine($"\nYour word in reverse(each word) is: {outputWord}\n\n\n\n");

                while (choice != "y" && choice != "n")
                {
                    Console.Write("Would you like to reverse another word? y/n: ");
                    choice = Console.ReadLine().ToLower();
                    if (choice == "n")
                        restart = false;
                }
                choice = "";
            } while (restart == true);

            Console.Clear();
            Console.WriteLine("\n\n!margorp ym gnisu rof uoy knahT\n\n\n\n\n\n\n\n");

        }
    }
}
