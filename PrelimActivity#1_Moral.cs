/*
=========================================================
Fuel Tracking Performance and Expense Monitoring System
Justine Carlo R. Moral
BSIT 3.2

Concepts Used:
- Data Types: string, int, double, decimal, bool
- Input/Output: Console.ReadLine() and String Interpolation ($"")
- Validation: while loop for distance range checking
- Data Structure: 1D array for 5-day fuel expenses
- Control Flow: for loop and if/else statements
=========================================================
*/


using System;

class Program
{
    static void Main()
    {

        // DRIVER PROFILE INPUT

        Console.WriteLine("\n------ DRIVER PROFILE ------");

        string driverName; // I used string for the driver name
        while (true)  // To ensure the driver full name contains letters and spaces only
        {
            Console.Write("Enter your Driver Full Name: ");
            driverName = Console.ReadLine();
            bool isValidName = true;

            foreach (char c in driverName)
            {
                // I used if condition to display a error if the character dont have letter
                if (!char.IsLetter(c) && c != ' ')
                {
                    isValidName = false;
                    break;
                }
            }

            if (isValidName && driverName.Length > 0)
            {
                break; // This will exit the while looop if the user input his/her name correctly
            }

            Console.WriteLine("ERROR! Your name must only contain letters (no numbers or symbols).");
        }

        
        // WEEKLY FUEL BUDGET INPUT
        
        decimal weeklyBudget;
        Console.WriteLine("\n------ Weekly Fuel Budget ------");
        Console.Write("Enter your Weekly Fuel Budget: ");

        // I used while lopp to ensure that there is a valid numeric input
        while (!decimal.TryParse(Console.ReadLine(), out weeklyBudget))
        {
            Console.Write("ERROR!. Please enter a valid number: ");
        }

        
        // TOTAL DISTANCE INPUT

        double totalDistance;  // double for numeric distance values

        while (true)
        {
            Console.Write("Enter Total Distance Traveled (1 - 5000 km): ");

            if (double.TryParse(Console.ReadLine(), out totalDistance) &&
                totalDistance >= 1.0 && totalDistance <= 5000.0)
            {
                break; // Exit loop if distance is valid
            }

            Console.WriteLine("ERROR! The Distance must be between 1 and 5000 km only.");
        }

        
        // FUEL EXPENSE TRACKING

        int numberOfDays = 5; // int to count the number of days
        decimal[] fuelExpenses = new decimal[numberOfDays]; // 1D array for fuel expenses
        decimal totalFuelSpent = 0;

        for (int i = 0; i < numberOfDays; i++)
        {
            Console.Write($"Enter your fuel expense for Day {i + 1}: ");

            while (!decimal.TryParse(Console.ReadLine(), out fuelExpenses[i]))
            {
                Console.Write("ERROR! Please Enter a valid number: ");
            }
                
            totalFuelSpent += fuelExpenses[i];
        }


        // FUEL PERFORMANCE ANALYSIS

        decimal averageDailyExpense = totalFuelSpent / numberOfDays;
        double efficiency = 0;

        if (totalFuelSpent != 0) // Prevent division by zero
        {
            efficiency = totalDistance / (double)totalFuelSpent;
        }

        string efficiencyRating;

        if (efficiency > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (efficiency >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        bool isUnderBudget = totalFuelSpent <= weeklyBudget;


        // WEEKLY AUDIT REPORT

        Console.WriteLine("\n------ WEEKLY FUEL AUDIT REPORT ------");
        Console.WriteLine($"Driver Name: {driverName}");

        for (int i = 0; i < numberOfDays; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]:C}");
        }

        Console.WriteLine("\n------ WEEKLY FUEL SUMMARY ------");
        Console.WriteLine($"Total Fuel Spent: {totalFuelSpent:C}");
        Console.WriteLine($"Average Daily Expense: {averageDailyExpense:C}");
        Console.WriteLine($"Total Distance: {totalDistance} km");
        Console.WriteLine($"Fuel Efficiency: {efficiency:F2}");
        Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");
    }
}
