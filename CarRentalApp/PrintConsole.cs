using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp
{
    class PrintConsole
    {
        public static void MainBanner()
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine("1980's Enterprise Car Rental");
            PrintConsole.BannerBar();
        }

        public static void AccountBanner(string loginEmailAddress)
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine($"Welcome back, this is your account menu");  //Want to add the {CustomerAccounts.GetAllAccounts.CustomerName) to the string
            PrintConsole.BannerBar();
        }

        public static void AccountCreationBanner()
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine("Account Creation Menu");
            PrintConsole.BannerBar();
        }
        public static void ReservationBanner()
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine("Reserve a Vehicle");
            PrintConsole.BannerBar();
        }
        public static void AllReservationsBanner()
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine("Printing all reservations...");
            PrintConsole.BannerBar();
        }
        public static void AllAccountsBanner()
        {
            Console.Clear();
            PrintConsole.BannerBar();
            Console.WriteLine("Printing all accounts...");
            PrintConsole.BannerBar();
        }

        public static void AccountMenu()
        {
            Console.WriteLine("1:  Basic Info");
            Console.WriteLine("2:  Reserve a Car");
            Console.WriteLine("3:  View current reservation");
            Console.WriteLine("4:  Picking up");
            Console.WriteLine("5:  Dropping off");
            Console.WriteLine("6:  Return to Main Menu");
            PrintConsole.BannerBar();
            PrintConsole.OptionInput();
        }
        
        public static void MainMenu()
        {
            Console.WriteLine("1:  Create new account");
            Console.WriteLine("2:  Log into existing account");
            Console.WriteLine("3:  Exit");
            PrintConsole.BannerBar();
            PrintConsole.OptionInput();
        }
               


        public static void BannerBar()
        {
            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine();
        }

        public static void MyReservations(string email)
        {
            var reservations = RentalAgreement.GetMyRentalAgreements(email);
            foreach (var getreservations in reservations)
            {

                Console.WriteLine($"Pickup date:       {getreservations.DateOfPickup},");
                Console.WriteLine($"Return date:       {getreservations.DateOfReturn},");
                Console.WriteLine($"Pickup location:   {getreservations.LocationToPickup},");
                Console.WriteLine($"Return location:   {getreservations.LocationToDropOff},");
                Console.WriteLine($"Destination:       {getreservations.Destination},");
                Console.WriteLine($"Drivers:           {getreservations.Drivers}");
                Console.WriteLine();
            }
        }

        public static void AllReservations()
        {
            var reservations = RentalAgreement.GetAllReservations();
            foreach (var getreservations in reservations)
            {

                Console.WriteLine($"Pickup date:       {getreservations.DateOfPickup},");
                Console.WriteLine($"Return date:       {getreservations.DateOfReturn},");
                Console.WriteLine($"Pickup location:   {getreservations.LocationToPickup},");
                Console.WriteLine($"Return location:   {getreservations.LocationToDropOff},");
                Console.WriteLine($"Destination:       {getreservations.Destination},");
                Console.WriteLine($"Drivers:           {getreservations.Drivers}");
                Console.WriteLine();
            }
        }

        public static void OptionInput()
        {
            Console.Write("Select an option:  ");
        }
        
    }
}
