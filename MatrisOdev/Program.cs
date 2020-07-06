using System;
using System.Reflection;

namespace MatrisOdev
{
    class Program
    {
        //Değişken isimlendirme formatı olarak Camel Case kullanılmıştır.

        //Oyunun çalışma şekli
        //matris içerisinde girilen değerlerden 0 duvarları işaret eder.
        //1 yolları belirtir.
        //2 bombaları belirtir.
        //3 kullanıcı konumu için kullanılır.

        public static Random rnd = new Random();
        public static Random rnd2 = new Random();
        public static int[,] matris = new int[10, 10];
        public static int[] kullaniciGiris = new int[10];
        public static string yol = "";
        public static bool varMiBomba1 = true;
        public static bool varMiBomba2 = true;
        public static int isControlBombaIslemleri = 0;
        public static bool isControlGamePlay = true;
        public static bool isControlBasla = true;       

        //bombaların konumları.
        public static int bomba1X = rnd.Next(1, 9);
        public static int bomba1Y = rnd.Next(1, 9);
        public static int bomba2X = rnd.Next(1, 9);
        public static int bomba2Y = rnd.Next(1, 9);

        //kullanıcıdan alınacak girdiye göre değerler belirlenecek.
        public static int baslangicX = 9;
        public static int baslangic1Y = 0;
        public static int baslangic2Y = 0;
        public static int baslangic3Y = 0;

        //labirentin içindeki yollar.
        public static int yolX = 0;
        public static int yol1Y = rnd.Next(1, 3);
        public static int isControlYol1Y = yol1Y;
        public static int yol2X = 0;
        public static int yol2Y= rnd.Next(3, 5);
        public static int yol3X = 0;
        public static int yol3Y = rnd.Next(5, 8);

        //yolun genisligini ayarlamak icin kullanılıyor.
        public static int genislik = 0;        

        //matrisin saf halini çizer.
        public static void MatrisCiz()
        {
            //yollar için çakışmama durumunu kontrol etmemiz gereken yer burasıdır.
            if (yol1Y == yol2Y || yol1Y == yol3Y) yol1Y = rnd2.Next(1, 2);
            else if (yol2Y == yol1Y || yol2Y == yol3Y) yol2Y = rnd2.Next(3, 5);
            else if (yol3Y == yol2Y || yol3Y == yol1Y) yol3Y = rnd2.Next(5, 8);
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

                            //kullanıcının başlayacağı yolu seçmek için girişin konumunu alır.
                            if (i == 9 && matris[i,j] == 1)
                            {
                                baslangic1Y = j;
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

                            //kullanıcının başlayacağı yolu seçmek için girişin konumunu alır.
                            if (i == 9 && matris[i, j] == 1)
                            {
                                baslangic2Y = j;
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
                                yol3Y -= 2;
                            }

                            //kullanıcının başlayacağı yolu seçmek için girişin konumunu alır.
                            if (i == 9 && matris[i, j] == 1)
                            {
                                baslangic3Y = j;
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
                    if (matris[i, j] == 1 && 8 >= j && i <= 8 && genislik < 2)
                    {
                        //Console.WriteLine("{0}.satır {1}. sütun : {2}",i, j, matris[i, j + 1]);
                        genislik++;
                        matris[i, j + 1] = 1;
                    }
                    else if (matris[i, j] == 1 && i == 9 && genislik < 2)
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
                    if (matris[i,j] == 1 || matris[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("1");
                        Console.Write("|");
                        Console.ResetColor();
                    }
                    else if(matris[i, j] == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("K");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
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

        //kullanıcının seçmesi için yolu çizer.
        public static void GirisBelirle()
        {
            for (int i = 0; i < kullaniciGiris.Length; i++)
            {
                if (i == baslangic1Y)
                {
                    kullaniciGiris[i] = 1;
                    Console.Write(kullaniciGiris[i]);
                }
                else if (i == baslangic2Y)
                {
                    kullaniciGiris[i] = 2;
                    Console.Write(" "+kullaniciGiris[i]);
                }
                else if (i == baslangic3Y)
                {
                    kullaniciGiris[i] = 3;
                    Console.Write(" "+kullaniciGiris[i]);
                }
                else Console.Write("  ");                
            }
            Console.WriteLine("\n");
        }

        //bombaları oluşturan metotlar.
        public static void Bomba1Olustur()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    while (varMiBomba1)
                    {
                        if (matris[bomba1X, bomba1Y] == 1)
                        {
                            matris[bomba1X, bomba1Y] = 2;
                            varMiBomba1 = false;
                        }
                        else
                        {
                            bomba1X = rnd.Next(2, 8);
                            //bomba1Y = rnd.Next(2, 8);
                        }
                    }
                }
            }
        }
        public static void Bomba2Olustur()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    while (varMiBomba2)
                    {
                        if (matris[bomba2X, bomba2Y] == 1)
                        {
                            matris[bomba2X, bomba2Y] = 2;
                            varMiBomba2 = false;
                        }
                        else
                        {
                            bomba2X = rnd.Next(2, 8);
                            //bomba1Y = rnd.Next(2, 8);
                        }
                    }
                }
            }

            
            
        }

