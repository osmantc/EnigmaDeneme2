using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            string girilen = Console.ReadLine();

            int firstHindex = girilen.IndexOf('H');

            int baslanacakSayi = firstHindex + 1;
            char[] girilenArray = girilen.ToArray();
            List<int> hyeri = new List<int>();
            List<int> lyeri = new List<int>();

            //LLHLLHLLH

            int maxSayi = girilenArray.Length + 1;

            List<int> sonucList = new List<int>(maxSayi);

            List<int> sayiHaznesi = new List<int>(Enumerable.Range(1, maxSayi));



            for (int i = baslanacakSayi; i > 0; i--)
            {
                sonucList.Add(i);
                sayiHaznesi.Remove(i);
            }

            for (int i = firstHindex; i < girilenArray.Length; i++)
            {

                if (girilenArray[i] == 'H')
                    hyeri.Add(i - firstHindex);
                else
                    lyeri.Add(i - firstHindex);
                lyeri.Add(i - firstHindex);

            }


            List<List<int>> possibilityList = new List<List<int>>();

            for (int i = 0; i < maxSayi - baslanacakSayi; i++)
            {
                List<int> list = new List<int>(Enumerable.Range(baslanacakSayi + 1, maxSayi));
                possibilityList.Add(list);
            }

            bool patladiMi = false;

            List<int> minDegerlerH = new List<int>();
            //List<int> minDegerlerL = new List<int>();

            minDegerlerH.Add(sonucList.Last());

            for (int i = firstHindex; i < girilenArray.Length; i++)
            {

                if (i >= firstHindex && patladiMi)
                {
                    i = i - 2;
                    patladiMi = false;
                }

                if (girilenArray[i] == 'H')
                {

                    //int currentdeger = sonucList.Last();
                    int yenideger = 0;

                    if (possibilityList[i - firstHindex].Any(x => x > minDegerlerH.Last()))
                    {
                        yenideger = possibilityList[i - firstHindex].First(x => x > minDegerlerH.Last());

                        //foreach (var index in hyeri)
                        //{
                        //    possibilityList[index].Remove(yenideger);
                        //}

                        possibilityList[i - firstHindex].Remove(yenideger);

                        sonucList.Add(yenideger);

                        minDegerlerH.Add(yenideger);
                    }
                    else
                    {
                        patladiMi = true;
                        sonucList.Remove(sonucList.ElementAt(i));
                    }
                }
                else  //'L' ise
                {
                    //int currentdeger = sonucList.Last();
                    int yenideger = 0;


                    if (possibilityList[i - firstHindex].Any(x => x < sonucList.Last()))
                    {
                        yenideger = possibilityList[i - firstHindex].FindLast(x => x < sonucList.Last());

                        //foreach (var index in lyeri)
                        //{
                        //    possibilityList[index].Remove(yenideger);
                        //}

                        possibilityList[i - firstHindex].Remove(yenideger);

                        sonucList.Add(yenideger);

                        //minDegerlerL.Add(yenideger);
                    }
                    else
                    {
                        patladiMi = true;
                        sonucList.Remove(sonucList.ElementAt(i));
                    }


                }


            }

            foreach (var item in sonucList)
            {

                Console.WriteLine(item);
            }


            Console.ReadLine();


        }
    }
}
