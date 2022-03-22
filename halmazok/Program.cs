﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace halmazok
{
    // A és B típusú egész tömböket kell létrehozni.
    // Ezen tömbök elemeinek számát a felhasználó adja meg; ez 200-nál nagyobb nem lehet!
            // Amennyiben nagyobb abban az esetben a program generál egy számot 100 és 200 között és ez lesz az elemek száma.
    // A tömbök elemeinek értéke a [-100, 100] intervallumon kell, hogy szerepeljen! (random generált számok)

    // Metódusok:
        // Unió
        // Metszet
        // A-B halmaz
        // B-A halmaz

    class Halmazok
    {
        // Osztályváltozók
        private int elemekszama = 0,
            metszet2,
            elemszam;
        private int[] tombA,
            metszet,
            unio,
            AB,
            BA,
            tombB;
        private bool jeloles = false;

        public Halmazok() { }

        public void Feltoltes()
        {
            Random rnd = new Random();
            Console.WriteLine("Adja meg a tömb elemeinek számát:");
            elemszam = Convert.ToInt32(Console.ReadLine());
            if (elemszam > 200)
            {
                elemszam = rnd.Next(100, 200);
            }
            this.tombA = new int[elemszam];
            this.tombB = new int[elemszam];
            this.metszet = new int[elemszam * 2];
            this.unio = new int[elemszam * 2];
            this.AB = new int[elemszam];
            this.BA = new int[elemszam];
            for (int i = 0; i < elemszam; i++)
            {
                this.tombA[i] = rnd.Next(-100, 100);
                this.tombB[i] = rnd.Next(-100, 100);
            }
            Console.WriteLine("Az A halmaz elemei:");
            for (int i = 0; i < tombA.Length; i++)
            {
                Console.Write("{0} ", tombA[i]);
            }
            Console.WriteLine();
            Console.WriteLine("A B halmaz elemei:");
            for (int i = 0; i < tombB.Length; i++)
            {
                Console.Write("{0} ", tombB[i]);
            }
        }

        public void Metszet()
        {
            int k = 0;
            for (int i = 0; i < this.tombA.Length; i++)
            {
                for (int j = 0; j < this.tombB.Length; j++)
                {
                    if (this.tombA[i] == this.tombB[j])
                    {
                        this.metszet[k] = this.tombA[i];
                        k++;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("A metszet elemei: ");
            for (int l = 0; l < k; l++)
            {
                Console.Write("{0} ", this.metszet[l]);
            }
            this.jeloles = true;
        }

        public void ABhalmaz()
        {
            if (!this.jeloles)
            {
                Metszet();
            }
            int k = 0;
            bool paros = false;
            for (int i = 0; i < this.tombA.Length; i++)
            {
                paros = false;
                for (int j = 0; j < this.metszet.Length; j++)
                {
                    if (this.tombA[i] == this.metszet[j])
                    {
                        paros = true;
                        break;
                    }
                }
                if (!paros)
                {
                    this.AB[k] = this.tombA[i];
                    k++;
                }
            }
            Console.WriteLine("\nA\\B halmaz:");
            for (int x = 0; x < k; x++)
            {
                Console.Write("{0} ", this.AB[x]);
            }
        }

        public void BAhalmaz()
        {
            if (!this.jeloles)
            {
                Metszet();
            }
            int l = 0;
            bool paros = false;
            for (int i = 0; i < this.tombB.Length; i++)
            {
                paros = false;
                for (int j = 0; j < this.metszet.Length; j++)
                {
                    if (this.tombB[i] == this.metszet[j])
                    {
                        paros = true;
                        break;
                    }
                }
                if (!paros)
                {
                    this.BA[l] = this.tombB[i];
                    l++;
                }
            }
            Console.WriteLine("\nB\\A halmaz:");
            for (int x = 0; x < l; x++)
            {
                Console.Write("{0} ", this.BA[x]);
            }
        }

        public void Unio()
        {
            if (!this.jeloles)
            {
                Metszet();
            }
            int l = 0;
            bool paros = false;
            for (int i = 0; i < this.tombB.Length; i++)
            {
                paros = false;
                for (int j = 0; j < this.metszet.Length; j++)
                {
                    if (this.tombB[i] == this.metszet[j])
                    {
                        paros = true;
                        break;
                    }
                }
                if (!paros)
                {
                    this.BA[l] = this.tombB[i];
                    l++;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Halmazok a = new Halmazok();
            a.Feltoltes();
            a.Metszet();
            a.ABhalmaz();
            a.BAhalmaz();
            Console.ReadKey();
        }
    }
}
