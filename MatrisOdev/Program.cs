using System;
using System.Reflection;

namespace MatrisOdev
{
    class Program
    {
        //Değişken isimlendirme formatı olarak Camel Case kullanılmıştır.

        public static Random rnd = new Random();
        public static int[,] matris = new int[10, 10];
        public static string yon = "";

        //bombaların konumları.
        public static int bomba1X = rnd.Next(1, 10);
        public static int bomba1Y = rnd.Next(1, 10);
        public static int bomba2X = rnd.Next(1, 10);
        public static int bomba2Y = rnd.Next(1, 10);

        //kullanıcıdan alınacak girdiye göre değerler belirlenecek.
        public static int baslangicX = 9;
        public static int baslangicY = 0;

        //labirentin içindeki yollar.
        public static int yolX = 1;
        public static int yol1Y = rnd.Next(1, 9);
        public static int isControlYol1Y = yol1Y;
        public static int yol2Y = rnd.Next(1, 9);

        public static void MatrisCiz()
        {
            //yollar için çakışmama durumunu kontrol etmemiz gereken yer burasıdır.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == yolX && j == yol1Y)
                    {
                        matris[i, j] = 1;//yol dışına çıkıp çıkmama durumunu dizinin değerinden kontrol edeceğiz.
                        yolX++;//yol için her satırda alta inmesini sağlıyoruz.
                        if ((yol1Y >= 1 && yol1Y < 8) && matris[i, j] == 1)
                        {
                            yol1Y++;
                        }
                        else if (yol1Y > 1 && matris[i, j] == 1)
                        {
                            yol1Y -= 1;
                        }
                    }
                    else if (i == yolX && j == yol2Y)
                    {
                        matris[i, j] = 2;//yol dışına çıkıp çıkmama durumunu dizinin değerinden kontrol edeceğiz.
                        yolX++;//yol için her satırda alta inmesini sağlıyoruz.
                        if ((yol2Y >= 1 && yol2Y < 8) && matris[i, j] == 2)
                        {
                            yol2Y++;
                        }
                        else if (yol2Y > 1 && matris[i, j] == 2)
                        {
                            yol2Y -= 1;
                        }
                    }
                    else
                    {
                        matris[i, j] = 0;
                    }
                }
            }
        }

        public static void MatrisGetir()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i,j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(matris[i, j]);
                        Console.ResetColor();
                        Console.Write("|");
                    }
                    else if (matris[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(matris[i, j]);
                        Console.ResetColor();
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(matris[i, j] + "|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Oynama şekli: yeşil renkli alan başlangıç noktasını gösterir.\nw: yukarı, a: sola, s: aşağı, d: sağa yönlendirir.\n");

            MatrisCiz();
            MatrisGetir();

            //Console.Write("Yön belirtiniz :");
            //yon = Console.ReadLine();
            //Console.WriteLine(yon);
            Console.ReadKey();
        }
    }
}

