using System.Collections.Generic;

namespace NTH.Analysis.Rendering
{
    class ConsoleCharDiffRenderer : ConsoleDiffRenderer<char>, IDiffRenderer<char>
    {
        public ConsoleCharDiffRenderer(bool newLineForDiff)
            : base(newLineForDiff)
        { }

        public void Render(List<Diff<char>> diffs)
        {
            foreach (var diff in diffs)
                PrintCharDiff(diff.Type, diff.Content);
        }
    }
}
