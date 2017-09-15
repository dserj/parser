using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishEvaluator
{
    using System.IO;

    public class PolishEvaluator
    {
        private readonly string input;
        private readonly Stack<double> stack = new Stack<double>();

        public PolishEvaluator(string input)
        {
            this.input = input;
        }

        public double Evaluate()
        {
            foreach (char c in input)
            {
                if (IsNumber(c))
                {
                    double d;
                    Double.TryParse(c.ToString(), out d);
                    stack.Push(d);
                    continue;
                }

                if (IsOperator(c))
                {
                    // right operator is always on the top of the stack
                    stack.Push(ApplyOperator(c, stack.Pop(), stack.Pop()));
                    continue;
                }

                throw new InvalidDataException("Invalid input data");
            }

            return stack.Pop();
        }

        private double ApplyOperator(char op, double rh, double lh)
        {
            switch (op)
            {
                case '+':
                {
                    return lh + rh;
                }
                case '-':
                {
                    return lh - rh;
                }
                case '*':
                {
                    return lh * rh;
                }
                case '/':
                {
                    return lh / rh;
                }

                default:
                    throw new InvalidDataException("Unsupported operator");
            }
        }

        private bool IsNumber(char ch)
        {
            int result;
            if (int.TryParse(ch.ToString(), out result))
            {
                return true;
            }

            return false;
        }

        private bool IsOperator(char ch)
        {
            var ops = new[] { '+', '-', '/', '*' };
            return ops.Contains(ch);
        }
    }
}
