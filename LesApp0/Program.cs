using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // введення даних
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nВведіть символи: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string s = Console.ReadLine().ToLower();

            // перевірка чи всі символи введені правильно
            try
            {
                // прохід по символам
                for (int i = 0; i < s.Length; i++)
                {
                    if (!Symbol.All.Contains(s[i]))
                    {
                        throw new Exception("\n\tВведено недопустимі символи.");
                    }
                }

                Console.WriteLine("\n\tВсі сиволи введені вірно.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
