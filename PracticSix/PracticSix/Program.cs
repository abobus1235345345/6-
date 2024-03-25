using System;
using System.IO;
namespace ConsoleApplication1
{
    class Class1
    {
        static void Main()
        {
            Random rnd = new Random();
            try
            {
                FileStream f = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite);
                byte[] x = new byte[10];
                int a;
                int z;

                for (byte i = 0; i < 10; ++i)
                {
                    x[i] = (byte)(rnd.Next(1, 10));
                }

                f.Write(x, 0, 10);   // записывается 10 элементов массива 
                f.Seek(0, SeekOrigin.Begin);    // текущий указатель - на начало 

                for (int i = 0; i < 10; i++)
                {
                    a = f.ReadByte();
                    Console.Write(a + " ");    //контрольная печать считанного значения
                }

                Console.WriteLine();
                Console.WriteLine("\nТекущая позиция в потоке " + f.Position);
                Console.WriteLine();

                FileStream fl = new FileStream("test1.txt", FileMode.Create, FileAccess.ReadWrite);
                byte[] b = new byte[10];

                for (byte i = 0; i < 10; ++i)
                {
                    b[i] = (byte)(rnd.Next(1, 10));
                }

                fl.Write(b, 0, 10);   // записывается 10 элементов массива 
                fl.Seek(0, SeekOrigin.Begin);    // текущий указатель - на начало 

                for (int i = 0; i < 10; i++)
                {
                    z = fl.ReadByte();
                    Console.Write(z + " ");    //контрольная печать считанного значения
                }

                Console.WriteLine();
                Console.WriteLine("\nТекущая позиция в потоке " + fl.Position);
                Console.WriteLine();

                f.Seek(0, SeekOrigin.Begin);
                fl.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < 10; i++)
                {
                    a = f.ReadByte();
                    z = fl.ReadByte();

                    if (z == a)
                    {
                        Console.WriteLine(i + 1 + " - ое число является тождественным");
                    }
                    else
                    {
                        Console.WriteLine(i + 1 + " - ое число не является тождественным");
                    }
                }

                fl.Close();
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}