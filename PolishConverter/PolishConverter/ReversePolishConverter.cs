namespace PolishConverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReversePolishConverter
    {
        private readonly string input;
        private readonly Queue<char> output = new Queue<char>();
        private readonly Stack<Operator> operators = new Stack<Operator>();

        public ReversePolishConverter(string input)
        {
            this.input = input;
        }

        public string Convert()
        {
            foreach (var word in input.ToCharArray())
            {
                if (!IsOperator(word))
                {
                    if (!IsNumber(word))
                    {
                        throw new InvalidOperationException();
                    }

                    output.Enqueue(word);
                    continue;
                }

                ProcessOperator(word);
            }

            while (operators.Count > 0)
            {
                output.Enqueue(operators.Pop().Value);
            }

            return GetOutput();
        }

        private void ProcessOperator(char ch)
        {
            var oper = new Operator(ch);

            if (operators.Count == 0)
            {
                operators.Push(oper);
                return;
            }

            // new > existing
            if (oper.CompareTo(operators.Peek()) > 0)
            {
                operators.Push(oper);
                return;
            }

            while (oper.CompareTo(operators.Peek()) <= 0)
            {
                output.Enqueue(operators.Pop().Value);
            }

            operators.Push(oper);
        }

        private string GetOutput()
        {
            var sb = new StringBuilder();

            while (output.Count > 0)
                sb.Append(output.Dequeue());

            return sb.ToString();
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
            var ops = new [] {'+', '-', '/', '*'};
            return ops.Contains(ch);
        }
    }
}