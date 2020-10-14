﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
    class Customer
    {
        public string Name;
        public string State;
        public string Phone;

        public Customer(string n, string s, string p)
        {
            Name = n;
            State = s;
            Phone = p;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var customers = new List<Customer>();
            customers.Add(new Customer("Chandler", "OR", "555-555-5555"));
            customers.Add(new Customer("Monica", "CO", "555-666-6666"));
            customers.Add(new Customer("Joey", "CO", "555-777-7777"));
            customers.Add(new Customer("Ross", "NY", "555-000-0000"));
            customers.Add(new Customer("Phoebe", "NY", "555-111-1111"));
            customers.Add(new Customer("Rachel", "NJ", "555-222-2222"));

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string[] numNames = { "nulla", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };

            //5 alatti számok kiíratása
            var otAlatt = from n in numbers where n < 5 orderby n descending select n;

            var ujTomb = otAlatt.ToList();
            //var ujTomb = otAlatt.ToArray();
            //Azonnali kiértékelés --> átalakítás

            foreach (var o in ujTomb)
            {
                Console.Write($"{o}, ");
            }

            // Kik laknak "CO" állmaban?
            var coState = from c in customers where c.State == "CO" orderby c.Name select c;
            Console.WriteLine("\n'CO' államban élők");
            foreach (var c in coState)
            {
                Console.WriteLine($"{c.Name,6} -- {c.State}");
            }

            // számok értéke növelve 2-vel
            var kettovel = from n in numbers select n + 2;

            var kettotomb = kettovel.ToArray();

            for (int i = 0; i < kettotomb.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} --> {kettotomb[i]}");
            }



            // A Customer-ből csak név és telefonszám kell --> anonim objektum típus felhasználása

            var namePhone = from p in customers orderby p.Name descending select p;
            foreach (var f in namePhone)
            {
                Console.WriteLine($"{ f.Name} - {f.Phone}");
            }

            // számokból --> szöveg

            int[] Tomb = { 2, 4, 0, 1, 9, 6 };

            var szoveges = from u in Tomb select numNames[u];
            Console.WriteLine();
            foreach (var i in szoveges)
            {
                Console.Write($"{i}, ");
            }

            // csoportosítás ű
            var nevek = from c in customers select c.Name;
            var nevLista = nevek.ToList();

            var kezdoBetu = from n in nevLista
                            orderby n
                            where n[0] != 'R'
                            group n by n[0] into tempNevek
                            select tempNevek;


            Console.WriteLine("\nCsoportosítás kezdőbetű szerint");
            foreach (var csoport in kezdoBetu)
            {
                Console.WriteLine("Kezdőbetű: {0}", csoport.Key);
                foreach (var csoportTag in csoport)
                {
                    Console.WriteLine($"\t{csoportTag}");
                }
            }
            Console.ReadLine();
        }

    }

}
