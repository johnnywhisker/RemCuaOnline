using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyMuaBanRemCua
{
    class IO
    {
        public static int PromptOption(string message, int numberOfOption)
        {
            if (numberOfOption == -2)
            {
                Console.WriteLine("\nBấm phím bất kì để {0}", message);
                Console.ReadKey();
                return 0;
            }
            int choice = 0;
            Console.Write(message);
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 0 || choice > numberOfOption)
                {
                    throw new System.IO.InvalidDataException();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Giá trị nhập vào không hợp lệ. Giá trị chỉ từ 0 đến {0}. Bấm phím bất kì để nhập lại.", numberOfOption);
                Console.ReadKey();
                return -1;
            }
            return choice;
        }
        public static string Returnpassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}
