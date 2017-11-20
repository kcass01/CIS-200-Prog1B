// Program 1A
// CIS 200-01/76
// Fall 2017
// Due: 9/25/2017
// By: D7010

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Joseph Mccoy", "631 Plateau Avenue", 
                "Portland", "OR", 56732); // Test Address 5
            Address a6 = new Address("Allison Devers", "1009 Garland Avenue",
                "Palmetto", "GA", 91110); // Test Address 6
            Address a7 = new Address("Lou Fields", "12 Henery St.", 
                "Phoenix", "AZ", 19284); // Test Address 7
            Address a8 = new Address("Michael Cruz", "908 Freedom Rd.", "Apt. 23",
                "Independence", "KY", 41033); // Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object 1
            Letter letter2 = new Letter(a8, a6, 4.56M);                            // Letter test object 2
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object 1
            GroundPackage gp2 = new GroundPackage(a7, a5, 5, 6, 4.5, 1.5);        // Ground test object 2
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object 1
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a8, 20, 6, 3, 6.0, 12.5M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object 1
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a6, a2,4.5, 12.7, 5.5, // Two Day test object 2
                5.1, TwoDayAirPackage.Delivery.Early);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2); // Populate list
            parcels.Add(gp2);
            parcels.Add(ndap2);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }


            Console.WriteLine("Ordered By Destination ZIP:");
            Console.WriteLine("====================");
            //variable to hold linq ordered by zip
            //ordered list by zip code returned
            var orderByZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;
            //foreach loop to print ordered by destination zip
            foreach (Parcel p in orderByZip)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }

            Console.WriteLine("Ordered By Cost:");
            Console.WriteLine("====================");
            //variable to hold linq ordered by cost
            //ordered list based on the calc cost method returned
            var orderByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;
            //foreach loop to print the cost sorted search
            foreach (Parcel p in orderByCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }

            Console.WriteLine("Ordered By Type:");
            Console.WriteLine("====================");
            //variable to hold linq ordered by first type and then cost
            //ordered list byt type then cost returned
            var orderByType =
                from p in parcels
                orderby p.GetType().ToString() ascending, p.CalcCost() descending
                select p;
            //foreach loop prints ordered output to console.
            foreach (Parcel p in orderByType)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }

            Console.WriteLine("Selecting Heavy Air Package:");
            Console.WriteLine("====================");
            //variable to hold linq ordered by weight, only of heavy air type.
            //ordered list by weight of only heavy air packages returned
            var onlyHeavyAir =
                from p in parcels
                where p is AirPackage
                let a = (AirPackage)p
                where a.IsHeavy()
                orderby a.Weight descending
                select a;
            //foreach loop to print output to console
            foreach (Parcel a in onlyHeavyAir)
            {
                Console.WriteLine(a);
                Console.WriteLine("====================");
            }

            Pause();
       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
