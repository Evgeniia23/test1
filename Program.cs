using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the name of the path, where .csv file is:"); 
            var fileDirectory = Console.ReadLine(); // C:\Users\49178\source\repos\ConsoleAppTest1\ConsoleAppTest1
            Console.WriteLine("Please, enter the name of the .csv file with an extension:");
            var fileWithExtension = Console.ReadLine();
            var filename = Path.Combine(fileDirectory, fileWithExtension);       // C:\Users\49178\source\repos\ConsoleAppTest1\ConsoleAppTest1\data.csv     
            
            if (File.Exists(filename))
            {
                Console.WriteLine("The file exists.");
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }

            var filenameCalcExport = Path.Combine(fileDirectory, "data_calc_result.csv");
            var lines = File.ReadAllLines(filename, Encoding.UTF8);                   

            for (int index = 1; index < lines.Length; index++)
            {
                var line = lines[index];
                var values = line.Split(";");

                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                var value1 = Convert.ToDouble(values[1], provider);
                var value2 = Convert.ToDouble(values[2], provider);
                var calcOperator = values[3];

                var sumResult = value1 + value2;
                var calcResult = CalcValuesWithOperator(value1, value2, calcOperator);

                lines[index] = line + sumResult.ToString() + ";" + calcResult.ToString(); //"1;763.98;765.87;+;"+"23"+";"+"400" = "1;763.98;765.87;+;23;400"               
            }
            
            File.WriteAllLines(filenameCalcExport, lines);
        }        

        private static double CalcValuesWithOperator(double input1, double input2, string calcOperator)
        {
            double result = 0;

            if(calcOperator == "+")
            {
                result = Add(input1, input2);
            }
            else if(calcOperator == "-")
            {
                result = Subtract(input1, input2);
            }
            else if(calcOperator == "/")
            {
                result = Divide(input1, input2);
            }
            else if(calcOperator == "*")
            {
                result = Multiply(input1, input2);
            }

            return result;
        }

        private static double Add(double input1, double input2)
        {
            return input1 + input2;
        }

        private static double Subtract(double input1, double input2)
        {
            return input1 - input2;
        }

        private static double Multiply(double input1, double input2)
        {
            return input1 * input2;
        }

        private static double Divide(double input1, double input2)
        {
            return input1 / input2;
        }
    }
}
