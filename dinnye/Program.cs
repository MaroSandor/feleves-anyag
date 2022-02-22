﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinnye
{
    class Program
    {
        static void Main(string[] args)
        {
            // Változók
            double szalaghossz,
                atmero,
                masni = 60;

            // Bekérés

            Console.WriteLine("Kérem a dinnye átmérőjét!");
            atmero = int.Parse(Console.ReadLine());

            // Számítás

            szalaghossz = (2 * (Math.Pow((atmero/2), 2) * Math.PI) + masni) / 1000;

            Console.WriteLine("A szalag hossza: {0} méter.", szalaghossz);
            Console.ReadKey();
        }
    }
}
