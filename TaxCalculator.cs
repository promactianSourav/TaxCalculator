using System;
using System.Runtime.InteropServices.ComTypes;

namespace SimpleTaxCalculator
{
    public class TaxCalculator
    {
        private double Salary { get; set; }
        private int Age { get; set; }

        public TaxCalculator(double _salary,int _age)
        {
            Salary = _salary;
            Age = _age;
        }

        

        //for age <= 60
        private double citizenFirstSlab = 0;
        private double citizenSecondSlab = 5;
        private double citizenThirdSlab = 20;
        private double citizenFourthSlab = 30;

        //for age > 60 and age <= 80
        private double seniorcitizenFirstSlab = 0;
        private double seniorcitizenSecondSlab = 5;
        private double seniorcitizenThirdSlab = 20;
        private double seniorcitizenFourthSlab = 30;

        //for age > 80 
        private double veryseniorcitizenFirstSlab = 0;
        private double veryseniorcitizenSecondSlab = 20;
        private double veryseniorcitizenThirdSlab = 30;

        public double CalculateTax()
        {
            double tax = 0;
            if (Age <= 60)
            {
                if (Salary <= 250000)
                {
                    tax = (Salary * citizenFirstSlab / 100);
                }else if(Salary <= 500000)
                {
                    tax = (Salary - 250000) * citizenSecondSlab / 100
                        + (250000 * citizenFirstSlab / 100);
                }else if(Salary <= 1000000)
                {
                    tax = (Salary - 500000)*citizenThirdSlab / 100 
                        + (250000 * citizenSecondSlab / 100)
                        + (250000 * citizenFirstSlab / 100);
                }
                else
                {
                    tax = (Salary - 1000000) * citizenFourthSlab / 100 
                        + ( 500000 * citizenThirdSlab / 100)
                        + ( 250000 * citizenSecondSlab / 100)
                        + ( 250000 * citizenFirstSlab / 100);
                }
            }else if( Age <= 80)
            {
                if (Salary <= 300000)
                {
                    tax = (Salary * seniorcitizenFirstSlab / 100);
                }
                else if (Salary <= 500000)
                {
                    tax = (Salary - 300000) * seniorcitizenSecondSlab / 100
                        + (300000 * seniorcitizenFirstSlab / 100);
                }
                else if (Salary <= 1000000)
                {
                    tax = (Salary - 500000) * seniorcitizenThirdSlab / 100
                        + (200000 * seniorcitizenSecondSlab / 100)
                        + (300000 * seniorcitizenFirstSlab / 100);
                }
                else
                {
                    tax = (Salary - 1000000) * seniorcitizenFourthSlab / 100
                        + (500000 * seniorcitizenThirdSlab / 100)
                        + (200000 * seniorcitizenSecondSlab / 100)
                        + (300000 * seniorcitizenFirstSlab /100);
                }
            }else
            {
                if (Salary <= 500000)
                {
                    tax = (Salary * veryseniorcitizenFirstSlab / 100); ;
                }
                else if (Salary <= 1000000)
                {
                    tax = (Salary - 500000) * veryseniorcitizenSecondSlab / 100
                        + (500000 * veryseniorcitizenFirstSlab / 100);
                }
                else
                {
                    tax = (Salary - 1000000) * veryseniorcitizenThirdSlab / 100
                        + (500000 * veryseniorcitizenSecondSlab / 100)
                        + (500000 * veryseniorcitizenFirstSlab / 100);
                }
            }

            return tax;
        }
        
        static void Main(string[] args)
        {
          
            //For avoiding Salary <= 0, only Salary > 0 is valid
            double yourSalary;
            do
            {
                Console.Write("Enter your Salary(Rupees):");
                yourSalary = double.Parse(Console.ReadLine());
                if (yourSalary <= 0)
                {
                    Console.WriteLine("Please!...Enter the valid Salary amount.");
                }

            } while (yourSalary <= 0);
            
            //for avoiding Age <=0, only Age > 0 is valid
            int yourAge ;
            do
            {
                Console.Write("Enter your Age:");
                yourAge = int.Parse(Console.ReadLine());
                if (yourAge <= 0)
                {
                    Console.WriteLine("Please!...Enter the valid Age.");
                }

            } while (yourAge <= 0);

            TaxCalculator taxCalculator = new TaxCalculator(yourSalary, yourAge);
            double tax = taxCalculator.CalculateTax();
            Console.WriteLine($"Your Total payable income tax is {tax} (in Rupees).");
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
