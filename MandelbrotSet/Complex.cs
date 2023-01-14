// System.Matlab.Complex
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace System
{
    namespace Matlab
    {
        /// <summary>
        /// A class representing complex numbers 
        /// </summary>
        public struct Complex : IEquatable<Complex>, ISteerable, IFormattable, IConvertible
        {
            private double x;
            private double y;
            /// <summary>
            /// The real part of the complex number
            /// </summary>
            public double X { get { return x; } set { x = value; } }

            /// <summary>
            /// The imaginary part of a complex number
            /// </summary>
            public double Y { get { return y; } set { y = value; } }

            public double ABS
            {
                get
                {
                    return Abs();
                }
            }

            /// <summary>
            /// Aruement of complex number
            /// </summary>
            public double ARG
            {
                get
                {
                    return Arg();
                }
            }

            /// <summary>
            /// Specifieds the complex number by two real numbers
            /// </summary>
            /// <param name="x">The real part of the complex number</param>
            /// <param name="y">The imaginary part of a complex number</param>
            public Complex(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public static Complex operator +(Complex z, Complex w)
            {
                return new Complex(z.X + w.X, z.Y + w.Y);
            }

            public static Complex operator -(Complex z, Complex w)
            {
                return new Complex(z.X - w.X, z.Y - w.Y);
            }

            public static Complex operator +(Complex z, double a)
            {
                return new Complex(z.X + a, z.Y);
            }

            public static Complex operator -(Complex z, double a)
            {
                return new Complex(z.X - a, z.Y);
            }

            public static Complex operator +(double a, Complex z)
            {
                return new Complex(z.X + a, z.Y);
            }

            public static Complex operator -(double a, Complex z)
            {
                return new Complex(a - z.X, 0.0 - z.Y);
            }

            public static Complex operator *(Complex z, Complex w)
            {
                return new Complex(z.X * w.X - z.Y * w.Y, z.X * w.Y + z.Y * w.X);
            }

            public static Complex operator *(Complex z, double a)
            {
                return new Complex(z.X * a, z.Y * a);
            }

            public static Complex operator *(double a, Complex z)
            {
                return new Complex(z.X * a, z.Y * a);
            }

            public static Complex operator /(Complex z, Complex w)
            {
                double num = w.X * w.X + w.Y * w.Y;
                return new Complex((z.X * w.X + z.Y * w.Y) / num, (z.Y * w.X - z.X * w.Y) / num);
            }

            public static Complex operator /(double a, Complex z)
            {
                double num = z.X * z.X + z.Y * z.Y;
                return new Complex(z.X * a / num, (0.0 - z.Y) * a / num);
            }

            public static Complex operator /(Complex z, double a)
            {
                return new Complex(z.X / a, z.Y / a);
            }

            public static Complex operator -(Complex z)
            {
                return new Complex(0.0 - z.X, 0.0 - z.Y);
            }

            public static Complex operator +(Complex z)
            {
                return z;
            }

            public static Complex operator ++(Complex z)
            {
                return z + new Complex(1.0, 1.0);
            }

            public static Complex operator --(Complex z)
            {
                return z + new Complex(-1.0, -1.0);
            }

            public static implicit operator Complex(double x)
            {
                return new Complex(x, 0.0);
            }

            public static bool operator ==(Complex left, Complex right)
            {
                return left.X == right.X && left.Y == right.Y;
            }

            public static bool operator !=(Complex left, Complex right)
            {
                return left.X != right.X || left.Y != right.Y;
            }

            private double Abs()
            {
                return (this == 0.0) ? 0.0 : Math.Sqrt(X * X + Y * Y);
            }

            private double Arg()
            {
                if (this == 0.0)
                {
                    return double.NaN;
                }
                double num = Math.Asin(Y / Abs());
                if (X < 0.0)
                {
                    num = ((!(Y > 0.0)) ? (-Math.PI - num) : (Math.PI - num));
                }
                return num;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                Complex complex = (Complex)obj;
                return X == complex.X && Y == complex.Y;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="z"></param>
            /// <returns></returns>
            public bool Equals(Complex z)
            {
                return z == this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return ToString("B", CultureInfo.CurrentCulture);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public string ToString(string format)
            {
                return ToString(format, CultureInfo.CurrentCulture);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="format"></param>
            /// <param name="formatProvider"></param>
            /// <returns></returns>
            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (string.IsNullOrEmpty(format))
                {
                    format = "B";
                }
                if (formatProvider == null)
                {
                    formatProvider = CultureInfo.CurrentCulture;
                }
                switch (format)
                {
                    case "B":
                        {
                            double num = X;
                            double num2 = Y;
                            return "(" + num + "," + num2 + ")";
                        }
                    case "F":
                        {
                            double num = X;
                            string text = ((Y < 0.0) ? "-" : "+");
                            string text2 = ((Y == 1.0 || Y == -1.0) ? "" : Math.Abs(Y).ToString());
                            return X + text + text2 + "i";
                        }
                    default:
                        throw new FormatException(string.Format("The {0} format is not supported.", format));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return (X.ToString() + Y).GetHashCode();
            }

            /// <summary>Converts the string representation of a number to its complex-precision complex-point number equivalent.</summary>
            /// <returns>A complex-precision complex-point number that is equivalent to the numeric value or symbol specified in <paramref name="str" />.</returns>
            /// <param name="str">A string that contains a complex number to convert. </param>
            public static Complex Parse(string str)
            {
                string pattern = "^\\s*[-+]?\\d+\\.?\\d*\\s*$";
                string pattern2 = "^\\s*\\([-+]?\\d+\\.?\\d*\\,[-+]?\\d+\\.?\\d*\\)\\s*$";
                Regex regex = new Regex(pattern2);
                if (regex.IsMatch(str))
                {
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    match = match.NextMatch();
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    return new Complex(num, num2);
                }
                regex = new Regex(pattern);
                if (regex.IsMatch(str))
                {
                    double num = Convert.ToDouble(str);
                    return num;
                }
                regex = new Regex("^\\s*[-+]?i\\s*$");
                if (regex.IsMatch(str))
                {
                    double num2 = 1.0;
                    regex = new Regex("[-+]?");
                    Match match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = -1.0;
                    }
                    return new Complex(0.0, num2);
                }
                regex = new Regex("^\\s*[-+]?\\d+\\.?\\d*[-+]\\d+\\.?\\d*i\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]\\d+\\.?\\d*i");
                    match = regex.Match(str);
                    str = match.Groups[0].Value;
                    regex = new Regex("[-+]\\d+\\.?\\d*");
                    match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    return new Complex(num, num2);
                }
                regex = new Regex("^\\s*[-+]?\\d+\\.?\\d*[-+]i\\s*$");
                if (regex.IsMatch(str))
                {
                    double num2 = 1.0;
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]i");
                    match = regex.Match(str);
                    str = match.Groups[0].Value;
                    regex = new Regex("[-+]");
                    match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = -1.0;
                    }
                    return new Complex(num, num2);
                }
                regex = new Regex("^\\s*[-+]?\\d+\\.?\\d*[-+]i\\d+\\.?\\d*\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]i\\d+\\.?\\d*");
                    match = regex.Match(str);
                    str = match.Groups[0].Value;
                    regex = new Regex("\\d+\\.?\\d*");
                    match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]");
                    match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = 0.0 - num2;
                    }
                    return new Complex(num, num2);
                }
                regex = new Regex("^\\s*[-+]?\\d+\\.?\\d*i\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    return new Complex(0.0, num2);
                }
                regex = new Regex("^\\s*([-+]?i\\d+\\.?\\d*)\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]?");
                    match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = 0.0 - num2;
                    }
                    return new Complex(0.0, num2);
                }
                regex = new Regex("^\\s*[-+]?\\d+\\.?\\d*i[-+]\\d+\\.?\\d*\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]?\\d+\\.?\\d*");
                    match = regex.Match(str);
                    match = match.NextMatch();
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    return new Complex(num, num2);
                }
                regex = new Regex("^\\s*[-+]?i[-+]\\d+\\.?\\d*\\s*$");
                if (regex.IsMatch(str))
                {
                    double num2 = 1.0;
                    regex = new Regex("[-+]\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]?");
                    match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = -1.0;
                    }
                    return new Complex(num, num2);
                }
                regex = new Regex("^\\s*[-+]?i\\d+\\.?\\d*[-+]\\d+\\.?\\d*\\s*$");
                if (regex.IsMatch(str))
                {
                    regex = new Regex("\\d+\\.?\\d*");
                    Match match = regex.Match(str);
                    double num2 = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]\\d+\\.?\\d*");
                    match = regex.Match(str);
                    double num = Convert.ToDouble(match.Groups[0].Value);
                    regex = new Regex("[-+]?");
                    match = regex.Match(str);
                    if (match.Groups[0].Value == "-")
                    {
                        num2 = 0.0 - num2;
                    }
                    return new Complex(num, num2);
                }
                throw new FormatException("Input string was not in a correct format.");
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="str"></param>
            /// <param name="a"></param>
            /// <returns></returns>
            public static bool TryParse(string str, out Complex a)
            {
                a = default(Complex);
                try
                {
                    a = Parse(str);
                    return true;
                }
                catch
                {
                }
                return false;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            Complex ISteerable.SteerTo(Complex other)
            {
                return Maths.Sign(this - other);
            }

            TypeCode IConvertible.GetTypeCode()
            {
                return TypeCode.Object;
            }

            bool IConvertible.ToBoolean(IFormatProvider provider)
            {
                return Convert.ToBoolean(X, provider);
            }

            byte IConvertible.ToByte(IFormatProvider provider)
            {
                return Convert.ToByte(X, provider);
            }

            char IConvertible.ToChar(IFormatProvider provider)
            {
                return Convert.ToChar(X, provider);
            }

            DateTime IConvertible.ToDateTime(IFormatProvider provider)
            {
                return Convert.ToDateTime(X, provider);
            }

            decimal IConvertible.ToDecimal(IFormatProvider provider)
            {
                return Convert.ToDecimal(X, provider);
            }

            double IConvertible.ToDouble(IFormatProvider provider)
            {
                return X;
            }

            short IConvertible.ToInt16(IFormatProvider provider)
            {
                return Convert.ToInt16(X, provider);
            }

            int IConvertible.ToInt32(IFormatProvider provider)
            {
                return Convert.ToInt32(X, provider);
            }

            long IConvertible.ToInt64(IFormatProvider provider)
            {
                return Convert.ToInt64(X, provider);
            }

            float IConvertible.ToSingle(IFormatProvider provider)
            {
                return Convert.ToSingle(X, provider);
            }

            string IConvertible.ToString(IFormatProvider provider)
            {
                return ToString("B", provider);
            }

            object IConvertible.ToType(Type conversionType, IFormatProvider provider)
            {
                throw new Exception();
            }

            ushort IConvertible.ToUInt16(IFormatProvider provider)
            {
                return Convert.ToUInt16(X, provider);
            }

            uint IConvertible.ToUInt32(IFormatProvider provider)
            {
                return Convert.ToUInt32(X, provider);
            }

            ulong IConvertible.ToUInt64(IFormatProvider provider)
            {
                return Convert.ToUInt64(X, provider);
            }

            sbyte IConvertible.ToSByte(IFormatProvider provider)
            {
                return Convert.ToSByte(X, provider);
            }
        }
    }
}