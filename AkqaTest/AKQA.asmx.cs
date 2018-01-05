using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AkqaTest
{
    /// <summary>
    /// Summary description for AKQA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AKQA : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetPersonData(string name, string amount)
        {
            string AmountInWords = string.Empty;
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(amount))
            {
                decimal output;

                if (decimal.TryParse(amount.Replace(".", ","), out output))
                {
                    AmountInWords = NumberToWords(TryParsedecimal(amount.Replace(".", ","), decimal.MinValue));
                }

                else
                {
                    AmountInWords = "Unable to parse:" + amount;
                }
                return "Name - " + name + " | Amount - " + amount + "  | Amount in words - " + AmountInWords;
            }
            else
            {
                AmountInWords = "Fields Required - Please enter valid data !!";
                return AmountInWords;
            }
        }

        /// <summary>
        /// Parses the string as Decimal.
        /// It wont throw error. Instead it gives the ifFail value if error occurs
        /// </summary>
        public decimal TryParsedecimal(string input, decimal ifFail)
        {
            decimal output;

            if (decimal.TryParse(input, out output))
            {
                output = output;
            }

            else
            {
                output = ifFail;
            }

            return output;
        }

        /// <summary>
        /// Convert number into words.
        /// </summary>
        public static string NumberToWords(Decimal doubleNumber)
        {
            var beforeFloatingPoint = (int)Math.Floor(doubleNumber);
            var beforeFloatingPointWord = NumberToWords(beforeFloatingPoint) + " dollars ";
            var afterFloatingPointWord =
                SmallNumberToWord((int)((doubleNumber - beforeFloatingPoint) * 100), "") + " cents";
            return beforeFloatingPointWord + afterFloatingPointWord;

        }

        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += NumberToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            words = SmallNumberToWord(number, words);

            return words;
        }

        private static string SmallNumberToWord(int number, string words)
        {
            if (number <= 0) return words;
            if (words != "")
                words += " ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
            return words;
        }
    }
}
