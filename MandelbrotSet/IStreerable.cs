// System.Matlab.ISteerable
using System;
namespace System
{
    namespace Matlab
    {
        internal interface ISteerable
        {
            Complex SteerTo(Complex other);
        }
    }
}