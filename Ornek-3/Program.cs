using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FENERBAHÇE - GALATSARAY - TRABZON - BEŞİKTAŞ (SÜPER FİNALİNDE)
            // BU DÖRT TAKIM KENDİ ARALARINDA 2 ŞER MAÇ YAPIYORLAR BU MAÇLARIN SONUCUNDA KAZANAN TAKIMLAR 3 PUAN KAYBEDEN TAKIMLAR İSE PUAN KAZANMIYOR BERABERLİK DURUMUNDA İSE HER İKİ TAKIMDA 1 PUAN KAZANIYOR.
            //MAÇ SONUÇLARININ 0-4 ARASINDA RASTGELE OLARAK OLUŞTURULSUN.
            //BUNUN SONUCUNDA LİGTE ŞAMPİYON OLANAN TAKIMIN ADINI LİGİN PUAN TABLOSUNU OLUŞTURUNUZ!!


            string[] takimIsmi = new string[4] { "Galatasaray", "Fenerbahçe.", "Beşiktaş...", "Trabzonspor" };
            int[] puanDurumu = new int[4];
            int[] atilanGol = new int[4];
            int[] yenilenGol = new int[4];
            int[] galibiyet = new int[4];
            int[] maglubiyet = new int[4];
            int[] beraberlik = new int[4];
            int[] oynadigiMac = new int[4];

            int[,] macSonucuEv = new int[4, 4];
            int[,] macSonucuDep = new int[4, 4];

            MacSonuclari(takimIsmi, macSonucuEv, macSonucuDep);
            Console.WriteLine("\n");
            EvindeOynananMaclariKiyasla(ref atilanGol, ref yenilenGol, ref puanDurumu, ref galibiyet, ref beraberlik, macSonucuDep, macSonucuEv);
            DeplasmandaOynananMaclirKiyasla(ref atilanGol, ref yenilenGol, ref puanDurumu, ref galibiyet, ref beraberlik, macSonucuDep, macSonucuEv);
            KaybedilenMaclariHesapla(ref oynadigiMac, ref maglubiyet, galibiyet, beraberlik);
            SiralamaYap(ref puanDurumu, ref takimIsmi, ref maglubiyet, ref galibiyet, ref beraberlik, ref atilanGol, ref yenilenGol, ref oynadigiMac);
            PuanTablosu(takimIsmi, puanDurumu, maglubiyet, galibiyet, beraberlik, atilanGol, yenilenGol, oynadigiMac);
            Console.ReadLine();
        }




        private static void PuanTablosu(string[] takimIsmi, int[] puanDurumu, int[] maglubiyet, int[] galibiyet, int[] beraberlik, int[] atilanGol, int[] yenilenGol, int[] oynadigiMac)
        {
            Console.WriteLine("--------------------PUAN DURUMU---------------------");
            Console.WriteLine("------------------ O -- G -- B -- M -- A -- Y -- P--");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}. {takimIsmi[i]}.....{oynadigiMac[i]} .. {galibiyet[i]} .. {beraberlik[i]} .. {maglubiyet[i]} .. {atilanGol[i]} .. {yenilenGol[i]} .. {puanDurumu[i]}");
            }           
        }

        private static void SiralamaYap(ref int[] puanDurumu, ref string[] takimIsmi, ref int[] maglubiyet, ref int[] galibiyet, ref int[] beraberlik, ref int[] atilanGol, ref int[] yenilenGol, ref int[] oynadigiMac)
        {
            int sayiTut = 0;
            string kelimeTut = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        if (puanDurumu[i] > puanDurumu[j])
                        {
                            sayiTut = puanDurumu[i];
                            puanDurumu[i] = puanDurumu[j];
                            puanDurumu[j] = sayiTut;

                            sayiTut = atilanGol[i];
                            atilanGol[i] = atilanGol[j];
                            atilanGol[j] = sayiTut;

                            sayiTut = yenilenGol[i];
                            yenilenGol[i] = yenilenGol[j];
                            yenilenGol[j] = sayiTut;

                            sayiTut = galibiyet[i];
                            galibiyet[i] = galibiyet[j];
                            galibiyet[j] = sayiTut;

                            sayiTut = maglubiyet[i];
                            maglubiyet[i] = maglubiyet[j];
                            maglubiyet[j] = sayiTut;

                            sayiTut = beraberlik[i];
                            beraberlik[i] = beraberlik[j];
                            beraberlik[j] = sayiTut;

                            sayiTut = oynadigiMac[i];
                            oynadigiMac[i] = oynadigiMac[j];
                            oynadigiMac[j] = sayiTut;

                            kelimeTut = takimIsmi[i];
                            takimIsmi[i] = takimIsmi[j];
                            takimIsmi[j] = kelimeTut;
                        }
                        else if (puanDurumu[i] == puanDurumu[j])
                        {
                            if ((atilanGol[i] - yenilenGol[i]) > (atilanGol[j] - yenilenGol[j]))
                            {
                                sayiTut = puanDurumu[i];
                                puanDurumu[i] = puanDurumu[j];
                                puanDurumu[j] = sayiTut;

                                sayiTut = atilanGol[i];
                                atilanGol[i] = atilanGol[j];
                                atilanGol[j] = sayiTut;

                                sayiTut = yenilenGol[i];
                                yenilenGol[i] = yenilenGol[j];
                                yenilenGol[j] = sayiTut;

                                sayiTut = galibiyet[i];
                                galibiyet[i] = galibiyet[j];
                                galibiyet[j] = sayiTut;

                                sayiTut = maglubiyet[i];
                                maglubiyet[i] = maglubiyet[j];
                                maglubiyet[j] = sayiTut;

                                sayiTut = beraberlik[i];
                                beraberlik[i] = beraberlik[j];
                                beraberlik[j] = sayiTut;

                                sayiTut = oynadigiMac[i];
                                oynadigiMac[i] = oynadigiMac[j];
                                oynadigiMac[j] = sayiTut;

                                kelimeTut = takimIsmi[i];
                                takimIsmi[i] = takimIsmi[j];
                                takimIsmi[j] = kelimeTut;
                            }
                        }
                    }
                }
            }
        }

        private static void KaybedilenMaclariHesapla(ref int[] oynadigiMac, ref int[] maglubiyet, int[] galibiyet, int[] beraberlik)
        {
            for (int i = 0; i < 4; i++)
            {
                oynadigiMac[i] = 6;
                maglubiyet[i] = oynadigiMac[i] - (galibiyet[i] + beraberlik[i]);
            }
        }

        private static void DeplasmandaOynananMaclirKiyasla(ref int[] atilanGol, ref int[] yenilenGol, ref int[] puanDurumu, ref int[] galibiyet, ref int[] beraberlik, int[,] macSonucuDep, int[,] macSonucuEv)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i != j)
                    {
                        atilanGol[j] += macSonucuDep[i, j];
                        yenilenGol[j] += macSonucuEv[i, j];
                        if (macSonucuEv[i, j] < macSonucuDep[i, j])
                        {
                            puanDurumu[j] += 3;
                            galibiyet[j]++;
                        }
                        else if (macSonucuEv[i, j] == macSonucuDep[i, j])
                        {
                            puanDurumu[j] += 1;
                            beraberlik[j]++;
                        }
                    }
                }
            }
        }

        private static void EvindeOynananMaclariKiyasla(ref int[] atilanGol, ref int[] yenilenGol, ref int[] puanDurumu, ref int[] galibiyet, ref int[] beraberlik, int[,] macSonucuDep, int[,] macSonucuEv)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        atilanGol[i] += macSonucuEv[i, j];
                        yenilenGol[i] += macSonucuDep[i, j];
                        if (macSonucuEv[i, j] > macSonucuDep[i, j])
                        {
                            puanDurumu[i] += 3;
                            galibiyet[i]++;
                        }
                        else if (macSonucuEv[i, j] == macSonucuDep[i, j])
                        {
                            puanDurumu[i] += 1;
                            beraberlik[i]++;
                        }
                    }
                }
            }
        }

        private static void MacSonuclari(string[] takimIsmi, int[,] macSonucuEv, int[,] macSonucuDep)
        {
            Random rnd = new Random();
            string[,] fikstur = new string[4,4];
            Console.WriteLine("---- FIKSTUR SONUCLARI ----");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        macSonucuEv[i, j] = rnd.Next(0, 4);
                        macSonucuDep[i, j] = rnd.Next(0, 4);
                        fikstur[i, j] = takimIsmi[i] + " " + Convert.ToString(macSonucuEv[i, j]) + ":" + Convert.ToString(macSonucuDep[i, j]) + " " + takimIsmi[j];
                        Console.WriteLine(fikstur[i, j]);
                    }
                }
            }
        }
    }
}
