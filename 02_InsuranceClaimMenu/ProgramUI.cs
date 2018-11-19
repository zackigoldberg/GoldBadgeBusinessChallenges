using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_InsuranceClaimMenu
{
    class ProgramUI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();
        public void Run()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.WriteLine("Choose a menu item \n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim");
                int input = GetInput();
                switch (input)
                {
                    case 1:
                        ShowClaims();
                        Console.Clear();
                        break;
                    case 2:
                        TakeClaim();
                        Console.Clear();
                        break;
                    case 3:
                        NewClaim();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid input please try again");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
            }
        }

        private void NewClaim()
        {
            Claim newClaim = new Claim();

            Console.Write("ClaimID: ");
            newClaim.ClaimID = GetInput();

            Console.Write("Type: ");
            newClaim.ClaimType = Console.ReadLine();

            Console.Write("Description: ");
            newClaim.Description = Console.ReadLine();

            Console.Write("Amount: $");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Write("DateOfAccident: ");
            newClaim.DateOfIncident = DateConverter();

            Console.Write("DateOfClaim: ");
            newClaim.DateOfClaim = DateConverter();

            int days = newClaim.DateOfClaim.Day - newClaim.DateOfIncident.Day;
            if (days <= 30)
            {
                Console.WriteLine("This claim is valid");
                newClaim.IsValid = true;
            }
            else
            {
                Console.WriteLine("This claim is invalid");
                newClaim.IsValid = false;
            }
            _claimRepository.NewClaim(newClaim);
            Console.ReadLine();

        }
        private DateTime DateConverter()
        {
            string input = Console.ReadLine();
            DateTime dateTime;
            if (DateTime.TryParse(input, out dateTime))
            {
                return dateTime;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                return DateConverter();
            }

        }
        private void TakeClaim()
        {
            Queue<Claim> claimList = _claimRepository.DisplayClaims();
            Claim claim = claimList.First();
            Console.WriteLine($"Here are the details for the next claim to be handled: \n" +
                $"ClaimId: {claim.ClaimID}\n" +
                $"Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident.Date}\n" +
                $"DateOfClaim: {claim.DateOfClaim.Date}\n" +
                $"IsValid: {claim.IsValid}\n");
            Console.WriteLine(" Do you want to deal with this claim now(y/n)?");

            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                _claimRepository.RemoveClaim();
            }
            Console.ReadLine();
        }
        private void ShowClaims()
        {

            Console.WriteLine($"{"Claim Id",-15} {"Type",-15} {"Description",-15} {"Amount",-15} {"DateOfAccident",-15} {"DateOfClaim",-15} {"IsValid",-15}");
            foreach (Claim claim in _claimRepository.DisplayClaims())
            {
                Console.WriteLine($" {claim.ClaimID,-14} {claim.ClaimType,-14} {claim.Description,-14} ${claim.ClaimAmount,-14} {claim.DateOfIncident.ToShortDateString(),-15} {claim.DateOfClaim.Date.ToShortDateString(),-15} {claim.IsValid,-15}");
            }
            Console.ReadLine();
        }
        public int GetInput()
        {
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            return input;
        }
        // Abadndoned piece of code, saved for later...private bool DateToBool()
        //{
        //    var daysAsTimeSpan = newClaim.DateOfClaim - newClaim.DateOfIncident;
        //    int days = daysAsTimeSpan.Days;
        //    if (days <= 30)
        //    {
        //        Console.WriteLine("This claim is valid");
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("This claim is invalid");
        //        return false;
        //    }
        //}
    }
}
