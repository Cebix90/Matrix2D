namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        public int A { get; init; }
        public int B { get; init; }
        public int C { get; init; }
        public int D { get; init; }

        public Matrix2D(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Matrix2D() : this(1,0,0,1) { }

        public static readonly Matrix2D Id = new (1,0,0,1);
        public static readonly Matrix2D Zero = new (0,0,0,0);

        public override string ToString() => $"[[{A}, {B}] , [{C}, {D}]]";

        #region implementation IEquatable<Matrix2D>

        #endregion
    }
}
