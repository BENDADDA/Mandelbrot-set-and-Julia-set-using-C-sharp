// System.Matlab.Maths
using System;
using System.Matlab;
namespace System
{
    /// <summary>
    ///
    /// </summary>
    public static class Maths
    {
       
        public const double PI = 3.1415926535897931;
        public const double E = 2.7182818284590451;
        public const double FI = 1.6180339887498948;
        /// <summary>
        /// Calculating the Niberian Exponent for a Complex Number
        /// </summary>
        /// <param name="z">A complex number specifying a power</param>
        /// <returns>Exp(z)</returns>
        public static Complex Exp(Complex z)
        {
            double x = Math.Exp(z.X) * Math.Cos(z.Y);
            double y = Math.Exp(z.X) * Math.Sin(z.Y);
            return new Complex(x, y);
        }

        /// <summary>
        /// To set the complex number using exponential form
        /// </summary>
        /// <param name="r">r is the modulus of  a complex number</param>
        /// <param name="o">o is the argument of a complex number</param>
        /// <returns></returns>
        public static Complex ExpForm(double r, double o)
        {
            return new Complex(r * Math.Cos(o), r * Math.Sin(o));
        }

        /// <summary>
        /// Returns a value indicating the sign of a complex number
        /// </summary>
        /// <param name="z">A complex number specifying an angle</param>
        /// <returns></returns>
        public static Complex Sign(Complex z)
        {
            return (z == 0.0) ? ((Complex)0.0) : (z / z.ABS);
        }

        /// <summary>
        ///             Returns the value of the logarithm of a complex number
        /// </summary>
        /// <param name="z">A complex  number  whose logarithm is to be found</param>
        /// <returns></returns>
        public static Complex Log(Complex z)
        {
            double x = Math.Log(z.ABS);
            double aRG = z.ARG;
            return new Complex(x, aRG);
        }

        /// <summary>
        ///             Returns the logarithm of specified complex number in a specified base
        /// </summary>
        /// <param name="z">A complex  number  whose logarithm is to be found</param>
        /// <param name="n">A real nubmer specifies the logarithm base </param>
        /// <returns></returns>
        public static Complex Log(Complex z, double n)
        {
            return Log(z) / Log(n);
        }

        /// <summary>
        /// Returns the logrithm of specified complex number in specified base
        /// </summary>
        /// <param name="z">A complex number whose logarithm is to be found</param>
        /// <param name="n">A complex number specifies the logarithm base</param>
        /// <returns></returns>
        public static Complex Log(Complex z, Complex n)
        {
            return Log(z) / Log(n);
        }

        /// <summary>
        /// Returns base 10 logarithm of specified complex number
        /// </summary>
        /// <param name="z">A complex number whose logarithm is to be found</param>
        /// <returns></returns>
        public static Complex Log10(Complex z)
        {
            return Log(z) / Math.Log(10.0);
        }

        /// <summary>
        /// Returns the cosine of specified complex number
        /// </summary>
        /// <param name="z"></param>
        /// <returns>A complex number whose cosine to be found</returns>
        public static Complex Cos(Complex z)
        {
            Complex complex = new Complex(0.0, 1.0);
            Complex complex2 = Exp(z.ARG * complex);
            complex = new Complex(0.0, -1.0);
            Complex complex3 = Exp(z.ARG * complex);
            return (complex2 + complex3) / 2.0;
        }

        /// <summary>
        /// Returns the sine of specified complex number
        /// </summary>
        /// <param name="z">A complex number whose sine to be found</param>
        /// <returns></returns>
        public static Complex Sin(Complex z)
        {
            Complex complex = new Complex(0.0, 1.0);
            Complex complex2 = Exp(z.ARG * complex);
            complex = new Complex(0.0, -1.0);
            Complex complex3 = Exp(z.ARG * complex);
            return (complex2 - complex3) / 2.0;
        }

