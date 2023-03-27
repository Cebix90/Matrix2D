namespace MatrixLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix2D m  = new (1,2,3,4);
            Matrix2D p  = new (2,2,3,4);

            //Console.WriteLine(p.Equals(m));
            //Console.WriteLine();

            Console.WriteLine(m);
            Console.WriteLine();
            Console.WriteLine(p);
            Console.WriteLine();

            //Console.WriteLine(m + p);
            //Console.WriteLine();
            //
            //Console.WriteLine(m - p);
            //Console.WriteLine();

            Console.WriteLine(m * p);
        }
    }
}
