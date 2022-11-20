using System;
using System.IO;

namespace Decorator
{
    internal class Program
    {
        class LettersCounter
        {
            protected int[] lowletters;
            protected int[] upletters;
            public void countletters(string s)
            {
                lowletters = new int[26];
                upletters = new int[26];
                for (int i=0; i < s.Length; i++)
                {
                    char c = Convert.ToChar(s[i]);
                    if (c>='a' && c <= 'z')
                    {
                        lowletters[c - 'a']++;
                    }
                    else if (c >= 'A' && c <= 'Z')
                    {
                        upletters[c - 'A']++;
                    }
                }
            }

            public virtual void showcounted()
            {
                for (int i = 0; i < lowletters.Length; i++)
                {
                    if(lowletters[i] >0)
                    {
                        Console.Write(Convert.ToChar('a'+i) +": "+lowletters[i]+", ");
                    }
                    if (upletters[i] > 0)
                    {
                        Console.Write(Convert.ToChar('A' + i) + ": " + upletters[i] + ", ");
                    }
                }
                Console.WriteLine();
            }
        }

        class LC2:LettersCounter
        {
            public override void showcounted()
            {
                for(int i = 0; i < lowletters.Length; i++)
                {
                    if (lowletters[i]+upletters[i] > 0)
                    {
                        Console.WriteLine(Convert.ToChar('A' + i) + ": " + (upletters[i] + lowletters[i]));
                    }
                }
            }
        }
        class LC3 : LC2
        {
            public override void showcounted()
            {
                StreamWriter file = new("file.txt");
                for (int i = 0; i < lowletters.Length; i++)
                {
                    if (lowletters[i] + upletters[i] > 0)
                    {
                        file.WriteLine(Convert.ToChar('A' + i) + ": " + (upletters[i] + lowletters[i]));
                    }
                }
                file.Close();

            }
        }
        static void Main(string[] args)
        {
            LettersCounter lc = new LettersCounter();
            LettersCounter lc2 = new LC2();
            LettersCounter lc3 = new LC3();
            lc.countletters("Allabama");
            lc.showcounted();
            lc2.countletters("Allabama");
            lc2.showcounted();
            lc3.countletters("Allabama");
            lc3.showcounted();
        }
    }
}
