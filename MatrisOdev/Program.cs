using System;
using System.Reflection;

namespace MatrisOdev
{
    class Program
    {
        //Değişken isimlendirme formatı olarak Camel Case kullanılmıştır.

        public static Random rnd = new Random();
        public static Random rnd2 = new Random();
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
        public static int yolX = 0;
        public static int yol1Y = rnd.Next(0, 3);
        public static int isControlYol1Y = yol1Y;
        public static int yol2X = 0;
        public static int yol2Y= rnd.Next(3, 5);
        public static int yol3X = 0;
        public static int yol3Y = rnd.Next(5, 9);

        //yolun genisligini ayarlamak icin kullanılıyor.
        public static int genislik = 0;

        //matrisin saf halini çizer.
        public static void MatrisCiz()
        {
            //yollar için çakışmama durumunu kontrol etmemiz gereken yer burasıdır.
            if (yol1Y == yol2Y || yol1Y == yol3Y) yol1Y = rnd2.Next(0, 3);
            else if (yol2Y == yol1Y || yol2Y == yol3Y) yol2Y = rnd2.Next(3, 5);
            else if (yol3Y == yol2Y || yol3Y == yol1Y) yol3Y = rnd2.Next(5, 9);
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (i == yolX && j == yol1Y)
                        {
                            matris[i, j] = 1;//yol dışına çıkıp çıkmama durumunu dizinin değerinden kontrol edeceğiz.
                            yolX++;//yol için her satırda alta inmesini sağlıyoruz.
                            if ((yol1Y >= 1 && yol1Y < 4) && matris[i, j] == 1)
                            {
                                yol1Y++;
                            }
                            else if (yol1Y > 1 && matris[i, j] == 1)
                            {
                                yol1Y -= 1;
                            }
                        }
                        else if (i == yol2X && j == yol2Y)
                        {
                            matris[i, j] = 1;//yol dışına çıkıp çıkmama durumunu dizinin değerinden kontrol edeceğiz.
                            yol2X++;//yol için her satırda alta inmesini sağlıyoruz.
                            if ((yol2Y >= 3 && yol2Y < 6) && matris[i, j] == 1)
                            {
                                yol2Y++;
                            }
                            else if (yol2Y > 1 && matris[i, j] == 1)
                            {
                                yol2Y -= 1;
                            }
                        }
                        else if (i == yol3X && j == yol3Y)
                        {
                            matris[i, j] = 1;//yol dışına çıkıp çıkmama durumunu dizinin değerinden kontrol edeceğiz.
                            yol3X++;//yol için her satırda alta inmesini sağlıyoruz.
                            if ((yol3Y >= 5 && yol3Y < 9) && matris[i, j] == 1)
                            {
                                yol3Y++;
                            }
                            else if (yol3Y > 1 && matris[i, j] == 1)
                            {
                                yol3Y -= 1;
                            }
                            else if(yol3Y == yol2Y ||yol3Y == yol1Y)
                            {
                                yol3Y -= 3;
                            }
                        }
                        else
                        {
                            matris[i, j] = 0;
                        }
                    }
                }
            }
        }

        //matris çizildikten sonra aralarda kalan boşlukları doldurur.
        public static void MatrisDuzenle()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i, j] == 1 && 8 >= j && i <= 8 && genislik < 3)
                    {
                        //Console.WriteLine("{0}.satır {1}. sütun : {2}",i, j, matris[i, j + 1]);
                        genislik++;
                        matris[i, j + 1] = 1;
                    }
                    else if (matris[i, j] == 1 && i == 9)
                    {
                        matris[i - 1, j] = 1;
                    }
                    else genislik = 0;
                }
            }
        }

        //matrisin son halini ekrana basar.
        public static void MatrisGetir()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i,j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(matris[i, j]);
                        Console.Write("|");
                        Console.ResetColor();
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
            MatrisDuzenle();
            MatrisGetir();

            //Console.Write("Yön belirtiniz :");
            //yon = Console.ReadLine();
            //Console.WriteLine(yon);

            

            Console.ReadKey();
        }
    }
}

