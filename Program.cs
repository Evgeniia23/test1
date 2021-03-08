using System;
using System.IO;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var filename = Path.Combine(currentDirectory, "data.csv");            
            var filenameCalcExport = Path.Combine(currentDirectory, "data_calc_result.csv");
            var lines = File.ReadAllLines(filename, Encoding.UTF8);                   

            for (int index = 1; index < lines.Length; index++)
            {
                var line = lines[index];
                var values = line.Split(";");                
                var value1 = Convert.ToDouble(values[1]);
                var value2 = Convert.ToDouble(values[2]);
                var calcOperator = values[3];

                var sumResult = value1 + value2;
                var calcResult = CalcValuesWithOperator(value1, value2, calcOperator);

                lines[index] = line + sumResult.ToString() + ";" + calcResult.ToString();                
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