        //bombaları göstermek için kullanacağımız metot.
        public static void BombaGoster()
        {
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matris[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(matris[i, j]);
                        Console.Write("|");
                        Console.ResetColor();
                    }
                    else if (matris[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
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
        
        //konsol ekranında bomba işlemlerini kontrol için kullanılır.
        public static void BombaIslemleri(string yon)
        {
            if (isControlBombaIslemleri == 0)
            {
                BombaGoster();
                isControlBombaIslemleri = 1;
            }
            else if(isControlBombaIslemleri == 1)
            {
                isControlBombaIslemleri = 0;
                KonsolTemizle();
            }
        }

        public static void KonsolTemizle()
        {
            Console.Clear();
            Uyarilar();
            MatrisGetir();
            GirisBelirle();
        }

        //oyunda yukarı yönü kontroledeceğimiz metot.
        public static void ImlecYukari()
        {

        }

        //oyunda sol yönü kontroledeceğimiz metot.
        public static void ImlecSola()
        {

        }

        //oyunda aşağı yönü kontroledeceğimiz metot.
        public static void ImlecAsagi()
        {

        }

        //oyunda sağ yönü kontroledeceğimiz metot.
        public static void ImlecSaga()
        {

        }

        //uyarılar/yönlendirmeler.
        public static void Uyarilar()
        {
            Console.WriteLine("Oynama şekli: yeşil renkli alan yolları gösterir.");
            Console.WriteLine("w: yukarı, a: sola, s: aşağı, d: sağa yönlendirir.");
            Console.WriteLine("Bombaların yerini görmek için g tuşunu kullanınız.");
        }

        //yol seçimini kontrol edeceğimiz metot.
        public static void YolSecimi(string yol)
        {
            while (isControlGamePlay)
            {
                if (yol == "1")
                {
                    Console.WriteLine(yol + ".yoldasınız.");
                    GamePlay(Convert.ToInt32(yol));
                    isControlGamePlay = !isControlGamePlay;
                }
                else if (yol == "2")
                {
                    Console.WriteLine(yol + ".yoldasınız.");
                    GamePlay(Convert.ToInt32(yol));
                    isControlGamePlay = !isControlGamePlay;
                }
                else if (yol == "3")
                {
                    Console.WriteLine(yol + ".yoldasınız.");
                    GamePlay(Convert.ToInt32(yol));
                    isControlGamePlay = !isControlGamePlay;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yaptınız!!! Yeniden deneyiniz!");
                    isControlGamePlay = !isControlGamePlay;
                }
            }
        }

        //oyun kontrolü için kullanacağımız metot.
        public static void GamePlay(int yol)
        {
            isControlBasla = !isControlBasla;
            for (int i = 0; i < kullaniciGiris.Length; i++)
            {
                if (yol == kullaniciGiris[i])
                {
                    //i yi kullanıp yerini tespit ettiğimiz giriş noktasına erişiyoruz.
                    for (int j = 0; j < 10; j++)
                    {
                        if (i == j)
                        {
                            //burası yola eriştiğimiz yer seçimi yaptıktan "k" yazdırıyoruz.
                            //KullaniciIsaretle(isControlKullaniciGiris, i, j);
                            matris[9, j] = 3;
                            KonsolTemizle();
                            
                        }
                    }
                }

            }
            
        }


        public static void Basla()
        {
            while (isControlBasla)
            {
                Console.Write("Kaderinizi seçiniz :");
                yol = Console.ReadLine();

                if (yol == "g")
                {
                    BombaIslemleri(yol);
                }
                else if (yol != "g")
                {
                    YolSecimi(yol);
                    isControlGamePlay = !isControlGamePlay;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("EĞER OYUN YÜKLENMEDİYSE, YÜKLENENE KADAR YENİDEN BAŞLATINIZ.");
            Console.ResetColor();


            MatrisCiz();
            MatrisDuzenle();
            Bomba1Olustur();
            Bomba2Olustur();
            Uyarilar();

            KonsolTemizle();


            Basla();

            Console.ReadKey();
        }
    }
}