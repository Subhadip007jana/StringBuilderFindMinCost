using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderMinimumCost
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int Count;
            Console.WriteLine("Enter How many Case you want to enter?");
            Count = Convert.ToInt32(Console.ReadLine());
            int[] Parameter = new int[3];
            int itr = 1;
            while (Count > 0)
            {
                Console.WriteLine("\n--------------------------------- "+ itr++ + "-Itaration ---------------------------");
                Console.WriteLine("\nPlease enter your parameters[ex: 9 4 5 Enter Saparator] :");
                for (int i = 0; i < 3; i++)
                {
                    Parameter[i] = Convert.ToInt32(Console.ReadLine());
                }
                
                string strInput = "";
                int flag = 0;
                do
                {
                    if (flag > 0)
                    {
                        Console.WriteLine("Your string langth not matched please reenter your string !");
                        strInput = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Please enter your full string and then press 'ENTER'\n");
                        strInput = Console.ReadLine();
                    }
                    flag++;

                } while (strInput.Length != Parameter[0]);

                // function call to return Minimum COst
                Console.Write("Total Minimum Cost: " + minimumCost(strInput, strInput.Length, Parameter[1], Parameter[2]));
                Count--;
            }




            Console.WriteLine("\nPress any key to Exit");
            Console.ReadKey();
        }

        static int minimumCost(String s, int n, int AddCost, int CopyCost)
        {
            int TotalCost = 0;
            String s1 = "", s2 = "";

            s1 += s[0];
            s1 += s[1];
            TotalCost = AddCost + AddCost;
            for (int i = 2; i < n; i++)
            {
                char x = s[i];
                int index = s1.IndexOf(x);
                var ind = AllIndex(s1, x);
                if (index < 0)
                {
                    s1 += s[i];
                    TotalCost = TotalCost + AddCost;
                }
                else
                {

                    for (int k = 0; k < ind.Count; k++)
                    {
                        s2 = "";
                        int flag = 0;
                        int counter = i;
                        index = ind[k];
                        while (index < s1.Length && counter < s.Length && s1[index] == s[counter])
                        {
                            flag++;
                            s2 += s[counter++];
                            index++;
                        }
                        //Checking If String can coppy
                        if (flag > 1)
                        {
                            s1 += s2;
                            i = counter - 1;
                            TotalCost = TotalCost + CopyCost;
                            break;
                        }
                        else if (k == ind.Count - 1)
                        {
                            s1 += s[i];
                            TotalCost = TotalCost + AddCost;
                        }
                    }
                }
            }
            return TotalCost;
        }

        public static List<int> AllIndex(string s, char ch)
        {
            var foundIndexes = new List<int>();
            for (int i = s.IndexOf(ch); i > -1; i = s.IndexOf(ch, i + 1))
            {
                foundIndexes.Add(i);
            }
            return foundIndexes;
        }
    }
}
