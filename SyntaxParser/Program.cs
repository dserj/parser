using System;

namespace SyntaxParser
{
    using PolishConverter;

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                // read the line from the user
                Console.Write("> ");
                input = Console.ReadLine();

                var converter = new ReversePolishConverter(input);

                Console.WriteLine(converter.Convert());
            }
        }
    }
}
