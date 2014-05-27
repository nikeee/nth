namespace NTH
{
    public static class MathEx
    {
        public static int Min(int a, int b, int c)
        {
            var ab = a > b ? b : a;
            return ab > c ? c : ab;
        }
        public static int Max(int a, int b, int c)
        {
            var ab = a > b ? a : b;
            return ab > c ? ab : c;
        }
    }
}
