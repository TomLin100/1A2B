using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NANB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] number = new bool[10]; //判斷是否抽過
            int[] password = new int[4]; //放要猜的數字
            Random random = new Random(); //亂數產生器
            string isContinue = "";
            bool success = false;
            int pick_number;
            Console.Write("歡迎來到1A2B猜數字的遊戲～\n------\n");
            while (!success || isContinue == "y")
            {
                //初始化
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = false;
                }
                //選擇4個不同的數字
                for (int i = 0; i < password.Length; i++)
                {
                    pick_number = random.Next(0, 9);
                    if (!number[pick_number])
                    {
                        password[i] = pick_number;
                        number[password[i]] = true;
                    }
                }

                while (true)
                {
                    //提示訊息並請使用者輸入
                    string answer = string.Join("", password);
                    Console.WriteLine(answer);
                    Console.Write("請輸入4個數字：");
                    string guess = Console.ReadLine();
                    int[] input = guess.Select(x => int.Parse(x.ToString())).ToArray();

                    int A = 0, B = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == password[i])
                        {
                            A++;
                        }
                        else if (password.Contains(input[i]))
                        {
                            B++;
                        }
                    }
                    if (guess == answer)
                    {
                        Console.Write("判定結果是4A0B\n恭喜你！猜對了！！\n");
                        Console.Write("------\n你要繼續玩嗎?(y/n):");
                        isContinue = Console.ReadLine();
                        if (isContinue == "y")
                        {
                            success = false;
                        }
                        else
                        {
                            success = true;                            
                        }
                        break;
                    }
                    else
                    {
                        Console.Write($"判定結果是{A}A{B}B \n--------\n");
                    }
                }
            }
            
            Console.WriteLine("遊戲結束，下次再來玩喔～");
        }
    }
}
