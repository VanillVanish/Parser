using System;
using System.Collections;
using System.Collections.Generic;

namespace ParserNS
{
    public class Parser
    {
        static string[] _lexemes = new string[] { ")", "(", "+", "--", "-", "*", "/", "^"};
        static int[] _priority = new int[]     {   0,   1,   3,   3,    3,   4,   4,   5};

        protected virtual string[] Lexemes
        {
            get { return _lexemes; }
        }

        protected virtual int[] Priority
        {
            get { return _priority; }
        }

        protected virtual int GetPrior(string lexem)
        {
            int iLex = Array.IndexOf<string>(Lexemes, lexem);
            return iLex >= 0 ? Priority[iLex] : 100;
        }

       
        public virtual List<string> ExtractLexList(string filterExpression)
        {
            filterExpression = filterExpression.Replace(" ", "");
            filterExpression = filterExpression.Replace("\t", "");
            filterExpression = filterExpression.Replace("\n", "");
            filterExpression = filterExpression.Replace("\r", "");
            for (int i = 0; i < Lexemes.Length; i++)
                filterExpression = filterExpression.Replace(Lexemes[i], Convert.ToString(Convert.ToChar(i)));
            List<string> lexList = new List<string>();
            string curLexem = "";
            foreach (Char c in filterExpression)
                if (Convert.ToInt32(c) < Lexemes.Length)
                {
                    if (curLexem != "") lexList.Add(curLexem);
                    curLexem = "";
                    lexList.Add(Lexemes[Convert.ToInt32(c)]);
                }
                else
                    curLexem += c;
            if (curLexem != "") lexList.Add(curLexem);

            return lexList;
        }


        public virtual List<string> ToBPN(List<string> lexList)
        {
            List<string> bpnList = new List<string>();
            Stack<string> stack = new Stack<string>();
            bool prevIsArgument = false;
            for (int i = 0; i < lexList.Count;i++ )
            {
                string lex = lexList[i];
                int prior = GetPrior(lex);
                if (prior == 100)
                {
                    bpnList.Add(lex);
                    prevIsArgument = true;
                    continue;
                }
                if (lex == "-" && !prevIsArgument)
                    lex = "--";

                //
                if (stack.Count == 0)
                    stack.Push(lex);
                else
                    if (lex == "(")
                        stack.Push(lex);
                    else
                    {
                        while (stack.Count > 0 && GetPrior(stack.Peek()) >= prior)
                        {
                            string l = stack.Pop();
                            if (lex == ")" && l == "(")
                                break;
                            bpnList.Add(l);
                        }
                        if (lex != ")")
                            stack.Push(lex);
                    }
                prevIsArgument = lex==")";
            }
            while (stack.Count > 0)
                bpnList.Add(stack.Pop());

            return bpnList;
        }

        public virtual object Calc(List<string> bpnList)
        {
            Stack arguments = new Stack();
            foreach (string lex in bpnList)
            {
                if (GetPrior(lex) == 100)
                    PushConst(lex, arguments);
                else
                    DoOperation(lex, arguments);
            }
            if (arguments.Count != 1)
                throw new Exception("[Parser] Syntax error in expression");
            return arguments.Pop();
        }

        public virtual object Calc(string expression)
        {
            return Calc(ToBPN(ExtractLexList(expression)));
        }

        protected virtual void PushConst(string lex, Stack arguments)
        {
            int i;
            double d;

            if(int.TryParse(lex, out i))
                arguments.Push(i);
            else
            if(double.TryParse(lex, out d))
                arguments.Push(d);
            else
                arguments.Push(lex);
        }

        protected virtual void DoOperation(string op, Stack arguments)
        {
            switch (op)
            {
                case "+":
                    arguments.Push(Plus(arguments.Pop(), arguments.Pop())); break;
                case "--":
                    arguments.Push(UnarMinus(arguments.Pop())); break;
                case "-":
                    arguments.Push(Minus(arguments.Pop(), arguments.Pop())); break;
                case "*":
                    arguments.Push(Mult(arguments.Pop(), arguments.Pop())); break;
                case "/":
                    arguments.Push(Div(arguments.Pop(), arguments.Pop())); break;
                case "^":
                    arguments.Push(Power(arguments.Pop(), arguments.Pop())); break;
            }
        }

        protected virtual object Power(object p, object p_2)
        {
            return Math.Pow(GetDoubleValue(p_2), GetDoubleValue(p));
        }

        protected virtual object Div(object p, object p_2)
        {
            return GetDoubleValue(p_2) / GetDoubleValue(p);
        }

        protected virtual object Mult(object p, object p_2)
        {
            if (p is int && p_2 is int)
                return (int)p * (int)p_2;
            else
                return GetDoubleValue(p) * GetDoubleValue(p_2);
        }

        protected virtual object Minus(object p, object p_2)
        {
            if (p is int && p_2 is int)
                return (int)p_2 - (int)p;
            else
                return GetDoubleValue(p_2) - GetDoubleValue(p);
        }

        protected virtual object UnarMinus(object p)
        {
            if (p is int)
                return -(int)p;
            else
                return - GetDoubleValue(p);
        }

        protected virtual object Plus(object p, object p_2)
        {
            if (p is int && p_2 is int)
                return (int)p + (int)p_2;
            else
                return GetDoubleValue(p) + GetDoubleValue(p_2);
        }

        protected virtual double GetDoubleValue(object p)
        {
            double result;
            if(double.TryParse(p.ToString(), out result))
                return result;
            return double.NaN;
        }
    }
}
