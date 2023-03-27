using System.Data.Common;

namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        #region properies, constructor, override ToString

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

        public override string ToString() => $"[{A}, {B}]\n[{C}, {D}]";

        #endregion

        #region implementation IEquatable<Matrix2D>

        public bool Equals(Matrix2D? other)
        {
            if(other is null) return false;
            if(ReferenceEquals(this, other)) return true;

            return A == other.A && B == other.B && C == other.C && D == other.D;
        }

        public override bool Equals(object? obj)
        {
            if(obj is null) return false;
            if(obj is not Matrix2D) return false;

            return Equals(obj as Matrix2D);
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C, D);

        public static bool operator ==(Matrix2D left, Matrix2D right)
        {
            if (left is null && right is null) return true;
            if (left is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(Matrix2D left, Matrix2D right) => !(left == right);

        #endregion

        #region addition

        public Matrix2D Plus(Matrix2D other)
        {
            if (this is null && other is null) return null; 

            return new Matrix2D(this.A + other.A, this.B + other.B, this.C + other.C, this.D + other.D);
        }

        private static Matrix2D Sum(Matrix2D u1, Matrix2D u2)
            => u1.Plus(u2);

        public static Matrix2D operator +(Matrix2D u1, Matrix2D u2)
        {
            return Sum(u1,u2);
        }
        #endregion

        #region substraction

        public Matrix2D Minus(Matrix2D other)
        {
            return new Matrix2D(this.A - other.A, this.B - other.B, this.C - other.C, this.D - other.D);
        }

        private static Matrix2D Difference(Matrix2D u1, Matrix2D u2)
            => u1.Minus(u2);

        public static Matrix2D operator -(Matrix2D u1, Matrix2D u2)
        {
            return Difference(u1, u2);
        }

        #endregion

        #region multiplication

        public Matrix2D Multiplication(Matrix2D other)
        {
            if (this is null && other is null) return null;

            return new Matrix2D(this.A * other.A + this.B * other.C, this.A * other.B + this.B * other.D,
                this.C * other.A + this.D * other.C, this.C * other.B + this.D * other.D);
        }

        private static Matrix2D Product(Matrix2D u1, Matrix2D u2)
            => u1.Multiplication(u2);

        public static Matrix2D operator *(Matrix2D u1, Matrix2D u2)
        {
            return Product(u1, u2);
        }

        #endregion

        #region scalar multiplication left & right

        public Matrix2D ScalarMultiplicationLeft(int other)
        {
            return new Matrix2D(this.A * other, this.B * other, this.C * other, this.D * other);
        }

        private static Matrix2D ScalarProductLeft(Matrix2D u1, int k)
            => u1.ScalarMultiplicationLeft(k);

        public static Matrix2D operator *(Matrix2D u1, int k)
        {
            return ScalarProductLeft(u1, k);
        }

       /*********************************************************************************************/

        public Matrix2D ScalarMultiplicationRight(int other)
        {
            return new Matrix2D(other * this.A, other * this.B, other * this.C, other * this.D);
        }

        private static Matrix2D ScalarProductRight(int k, Matrix2D u1)
            => u1.ScalarMultiplicationRight(k);

        public static Matrix2D operator *(int k, Matrix2D u1)
        {
            return ScalarProductRight(k, u1);
        }

        #endregion

        #region changing the sign of the matrix

        public Matrix2D ChangeTheSign()
        {
            return new Matrix2D(this.A * -1, this.B * -1, this.C * -1, this.D * -1);
        }

        private static Matrix2D CharacterReplacementResult(Matrix2D u1)
            => u1.ChangeTheSign();

        public static Matrix2D operator -(Matrix2D u1)
        {
            return CharacterReplacementResult(u1);
        }

        #endregion

        #region transposition

        public Matrix2D Transpose()
        {
            return new Matrix2D(this.A, this.C, this.B, this.D);
        }

        #endregion

        #region matrix's determinant


        public static int Determinant(Matrix2D u)
        {
            return u.A * u.D - u.B * u.C;
        }

        public int Det()
        {
            return this.A * this.D - this.B * this.C;
        }

        #endregion
    }
}
