using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_LABA_WF
{
    public class SupportingMethods
    {
        #region StringValue
        public string InputStringValue(string message)
        {
            Console.Write(message);
            string input;
            bool isRightinput = false;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Введите непустую строку.");
                }
                else
                {
                    input = DeleteJunkSpace(input);
                    isRightinput = true;
                }
                if (!isRightinput)
                {
                    Console.Write("Повторите ввод: ");
                }
            } while (!isRightinput);

            return input;
        }
        private string DeleteJunkSpace(string str)
        {
            char[] space = { ' ' };
            string[] arrayOfWords = str.Split(space, StringSplitOptions.RemoveEmptyEntries);

            string stringWithoutJunkSpace = "";

            foreach (string word in arrayOfWords)
            {
                stringWithoutJunkSpace += word;
                stringWithoutJunkSpace += " ";
            }
            return stringWithoutJunkSpace;
        }
        #endregion

        #region IntValue

        const int MIN_AVAILABLE_VALUE = 1;
        const int MAX_AVAILABLE_VALUE = 99;

        public int InputIntValue(string message)
        {
            Console.Write(message);
            bool isRightInput = false;
            int value;
            do
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out value))
                {
                    if (value > MAX_AVAILABLE_VALUE)
                    {
                        Console.WriteLine("Значение не может быть таким большим.");
                    }
                    if (value < MIN_AVAILABLE_VALUE)
                    {
                        Console.WriteLine("Значение не может быть таким маленьким.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите натуральное число.");
                }

                if (!isRightInput)
                {
                    Console.Write("Повторите ввод: ");
                }
            } while (!isRightInput);
            return value;
        }
        #endregion
    }
}
