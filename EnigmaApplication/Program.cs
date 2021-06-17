using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**********WELLCOME TO THE ENIGMA DECRYPTION APPLICATION**********");


            int lSiraBaslangic = -1, hSiraBaslangic = -1;
            bool ayar1ok = false, ayar2ok = false;



            string message = string.Empty;

            char[] karakterler = new char[2] { 'H', 'L' };

            Stack<int> lSiraStack;
            Stack<int> hSiraStack;

            Stack<char> messageStack = new Stack<char>();
            Stack<int> resultStack = new Stack<int>();

            int coreSayi = 0;
            char islenenHarf;

            bool lKilit = false;
            bool hKilit = false;

            do
            {
                Console.WriteLine("Biliyorsanız enigma a parametresi başlangıç ayarını giriniz....bilmiyorsanız default ayar için boş bırakabilirsiniz");

                ayar1ok = int.TryParse(Console.ReadLine(), out lSiraBaslangic);

                if (lSiraBaslangic < 1)
                {
                    Console.WriteLine("Sıfırdan büyük değer giriniz...");
                }

            } while (lSiraBaslangic > 0);


            do
            {
                Console.WriteLine("Biliyorsanız enigma b parametresi başlangıç ayarını giriniz....bilmiyorsanız default ayar için boş bırakabilirsiniz");

                ayar2ok = int.TryParse(Console.ReadLine(), out hSiraBaslangic);

                if (hSiraBaslangic < 1)
                {
                    Console.WriteLine("Sıfırdan büyük değer giriniz...");
                }

            } while (hSiraBaslangic > 0);

            if (!ayar1ok)
                lSiraBaslangic = 10;

            if (!ayar2ok)
                hSiraBaslangic = 10;

            /////////STACKLERİ AYARLA

            lSiraStack = new Stack<int>(lSiraBaslangic);
            for (int i = 1; i <= lSiraBaslangic; i++)
            {
                lSiraStack.Push(i);
            }

            hSiraStack = new Stack<int>(hSiraBaslangic);
            for (int i = 1; i <= hSiraBaslangic; i++)
            {
                hSiraStack.Push(i);
            }

            /////////STACKLERİ AYARLA


            ////MESAJ KONTROL

            Console.WriteLine("ENCRYPTED MESAJI GİRİNİZ...");

            do
            {
                message = Console.ReadLine();

            } while (GirilenKarakterKontrol(message, karakterler));

            ////MESAJ KONTROL


            foreach (char item in message.Reverse())
            {
                messageStack.Push(item);
            }

            ///LOGIC FLOW START

            //BASLANGIC
            islenenHarf = messageStack.Pop();

            if (islenenHarf == 'H')
            {
                coreSayi += 1;
                resultStack.Push(coreSayi);
            }
            else if (islenenHarf == 'L')
            {
                //POP KONTROL.....
                coreSayi = lSiraStack.Pop();
                resultStack.Push(coreSayi);

                coreSayi = coreSayi - 1;
                resultStack.Push(coreSayi);
            }
            else
            {
                Console.WriteLine("bir hata oluştu");
                return;
            }
            //BASLANGIC


            for (int i = 0; i < messageStack.Count; i++)
            {

                islenenHarf = messageStack.Pop();

                if (islenenHarf == 'H')
                {

                    if (lKilit)
                    {

                    }
                    else
                    {

                    }



                }
                else if (islenenHarf == 'L')
                {

                    if (hKilit)
                    {

                    }
                    else
                    {

                    }

                }
                else
                {
                    Console.WriteLine("bir hata oluştu");
                    return;
                }

            }

        }


        private static bool GirilenKarakterKontrol(string checkMessage, char[] karakterArray)
        {
            bool karakterKontrol = true;

            foreach (var karakter in checkMessage)
            {

                karakterKontrol = karakterArray.Contains(karakter);

                if (!karakterKontrol)

                    break;
            }

            if (karakterKontrol)
                return true;
            else
            {
                Console.WriteLine("Mesaj beklenilen formatta değil...yeniden giriniz..");
                return false;
            }

        }

    }
}
