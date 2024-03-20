using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    internal class MonthlyExpenditures
    {
        double transportation;
        double groceries;
        double utilities;
        double total;




        public MonthlyExpenditures(double trasportation, double groceries, double utilities, double total)
        {
            this.transportation = trasportation;
            this.groceries = groceries;
            this.utilities = utilities;
            this.total = 0;
        }
        public double getMonthlyExpenditure()
        {
            Console.WriteLine("How much do you spend on groceries a month?");
            groceries = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("How much do you spend on utilities a month?");
            utilities = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("How much do you spend on transportation a month?");
            transportation = Convert.ToDouble(Console.ReadLine());

            total = transportation + groceries + utilities;

            return total;

        }
    }


