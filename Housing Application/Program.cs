using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    public class HousingAffordabilty
{
    double grossMonthlyIncome;
    double estimatedMonthlyTax;
    String tenant;
    private double homeLoanRepayment;
    double rent;



    public HousingAffordabilty(double grossMonthlyIncome, double estimatedMonthlyTax, string tenant)
    {

        this.grossMonthlyIncome = grossMonthlyIncome;
        this.tenant = tenant;
        this.estimatedMonthlyTax = estimatedMonthlyTax;

    }

    public double getMI()
    {

        Console.WriteLine("Enter your total monthly income before deductions");
        grossMonthlyIncome = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(" ");

        return grossMonthlyIncome;

    }

    public double getMT()
    {

        Console.WriteLine("Enter your total monthly tax deducted from income");
        estimatedMonthlyTax = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(" ");
        return estimatedMonthlyTax;

    }


    public void getTenant()
    {

        Console.WriteLine("Would you like to rent accomodation or buy property");
        Console.WriteLine("1. Rent accomodation");
        Console.WriteLine("2. Buy property");
        Console.WriteLine(" ");
        tenant = Console.ReadLine();

        if (tenant != "1" && tenant != "2")
        {
            Console.WriteLine("Invalid input. Please eneter either 1 or 2");
            getTenant();

        }

    }



    public double buyingProperty()
    {
        Console.WriteLine("what is the total cost of the property.");
        double propertyCost = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("how much do you want to pay as a down payment");
        double downPayment = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("what is the interest rate of the home loan");
        double interestRate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("what is the duration of the Home loan in months");
        double numMonths = Convert.ToDouble(Console.ReadLine());

        double monthlyInterestRate = (interestRate / 100) / 12;
        double newCost = propertyCost - downPayment;


        double MonthlyHomeLoanRepayment = (newCost / numMonths) + monthlyInterestRate;

        homeLoanRepayment = Math.Round(MonthlyHomeLoanRepayment, 2);

        Console.WriteLine("your monthly home loan repayment is " + Math.Round(MonthlyHomeLoanRepayment, 2));

        return MonthlyHomeLoanRepayment;
    }



    public void userChoice()
    {
        switch (tenant)
        {
            case "1":
                Console.WriteLine("How much will the monthly rent be?");
                rent = Convert.ToDouble(Console.ReadLine());
                break;

            case "2":
                buyingProperty();
                break;

            default:
                Console.WriteLine("Invalid input for tenant type. Please enter 1 or 2");
                getTenant();
                userChoice();
                break;


        }
    }




    public void affordabilityCheck()
    {
        if (tenant.Equals("2"))
        {

            MonthlyExpenditures expenditures = new MonthlyExpenditures(0, 0, 0, 0);

            double total = expenditures.getMonthlyExpenditure();

            double finalIncome = grossMonthlyIncome - estimatedMonthlyTax - total;

            double oneThirdofFinalIncome = grossMonthlyIncome / 3;

            double repayment = homeLoanRepayment;

            if (repayment > oneThirdofFinalIncome)
            {

                Console.WriteLine("Your  gross monthly income is R" + grossMonthlyIncome);
                Console.WriteLine("A third of that is R" + Math.Round(oneThirdofFinalIncome, 2));
                Console.WriteLine("The home loan approval is unlikey, repayment amount exceeds one-third of the gross monthly income");
            }

            else
            {
                Console.WriteLine("Your  gross monthly income is R" + grossMonthlyIncome);
                Console.WriteLine("A third of that is R" + Math.Round(oneThirdofFinalIncome, 2));
                Console.WriteLine("The home loan approval is possible, repayment amount does not exceed one-third of the gross monthly income");
            }
        }

        else if (tenant.Equals("1"))
        {
            MonthlyExpenditures expenditures = new MonthlyExpenditures(0, 0, 0, 0);

            double total = expenditures.getMonthlyExpenditure();

            double finalIncome = grossMonthlyIncome - estimatedMonthlyTax - total - rent;


            Console.WriteLine("your Gross monthly income is R" + grossMonthlyIncome);
            Console.WriteLine("your estimated tax is R" + estimatedMonthlyTax);
            Console.WriteLine(" your monthy expenditures is R" + expenditures);


            if (finalIncome > 0)
            {
                Console.WriteLine("you can afford to rent");
            }

            else if (finalIncome < 0)
            {
                Console.WriteLine("you cannot afford to rent");
            }


        }


    }

    public void availableMonthlyMoney()
    {
        if (tenant.Equals("2"))
        {

            MonthlyExpenditures expenditures = new MonthlyExpenditures(0, 0, 0, 0);

            double total = expenditures.getMonthlyExpenditure();

            double finalIncome = grossMonthlyIncome - estimatedMonthlyTax - total;

            double repayment = homeLoanRepayment;

            double availableMoney = finalIncome - repayment;

            Console.WriteLine("Monthly expenditures: R" + total);
            Console.WriteLine("Estimated Monthly tax: R" + estimatedMonthlyTax);
            Console.WriteLine("Home loan: R" + repayment);
            Console.WriteLine(" you will be left with R" + availableMoney + " after all expenditures");


        }

        else if (tenant.Equals("1"))
        {

            MonthlyExpenditures expenditures = new MonthlyExpenditures(0, 0, 0, 0);

            double total = expenditures.getMonthlyExpenditure();

            double finalIncome = grossMonthlyIncome - estimatedMonthlyTax - total;

            double availableMoney = finalIncome - rent;

            Console.WriteLine("Monthly expenditures: R" + total);
            Console.WriteLine("Estimated Monthly tax: R" + estimatedMonthlyTax);
            Console.WriteLine("Rent is: R" + rent);
            Console.WriteLine(" you will be left with R" + availableMoney + " after all expenditures");

        }


    }


    static void Main(string[] args)
    {

        HousingAffordabilty user = new HousingAffordabilty(0, 0, "1");

        Console.WriteLine("Welcome to Housing Affordability Tactics");
        Console.WriteLine("1. Start");
        Console.WriteLine("2. Exit");
        String ans = Console.ReadLine();

        if (ans == "1")
        {
            user.getMI();
            Console.WriteLine(" ");
            user.getMT();
            Console.WriteLine(" ");
            user.getTenant();
            Console.WriteLine(" ");
        }

        else if (ans == "2")
            System.Environment.Exit(0);

        else
        {
            Console.WriteLine("Incorrect input");
            Main(args);
        }

        user.userChoice();

        section2();

        void section2()
        {

            Console.WriteLine("what would you like to do next?");
            Console.WriteLine("1. Check Affordability");
            Console.WriteLine("2. Available monthly money");
            String ans1 = Console.ReadLine();

            if (ans1 == "1")
            {
                user.affordabilityCheck();
            }
            else if (ans1 == "2")
            {
                user.availableMonthlyMoney();
            }
            else { section2(); }
        }







    }


}



