using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCalculator.Models
{
    class Model
    {
        public string OperationLabelAddChar(string text, char toAdd)
        {
            if (toAdd == ',')
                return OperationLabelAddComa(text);
            if (text == "0")
                return toAdd.ToString();
            if(text.Contains(",")&&text.Length<17)
                return text + toAdd.ToString();
            if (!text.Contains(",") && text.Length < 16)
                return text + toAdd.ToString();
            return text;
        }
        public string startNewLine(string odlLine)
        {
            return "";
        }
        public double makeCalculation(double first, double second,string Operator)
        {
            if (Operator == "+") return first + second;
            if (Operator == "-") return first - second;
            if (Operator == "*") return first * second;
            if (Operator == "/") return first / second;
            throw new System.ArgumentException("Unknow operator", "Operator");
        }
        public string makeCalculation(string first,string second, string Operator)
        {
            return makeCalculation(double.Parse(first), double.Parse(second), Operator).ToString();
        }
        public string OperationLabelAddComa(string text)
        {
            string coma = ",";
            if(!text.Contains(coma))
            {
                return text + coma;
            }
            return text;

        }
        public string deleteLastChar(string text)
        {
            if (text.Length > 1)
            {
                return text.Remove(text.Length - 1);
            }
            else
            {
                return "0";
            }
        }
        public string historyTextadd(string napis, string toAdd)
        {
            int n =napis.Length - 1;
            if (n >= 0)
                if ((toAdd == "+" || toAdd == "/" || toAdd == "*" || toAdd == "-") && (napis[n] == '+' || napis[n] == '/' || napis[n] == '*' || napis[n] == '-'))
                    napis = napis.Remove(napis.Length - 1);
            napis += toAdd;

            if (napis.Length > 30)
            {
                napis = "<" + napis.Substring(napis.Length - 29, 29);

            }
            return napis;
        }


    }
}
