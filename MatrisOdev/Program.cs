using System;
using System.Reflection;

namespace MatrisOdev
{
    class Program
    {
        //Değişken isimlendirme formatı olarak Camel Case kullanılmıştır.

        public static Random rnd = new Random();
        public static int[,] dizi = new int[10, 10];

        //bombaların konumları.
        public static int bomba1X = rnd.Next(1, 10);
        public static int bomba1Y = rnd.Next(1, 10);
        public static int bomba2X = rnd.Next(1, 10);
        public static int bomba2Y = rnd.Next(1, 10);

        //kullanıcıdan alınacak girdiye göre değerler belirlenecek.
        public static int baslangicX = 9;
        public static int baslangicY = 0;

        //labirentin içindeki yollar.
        public static int yol1X = 2;
        public static int yol1Y = rnd.Next(1, 9);
        public static int isControlYol1Y = yol1Y;

        public static void MatrisCiz()
        {
            //yollar için çakışmama durumunu kontrol etmemiz gereken yer burasıdır.
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == yol1X && j == yol1Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        dizi[i, j] = 1;
                        Console.Write(1);
                        Console.ResetColor();
                        Console.Write("|");
                        yol1X++;
                        if (yol1Y < 9 || isControlYol1Y != yol1Y)
                        {
                            yol1Y++;
                        }
                    }
                    else
                    { 
                        Console.Write(0+"|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            
            string yon = "";

            
            Console.WriteLine("Oynama şekli: yeşil renkli alan başlangıç noktasını gösterir.\nw: yukarı, a: sola, s: aşağı, d: sağa yönlendirir.\n");

            MatrisCiz();

            Console.Write("Yön belirtiniz :");
            yon = Console.ReadLine();

            Console.ReadKey();
        }
    }
}

