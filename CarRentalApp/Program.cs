using System;

namespace CarRentalApp
{
    class Program
    {

        static void Main(string[] args)
        {

            ConsoleMainMenu();
            
        }

        public static void ConsoleMainMenu()
        {
            bool active = true;
            while (active == true)
            {
                PrintConsole.MainBanner();
                PrintConsole.MainMenu();

                var option = Console.ReadLine();

                switch (option)
                {
                    
                    case "1":
                        //Create account
                        PrintConsole.AccountCreationBanner();

                        Console.WriteLine("Enter first name:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name:");
                        var lastName = Console.ReadLine();
                        var fullName = firstName + " " + lastName;

                        Console.WriteLine("Enter Address:");
                        var customerAddress = Console.ReadLine();

                        Console.WriteLine("Enter Phone Number:");
                        var customerPhoneNumber = Console.ReadLine();

                        Console.WriteLine("Enter Email Address: ");
                        var customerEmailAddress = Console.ReadLine();

                        Console.WriteLine("Enter your drivers License number:");
                        var customerDriversLicenseNumber = Console.ReadLine();

                        Console.WriteLine("Enter your rental credit card:");
                        var customerCreditCardNumber = Console.ReadLine();

                        //CreateAccount(string customerName, string customerAddress, string customerPhoneNumber, string customerEmailAddress, string driverLicenseNumber, int customerCreditCardNumber
                        var account = CustomerAccounts.CreateAccount(fullName, customerAddress, customerPhoneNumber, customerEmailAddress, customerDriversLicenseNumber, customerCreditCardNumber);

                        break;

                    case "2":
                        //Log into existing account
                        Console.Clear();
                        PrintConsole.AllAccountsBanner();

                        Console.Write("Please login using your email address: ");
                        var loginEmailAddress = Console.ReadLine();
                        //if (loginEmailAddress == null)
                        //{
                        //    Console.WriteLine("Please input valid Email Address.");
                        //    ConsoleMainMenu();
                        //}
                        //if (loginEmailAddress != null)
                        //{
                            ConsoleCustomerMenu(loginEmailAddress);
                        //}
                        break;

                    case "3":
                        // Exit
                        active = false;
                        break;
                }
            }
        }


        public static void ConsoleCustomerMenu(string loginEmailAddress)
        {
            
            string email = loginEmailAddress;
            bool active = true;
            while (active == true)
            {

                Console.Clear();
                PrintConsole.AccountBanner(email);
                PrintConsole.AccountMenu();
                    // I think this is where the swtich for PrintAccountMenu should be
                    var accountoption = Console.ReadLine();

                    switch (accountoption)
                    {

                    case "1":

                        //Basic Info
                        //CustomerAccounts.EditAccount
                        //Remember to include the insurance part
                        PrintConsole.AllAccountsBanner();
                        
                        
                        PrintAllAccounts(email);

                        Console.ReadLine();
                        ConsoleCustomerMenu(loginEmailAddress);
                        break;


                    case "2":

                        //Reserve a car
                        //RentalAgreement.Reservation
                        PrintConsole.ReservationBanner();

                        Console.WriteLine("What type of vehicle would you like?");
                        var rentalClass = Enum.GetNames(typeof(VehicleRentalClassification));
                        for (var i = 0; i < rentalClass.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {rentalClass[i]}");
                        }
                        Console.Write("Select number: ");
                        var rentalClassType = Convert.ToInt32(Console.ReadLine());  // This will cause an exception if not number
                        var vehicleRentalClassSelected = (VehicleRentalClassification)Enum.Parse(typeof(VehicleRentalClassification), rentalClass[rentalClassType - 1]);



                        Console.WriteLine("Enter desired pickup date and time mm/dd/yy 'time': ");
                        DateTime dateOfPickup = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine(dateOfPickup);

                        Console.WriteLine("Pick one of our terrible branches to pickup at:");
                        var rentalLocations = Enum.GetNames(typeof(RentalLocations));
                        for (var i = 0; i < rentalLocations.Length; i++)
                        {
                            Console.WriteLine($"{ i + 1}. {rentalLocations[i]}");
                        }
                        var pickuplocation = Convert.ToInt32(Console.ReadLine());
                        var locationToPickup = (RentalLocations)Enum.Parse(typeof(RentalLocations), rentalLocations[pickuplocation - 1]);

                        Console.WriteLine("Enter desired return date and time mm/dd/yy 'time': ");
                        DateTime dateOfReturn = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine(dateOfReturn);

                        Console.WriteLine("Pick one of our disgusting branches to return to:");
                        for (var i = 0; i < rentalLocations.Length; i++)
                        {
                            Console.WriteLine($"{ i + 1}. {rentalLocations[i]}");
                        }
                        var returnlocation = Convert.ToInt32(Console.ReadLine());
                        var locationToDropOff = (RentalLocations)Enum.Parse(typeof(RentalLocations), rentalLocations[returnlocation - 1]);

                        Console.WriteLine("Please let us know what city you are headed with the vehicle:");
                        var destination = Console.ReadLine();

                        Console.WriteLine("Please provide the names of the drivers:");
                        var drivers = Console.ReadLine();

                        //Reservation(DateTime dateOfPickup, string locationToPickup, DateTime dateOfReturn, string locationtoDropOff, string destination, string drivers)
                        //RentalAgreement.Reservation();
                        RentalAgreement.Reservation(dateOfPickup, locationToPickup, dateOfReturn, locationToDropOff, destination, drivers,email);
                        
                        ConsoleCustomerMenu(email);
                        break;

                    case "3":

                        //Current reservation

                        PrintConsole.AllReservationsBanner();
                        PrintConsole.MyReservations(email);
                        Console.ReadLine();
                        ConsoleCustomerMenu(email);
                        break;

                    case "4":

                        //Pickup
                        //RentalAgreement.CheckOutVehical
                        //Need to have a check to make sure that this is completed
                        //InsuranceInformation.PolicyInformation
                        ConsoleCustomerMenu(email);
                        break;



                    case "5":

                        //Dropoff
                        //RentalAgreement.CheckInVehicle
                        ConsoleCustomerMenu(email);
                        break;
                    
                        //Return to main menu

                    case "6":
                        ConsoleMainMenu();
                        active = false;
                        break;
                    }
                    break;
            }
        }
        private static void PrintAllAccounts(string emailAddress)
        {
            var accounts = CustomerAccounts.GetAllAccounts(emailAddress);
            foreach (var getaccount in accounts)
            {
                {
                    Console.WriteLine($"Account Number: {getaccount.CustomerAccountNumber},");
                    Console.WriteLine($"Name:           {getaccount.CustomerName},");
                    Console.WriteLine($"Address:        {getaccount.CustomerAddress},");
                    Console.WriteLine($"Phone Number:   {getaccount.CustomerPhoneNumber},");
                    Console.WriteLine($"Email:          {getaccount.CustomerEmailAddress},");
                    Console.WriteLine($"Credit Card:    {getaccount.CustomerCreditCardNumber}");
                    Console.WriteLine();
                }
            }
        }
    }

}
