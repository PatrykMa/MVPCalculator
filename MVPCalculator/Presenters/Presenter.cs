using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCalculator.Presenters
{
    class Presenter
    {
        interfaces.iViev viev;
        Models.Model model;

        string left = "0";
        string right = "0";
        string Operator = "";
        bool writeSomething = true;
        bool shouldClearLine = false;
        bool block=false;
        bool lasEqual = false;
        

        public Presenter(interfaces.iViev viev, Models.Model model)
        {
            this.model = model;
            this.viev = viev;

            viev.Button_NumericClick += NumerClick;
            viev.Button_ComaClick += comaClick;
            viev.Button_OperatorClick += operatorClick;
            viev.Button_EqualClick += equalClick;
            viev.Button_DeleteClick += deleteClik;
            viev.Button_ClearClick += clarClick;
        }

        private void NumerClick(object obj, string num)
        {
            if (block) return;
            if (lasEqual) return;
            writeSomething = true;
            if (shouldClearLine) {
                viev.operationText = model.startNewLine(viev.operationText);
                shouldClearLine = false;
            }
            viev.operationText = model.OperationLabelAddChar(viev.operationText, num[0]);
            

        }
        private void operatorClick(object obj, string oper)
        {
            if (block) return;
            if(!writeSomething)
            {
                Operator = oper;
                shouldClearLine = true;
                right = viev.operationText;
                viev.historyText = model.historyTextadd(viev.historyText, oper);
            }
            else
            {
                if(Operator=="")
                {
                    left = viev.operationText;
                    viev.historyText = model.historyTextadd(viev.historyText, left);
                    right = left;
                }
                else
                {
                    right=viev.operationText;
                    viev.historyText = model.historyTextadd(viev.historyText, right);
                    left = calculate(left, right, Operator);
                    viev.operationText = left;

                }
                viev.historyText = model.historyTextadd(viev.historyText, oper);
                Operator = oper;
                shouldClearLine = true;
            }
            writeSomething = false;
            lasEqual = false;


        }
        private void comaClick(object obj)
        {
            if (block) return;
            if (lasEqual) return;
            viev.operationText = model.OperationLabelAddComa(viev.operationText);
        }
        private void equalClick(object obj)
        {
            if (left == ""||Operator==""||block)
                return;
            if (writeSomething)
            {
                right = viev.operationText;
            }
            left = calculate(left, right, Operator);
            viev.operationText = left;
            writeSomething = false;
            viev.historyText = "";
            lasEqual = true;

        }

        private string calculate(string left, string right,string Oper)
        {
            try
            {
                if (Oper == "/" && double.Parse(right) == 0)
                {
                    block = true;
                    return "nie mozna dzielic przez 0";
                }
                return model.makeCalculation(left, right, Oper);
            }
            catch (DivideByZeroException)
            {
                block = true;
                return "nie mozna dzielic przez 0";
            }
            catch
            {
                block=true;
                return "nieznany blad";
            }
        }
        private void deleteClik(object obj)
        {
            if(writeSomething)
            {
                viev.operationText = model.deleteLastChar(viev.operationText);
            }
        }
        private void clarClick(object obj)
        {
           left = "0";
           right = "0";
           Operator = "";
           writeSomething = true;
           shouldClearLine = false;
           block = false;
           viev.operationText = "0";

        }

    }
}
