using System;

namespace Kursova.Writers
{
    public class Writer
    {
        public Writer()
        {

        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string line, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;

            Console.WriteLine(line);

            Console.ResetColor();
        }

        public void Write(string line)
        {
            Console.Write(line);
        }

        public void Write(string line, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;

            Console.Write(line);

            Console.ResetColor();
        }
    }
}
