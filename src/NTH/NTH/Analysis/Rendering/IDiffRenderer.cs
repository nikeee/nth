using System;
using System.Collections.Generic;

namespace NTH.Analysis.Rendering
{
    interface IDiffRenderer<T> where T : IComparable<T>
    {
        void Render(List<Diff<T>> diffs);
    }
}
