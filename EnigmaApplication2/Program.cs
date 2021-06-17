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

            int maxSayi = girilenArray.Length + 1;

            List<int> sonucList = new List<int>(maxSayi);

            List<int> sayiHaznesi = new List<int>(Enumerable.Range(1, maxSayi));

            bool patladiMi = false;

            List<List<int>> bannedList = new List<List<int>>();


            for (int i = baslanacakSayi; i > 0; i--)
            {
                sonucList.Add(i);
                sayiHaznesi.Remove(i);
            }



            for (int i = 0; i < maxSayi - baslanacakSayi; i++)
            {
                List<int> list = new List<int>();

                bannedList.Add(list);
            }



            for (int i = firstHindex; i < girilenArray.Length; i++)
            {

                if (girilenArray[i] == 'H')
                {

                    int yenideger = 0;

                    sayiHaznesi = sayiHaznesi.OrderBy(x => x).ToList();

                    List<int> secilebilirAlan = sayiHaznesi.Where(x => bannedList[i - firstHindex].Contains(x) == false).ToList();

                    if (secilebilirAlan.Count > 0)
                    {

                        yenideger = secilebilirAlan.First();

                        sayiHaznesi.Remove(yenideger);

                        sonucList.Add(yenideger);

                    }
                    else
                    {
                        patladiMi = true;

                        int banlanacakValue = sonucList.ElementAt(i);

                        sonucList.Remove(banlanacakValue);

                        if (i - firstHindex - 1 >= 0)
                            bannedList[i - firstHindex - 1].Add(banlanacakValue);

                        sayiHaznesi.Add(banlanacakValue);
                    }
                }
                else  //'L' ise
                {
                    int yenideger = 0;

                    sayiHaznesi = sayiHaznesi.OrderByDescending(x => x).ToList();

                    List<int> secilebilirAlan = sayiHaznesi.Where(x => bannedList[i - firstHindex].Contains(x) == false && x < sonucList.Last()).ToList();


                    if (secilebilirAlan.Count > 0)
                    {
                        yenideger = secilebilirAlan.First();

                        sayiHaznesi.Remove(yenideger);

                        sonucList.Add(yenideger);

                    }
                    else
                    {
                        patladiMi = true;

                        int banlanacakValue = sonucList.ElementAt(i);

                        sonucList.Remove(banlanacakValue);

                        if (i - firstHindex - 1 >= 0)
                            bannedList[i - firstHindex - 1].Add(banlanacakValue);

                        sayiHaznesi.Add(banlanacakValue);
                    }


                }

                if (i >= firstHindex && patladiMi)
                {
                    i = i - 2;
                    patladiMi = false;
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
