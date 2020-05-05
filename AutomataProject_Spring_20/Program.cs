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

            //our reg expression = ba(a+b)abaa+ba(a+b)*

            //////////////////////// TRANSITION TABLE /////////////////////////////////////////
            Dictionary<int, Dictionary<char, int>> dfa = new Dictionary<int, Dictionary<char, int>>()
            {
                {
                  //Current State           //next_state_for 'a'       //next_state_for 'b'
                     0,new Dictionary<char, int>{  { 'a',3 } ,               {'b',1} }
                },
                {
                     1,new Dictionary<char, int>{{ 'a',2 } ,                {'b',3} }
                },
                {
                     2,new Dictionary<char, int>{{ 'a',2 } ,                {'b',2} }
                },
                {
                     3,new Dictionary<char, int>{{ 'a',3 } ,                {'b',3} }
                }
            };

            int[] finalState = {2};    // Final States our DFA         

           
            while (true)
            {
                string input = "";
                Console.WriteLine("Press Esc to quit , r to auto generate string , or press enter to enter your string");
                ConsoleKeyInfo c = Console.ReadKey(true);

                if (c.Key == ConsoleKey.Escape)
                    break;  

                else if (c.Key == ConsoleKey.R)
                {
                    input = random();
                    Console.WriteLine(input);
                }

                else
                {
                    Console.Write("Enter your string : ");
                    input = Console.ReadLine();
                }
                bool ans = accepts(dfa, 0, finalState, input);
                Console.WriteLine("\t\t\nGiven string is " + ans + "\n\n");
                
            }
           
        }
        public static bool accepts(Dictionary<int, Dictionary<char, int>> transitions, int initial, int[] arr ,string s)
        {
            int state = initial;
            bool final;
            Console.WriteLine("current_state\tcharacter\tnext_state");
            foreach (char c in s)
            {
                if (c != 'a' && c != 'b')
                {
                    Console.WriteLine($"{c} is not a part of language {{a,b}}");
                    return false;
                }
                Console.Write(state+"\t\t"); //to print the transitions
                state = transitions[state][c];
                Console.WriteLine( c + "\t\t"+ state );
                
            }
               
            return final  = true ? arr.Contains(state) : false;
        }
        public static string random()
        {
            
           string s = "";
            Random r = new Random(DateTime.Now.Millisecond);
            int length = r.Next(3,11);
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


