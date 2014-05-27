using System;
using System.Collections.Generic;

namespace NTH.Analysis.Rendering
{
    class GenericConsoleDiffRenderer<T> : ConsoleDiffRenderer<T>, IDiffRenderer<T> where T : IComparable<T>
    {
        public GenericConsoleDiffRenderer(bool newLineForDiff)
             : base(newLineForDiff)
        { }

        public void Render(List<Diff<T>> diffs)
        {
            foreach (var diff in diffs)
                PrintCharDiff(diff.Type, diff.Content);
        }
    }
}
