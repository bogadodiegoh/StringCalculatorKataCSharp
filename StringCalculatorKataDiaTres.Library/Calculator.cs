using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKataDiaTres.Library
{
    public class Calculator
    {
        public int Add(string value)
        {
            int add;

            if (CheckIfIsEmptyString(value, out add)) return add;

            if (IsNegative(value))            
                throw new ArgumentException("negatives not allowed");
            
            var separators = GetSeparators(ref value);
                      
            var numbers = value.Split(separators,StringSplitOptions.None).Where(x => Convert.ToInt32(x) < 1001);
           return numbers.Sum(x => Convert.ToInt32(x));
        }

        private bool IsNegative(string value)
        {
            return value.IndexOf('-') == 0 && IsANumber(value.Substring(value.IndexOf('-')));
        }

        private bool IsANumber(string value)
        {
            int result;
            return Int32.TryParse(value,out result);
        }

        private static string[] GetSeparators(ref string value)
        {
            string[] separators;
            if (value.Contains("//"))
            {
                
                if (value.IndexOf('[') == 2)
                {
                    int i = 0;
                    separators = new string[GetSeparatorsNumber(value.Substring(2,value.IndexOf('\n') - 2))];
                    var sep = value.Substring(2, value.IndexOf('\n') - 2).Split('[', ']').Where(x => x != string.Empty);
                    foreach (var separator in sep)
                    {
                        separators[i] = separator;
                        i++;
                    }                   
                }                    
                else
                {
                    separators=new string[1];
                    separators[0] = value.Substring(2, value.IndexOf('\n') - 2);   
                }
                                                         
                value = value.Substring(value.IndexOf('\n'));
            }
            else
            {
                separators = new string[2];
                separators[0] = ",";
                separators[1] = "\n";
            }
            return separators;
        }

        private static int GetSeparatorsNumber(string value)
        {
            return value.Split('[',']').Count(x => x != string.Empty);
        }

        private static bool CheckIfIsEmptyString(string value, out int add)
        {
            add = 0;
            return value == string.Empty;
        }
    }
}
