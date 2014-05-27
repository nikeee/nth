using System;

namespace NTH.Analysis.Rendering
{
    abstract class ConsoleDiffRenderer<T>
    {
        private readonly bool _newLineForDiff;
        protected ConsoleDiffRenderer(bool newLineForDiff)
        {
            _newLineForDiff = newLineForDiff;
        }
        protected void PrintCharDiff(DiffType type, T c)
        {
            switch (type)
            {
                case DiffType.Equal:
                    PrintItemDiff(ConsoleColor.Gray, "   ", c);
                    return;
                case DiffType.Insert:
                    PrintItemDiff(ConsoleColor.DarkGreen, "+  ", c);
                    return;
                case DiffType.Delete:
                    PrintItemDiff(ConsoleColor.DarkRed, "-  ", c);
                    return;
                default:
                    throw new ArgumentException("?");
            }
        }

        private void PrintItemDiff(ConsoleColor color, string diffPrefix, T c)
        {
            if (_newLineForDiff)
                WriteColorNewLine(color, diffPrefix + c);
            else
                WriteColor(color, c);
        }

        private void WriteColorNewLine<U>(ConsoleColor color, U c)
        {
            var fg = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(c);
            Console.ForegroundColor = fg;
        }
        private void WriteColor<U>(ConsoleColor color, U c)
        {
            var fg = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(c);
            Console.ForegroundColor = fg;
        }
    }
}
