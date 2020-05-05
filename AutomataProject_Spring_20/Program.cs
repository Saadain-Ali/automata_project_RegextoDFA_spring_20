using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataProject_Spring_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<char, int>> dfa = new Dictionary<int, Dictionary<char, int>>()
            {
                {
                    0,new Dictionary<char, int>{{ 'a',3 } , {'b',1} }
                },
                {
                     1,new Dictionary<char, int>{{ 'a',2 } , {'b',3} }
                },
                {
                     2,new Dictionary<char, int>{{ 'a',2 } , {'b',2} } //Final state
                },
                {
                     3,new Dictionary<char, int>{{ 'a',3 } , {'b',3} }
                }
            };

            int[] finalState = {2};            
            bool run = true;
            while (run)
            {
                string input = "";
                Console.WriteLine("Press Esc to quit , r to auto generate string , or press s");
                char p = Convert.ToChar(Console.ReadLine());
                switch (p)
                {
                    case 'q':
                        run = false;
                        break;
                    case 'r':
                        input = random(8);
                        Console.WriteLine(input);
                        break;
                    default:
                        Console.WriteLine("Enter your string");
                        input = Console.ReadLine();
                        break;
                }
                bool ans = accepts(dfa, 0, finalState, input);
                Console.WriteLine("Given string is " + ans);
                Console.WriteLine();
            }
           
        }
        public static bool accepts(Dictionary<int, Dictionary<char, int>> transitions, int initial, int[] arr ,string s)
        {
            int state = initial;
            bool final;
            foreach (char c in s)
                state = transitions[state][c];
            return final  = true ? arr.Contains(state) : false;
        }
        public static string random(int length)
        {
           string s = "";
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < length; i++)
            {
                int w = r.Next(97,99);
                s += (char)w;
            }

            
            //=r.Next(97, 98);

            return s;
        }

    }
}


