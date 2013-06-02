/*
* Complex.NET
* https://github.com/ZenLulz/Complex.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-06-02
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Binarysharp.Maths
{
    /// <summary>
    /// Represents a complex number.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Complex : IEquatable<Complex>
    {
        #region Properties
        #region Argument
        /// <summary>
        /// Gets the argument of the complex number.
        /// </summary>
        public double Argument
        {
            get { return Math.Atan2(Imaginary, Real); }
        }
        #endregion
        #region Imaginary
        /// <summary>
        /// Gets the imaginary part of the complex number.
        /// </summary>
        public double Imaginary { get; private set; }
        #endregion
        #region Modulus
        /// <summary>
        /// Gets the modulus of the complex number.
        /// </summary>
        public double Modulus
        {
            get { return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2)); }
        }
        #endregion
        #region Quadrant
        /// <summary>
        /// Gets a value indicating in which quadrant the complex number is.
        /// </summary>
        public int Quadrant
        {
            get
            {
                if (Real >= 0 && Imaginary >= 0)
                    return 1;
                if (Real < 0 && Imaginary >= 0)
                    return 2;
                if (Real < 0 && Imaginary < 0)
                    return 3;
                return 4;
            }
        }
        #endregion
        #region Real
        /// <summary>
        /// Gets the real part of the complex number.
        /// </summary>
        public double Real { get; private set; }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of <see cref="Complex"/> using the specified real and imaginary values.
        /// </summary>
        /// <param name="real">The real part of the complex number.</param>
        /// <param name="imaginary">The imaginary part of the complex number.</param>
        public Complex(double real, double imaginary)
            : this()
        {
            // Save the parameters
            Real = real;
            Imaginary = imaginary;
        }
        #endregion

        #region Methods
        #region Conjugate
        /// <summary>
        /// Computes the conjugate of a complex number and returns the result.
        /// </summary>
        /// <returns>The conjugate of the complex number.</returns>
        public Complex Conjugate()
        {
            return new Complex(Real, -Imaginary);
        }
        #endregion
        #region Equals
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        public bool Equals(Complex other)
        {
            return Imaginary.Equals(other.Imaginary) && Real.Equals(other.Real);
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Complex && Equals((Complex)obj);
        }
        #endregion
        #region FromPolarCoordinates (static)
        /// <summary>
        /// Creates a complex number from a point's polar coordinates.
        /// </summary>
        /// <param name="modulus">The magnitude, which is the distance from the origin (the intersection of the x-axis and the y-axis) to the number.</param>
        /// <param name="argument">The phase, which is the angle from the line to the horizontal axis, measured in radians.</param>
        /// <returns>A complex number.</returns>
        public static Complex FromPolarCoordinates(double modulus, double argument)
        {
            return new Complex((modulus * Math.Cos(argument)), (modulus * Math.Sin(argument)));
        }
        #endregion
        #region GetHashCode
        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Imaginary.GetHashCode() * 397) ^ Real.GetHashCode();
            }
        }
        #endregion
        #region Operator Overloading
        /// <summary>
        /// Overloads the equality operator.
        /// </summary>
        public static bool operator ==(Complex left, Complex right)
        {
            return left.Equals(right);
        }
        /// <summary>
        /// Overloads the inequality operator.
        /// </summary>
        public static bool operator !=(Complex left, Complex right)
        {
            return !left.Equals(right);
        }
        /// <summary>
        /// Overloads the addition operator.
        /// </summary>
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }
        /// <summary>
        /// Overloads the subtraction operator.
        /// </summary>
        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }
        /// <summary>
        /// Overloads the multiplication operator.
        /// </summary>
        public static Complex operator *(Complex left, Complex right)
        {
            var real = (left.Real * right.Real) - (left.Imaginary * right.Imaginary);
            var imaginary = (left.Real * right.Imaginary) + (left.Imaginary * right.Real);
            return new Complex(real, imaginary);
        }
        /// <summary>
        /// Overloads the division operator.
        /// </summary>
        public static Complex operator /(Complex left, Complex right)
        {
            var numerator = left * right.Conjugate();
            var denominator = Math.Pow(right.Real, 2) + Math.Pow(right.Imaginary, 2);
            return new Complex(numerator.Real / denominator, numerator.Imaginary / denominator);
        }
        /// <summary>
        /// Overloads the unary minus operator.
        /// </summary>
        public static Complex operator -(Complex value)
        {
            return new Complex(-value.Real, -value.Imaginary);
        }
        #region Implicit operators
        /// <summary>
        /// Defines an implicit conversion of a short to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(Int16 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of an unsigned short to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(UInt16 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of an integer to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(Int32 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of an unsigned integer to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(UInt32 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of a long to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(Int64 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of an unsigned long to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(UInt64 value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of a float to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(float value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of a double to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(double value)
        {
            return new Complex(value, 0d);
        }
        /// <summary>
        /// Defines an implicit conversion of a decimal to a complex number.
        /// </summary>
        /// <param name="value">The value to convert to a complex number.</param>
        /// <returns>An object that contains the value of the parameter as its real part and zero as its imaginary part.</returns>
        public static implicit operator Complex(decimal value)
        {
            return new Complex((double)value, 0d);
        }
        #endregion
        #endregion
        #region Power
        /// <summary>
        /// Returns the complex number raised to a power specified by a double-precision floating-point number.
        /// </summary>
        /// <param name="power">A double-precision floating-point number that specifies a power.</param>
        /// <returns>The complex number raised to the specified power.</returns>
        public Complex Power(double power)
        {
            return FromPolarCoordinates(Math.Pow(Modulus, power), Argument * power);
        }
        #endregion
        #region Roots
        /// <summary>
        /// Return the first root of the complex number using a double-precision floating-point number.
        /// </summary>
        /// <param name="root">A double-precision floating-point number that specifies a root.</param>
        /// <returns>A complex number.</returns>
        public Complex FirstRoot(double root)
        {
            return AllRoots(root).First();
        }
        /// <summary>
        /// Returns all nth roots of the complex number using a double-precision floating-point number.
        /// </summary>
        /// <param name="root">A double-precision floating-point number that specifies a root.</param>
        /// <returns>An array of nth roots of the complex number.</returns>
        public IEnumerable<Complex> AllRoots(double root)
        {
            // Compute the modulus and the argument
            var modulus = Math.Pow(Modulus, 1d / root);
            var argument = Argument / root;

            // Compute all roots
            for (var i = 0; i < root; i++)
            {
                yield return FromPolarCoordinates(modulus, argument + ((2 * Math.PI / root) * i));
            }
        }
        #endregion
        #region SolveQuadraticEquation (static)
        /// <summary>
        /// Solves a quadratic equation with real coefficients written in the form: ax^2 + bx + c = 0.
        /// </summary>
        /// <param name="a">The quadratic coefficient (must be different from zero).</param>
        /// <param name="b">The linear coefficient.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>An array containing the solution(s).</returns>
        public static Complex[] SolveQuadraticEquation(double a, double b, double c)
        {
            // Check that the quadratic coefficient must be different from zero
            if (a.Equals(0d))
                throw new ArgumentOutOfRangeException("a", "The quadratic coefficient must be different from zero.");

            // Compute the discriminant
            var delta = Math.Pow(b, 2) - 4 * a * c;

            // Compute the parts of the complex solutions
            var real = -b / (2 * a);
            var imaginary = Math.Sqrt(Math.Abs(delta)) / (2 * a);

            // Return the solutions
            return new[] { new Complex(real, imaginary), new Complex(real, -imaginary) };
        }
        /// <summary>
        /// Solves a quadratic equation with complex coefficients written in the form: ax^2 + bx + c = 0.
        /// </summary>
        /// <param name="a">The quadratic coefficient (must be different from zero).</param>
        /// <param name="b">The linear coefficient.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>>An array containing the solution(s).</returns>
        public static Complex[] SolveQuadraticEquation(Complex a, Complex b, Complex c)
        {
            // Check that the quadratic coefficient must be different from zero
            if(a.Equals(0d))
                throw new ArgumentOutOfRangeException("a", "The quadratic coefficient must be different from zero.");

            // Compute the discriminant
            var delta = b.Power(2) - new Complex(4 * ((a * c).Real), 4 * (a * c).Imaginary);

            // Compute the parts of the solutions
            var deltaSqrt = delta.FirstRoot(2);
            var denominator = new Complex(a.Real*2, a.Imaginary*2);

            // Return the solutions
            return new[] { (-b + deltaSqrt) / denominator, (-b - deltaSqrt) / denominator };
        }
        #endregion
        #region ToString
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            // If the imaginary number is missing
            if (Imaginary.Equals(0))
                return string.Format("{0}", Real);
            // If the real number is missing
            if (Real.Equals(0))
                return string.Format("{0}i", Imaginary);
            // If both exist
            return string.Format("{0}{1}{2}i", Real, Imaginary > 0 ? "+" : "", Imaginary);
        }
        #endregion
        #endregion
    }
}