        /// <summary>
        /// Returns the tangent of specified complex number 
        /// </summary>
        /// <param name="z">A complex number whose tangent to be found</param>
        /// <returns></returns>
        public static Complex Tan(Complex z)
        {
            return Sin(z) / Cos(z);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of specfied complex number
        /// </summary>
        /// <param name="z">A complex number whose hyperbloci cosine of to be found</param>
        /// <returns></returns>
        public static Complex Cosh(Complex z)
        {
            return (Exp(z) + Exp(-z)) / 2.0;
        }

        /// <summary>
        /// Returns the hyperbolic tangent of specfied complex number
        /// </summary>
        /// <param name="z">A complex number whose hyperbloci tangent of to be found</param>
        /// <returns></returns>
        public static Complex Tanh(Complex z)
        {
            return Sinh(z) / Cosh(z);
        }

        /// <summary>
        /// Returns the hyperbolic sine of specfied complex number
        /// </summary>
        /// <param name="z">A complex number whose hyperbloci sine of to be found</param>
        /// <returns></returns>
        public static Complex Sinh(Complex z)
        {
            return (Exp(z) - Exp(-z)) / 2.0;
        }

        /// <summary>
        /// Returns the square root of specified complex nubmer
        /// </summary>
        /// <param name="z">A complex number</param>
        /// <returns></returns>
        public static Complex Sqrt(Complex z)
        {
            double x = z.X;
            double y = z.Y;
            double num = (x + Math.Sqrt(x * x + y * y)) / 2.0;
            double y2 = Math.Sqrt(num - x);
            return new Complex(Math.Sqrt(num), y2);
        }

        /// <summary>
        /// Return a specified complex nubmber raised to the specified power
        /// </summary>
        /// <param name="z">A complex number to raised a power </param>
        /// <param name="n">A double -precision floating -point number that specifies a power</param>
        /// <returns></returns>
        public static Complex Power(Complex z, double n)
        {
            if (n == 0.0)
            {
                return new Complex(1.0, 0.0);
            }
            if (z.X == 0.0 && z.Y == 0.0)
            {
                return new Complex(0.0, 0.0);
            }
            return Exp(n * Log(z));
        }

        /// <summary>
        /// Return a specified complex nubmber raised to the specified power where the power is a complex number
        /// </summary>
        /// <param name="z">A complex number to raised a power</param>
        /// <param name="n">A complex number that  specifies a power</param>
        /// <returns></returns>
        public static Complex Power(Complex z, Complex n)
        {
            if (n.X == 0.0 && n.Y == 0.0)
            {
                return new Complex(1.0, 0.0);
            }
            if (z.X == 0.0 && z.Y == 0.0)
            {
                return new Complex(0.0, 0.0);
            }
            return Exp(n * Log(z));
        }

        /// <summary>
        /// Returns the floor of complex number
        /// </summary>
        /// <param name="z">A complex number</param>
        /// <returns></returns>
        public static Complex Floor(Complex z)
        {
            return new Complex(Math.Floor(z.X), Math.Floor(z.Y));
        }

        /// <summary>
        /// Returns the ceiling of complex nubmer
        /// </summary>
        /// <param name="z">A complex number</param>
        /// <returns></returns>
        public static Complex Ceiling(Complex z)
        {
            return new Complex(Math.Ceiling(z.X), Math.Ceiling(z.Y));
        }
        public static Complex Zeta(Complex z)
        {
            throw new NotImplementedException();
        }
        public static Complex Fact(Complex z)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return a Magic Matrix in a specified dimensions where it is a square matrix
        /// </summary>
        /// <param name="k">k is a natural number specified the dimensions where the dimensions of the magic matrix is 2k+1</param>
        /// <returns></returns>
        public static int[,] MagicMatrix(int k)
        {
            int num = 2 * k + 1;
            int[,] array = new int[num, num];
            int num2 = (num - 1) / 2;
            int a = num2 - 1;
            int b = num2;
            int num3 = 0;
            while (num3 < num * num)
            {
                if (a >= 0 && a < num && b >= 0 && b < num)
                {
                    if (array[a, b] == 0)
                    {
                        array[a, b] = num3 + 1;
                        num3++;
                        a--;
                        b++;
                    }
                    else
                    {
                        a--;
                        b--;
                    }
                }
                else
                {
                    g(ref a, ref b, num - 1);
                }
            }
            return array;
        }

        private static void g(ref int a, ref int b, int n)
        {
            if (a == n + 1)
            {
                a = 0;
            }
            if (a == -1)
            {
                a = n;
            }
            if (b == n + 1)
            {
                b = 0;
            }
            if (b == -1)
            {
                b = n;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Function(FunctionName functionName,Complex z)
        {
            switch (functionName)
            {
                case FunctionName.Cos: return Cos(z);
                case FunctionName.Sin: return Sin(z);
                case FunctionName.Exp: return Exp(z);
                case FunctionName.Log: return Log(z);
                case FunctionName.Log10: return Log10(z);
                case FunctionName.Sqrt: return Sqrt(z);
                case FunctionName.Inverse: return 1 / z;
                case FunctionName.Square: return z * z;
                case FunctionName.Cube: return z * z * z;
                case FunctionName.Zeta: return Zeta(z);
                case FunctionName.Fact: return Fact(z);
                default: throw new Exception();
            }
        }

    }

}