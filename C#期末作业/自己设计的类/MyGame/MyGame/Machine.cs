using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Machine
    {
            int i;
            public void Begin()  //启动
            {
                Console.WriteLine("Welcome to the Game created by Song Jie!\n");
                Console.WriteLine("************************************************\n");
            }

            public void  FirstAsk()//第一次问是否游戏
            {
                Console.WriteLine("Your magic adventure starts now!");
                Console.WriteLine();
            }

            public bool Ask()  //判断是否中断游戏
            {
                Console.WriteLine("\nPress 0 to exit:");
                Console.WriteLine("Press any others to continue:");
                Console.WriteLine();
                string sop = Console.ReadLine();
                try
                {
                    i = Int32.Parse(sop);
                }
                catch
                {
                    i = 1;
                }

                if (i != 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Hoping for your next adventure!");
                    return false;
                }
            }

        }
    }
