namespace PolishConverter
{
    using System;

    public class Operator : IComparable<Operator>
    {
        public Operator(char value)
        {
            Value = value;
        }

        public char Value { get; private set; }

        public int Precedence
        {
            get
            {
                if (this.Value == '+' || this.Value == '-')
                {
                    return 2;
                }

                if (this.Value == '*' || this.Value == '/')
                {
                    return 3;
                }

                if (this.Value == '^')
                {
                    return 4;
                }

                if (this.Value == '(' || this.Value == ')')
                {
                    return -1;
                }

                return 0;
            }
        }

        public int CompareTo(Operator other)
        {
            return this.Precedence.CompareTo(other.Precedence);
        }
    }
}