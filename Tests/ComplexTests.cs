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
using System.Linq;
using Binarysharp.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void Modulus()
        {
            var c1 = new Complex(3, 4);
            var c2 = new Complex(4, 0);
            var c3 = new Complex(0, 4);


            Assert.AreEqual(5, c1.Modulus);
            Assert.AreEqual(4, c2.Modulus);
            Assert.AreEqual(4, c3.Modulus);
        }

        [TestMethod]
        public void Argument()
        {
            var c1 = new Complex(4, 0);
            var c2 = new Complex(-4, 4);
            var c3 = new Complex(-3, -3);
            var c4 = new Complex(1, -1);

            Assert.AreEqual(0, MathEx.ToDegrees(c1.Argument));
            Assert.AreEqual(135, MathEx.ToDegrees(c2.Argument));
            Assert.AreEqual(-135, MathEx.ToDegrees(c3.Argument));
            Assert.AreEqual(-45, MathEx.ToDegrees(c4.Argument));
        }

        [TestMethod]
        public void Conjugate()
        {
            var c1 = new Complex(3, 6);
            var c2 = new Complex(-3, -1);

            var cc1 = c1.Conjugate();
            var cc2 = c2.Conjugate();

            Assert.AreEqual(3, cc1.Real);
            Assert.AreEqual(-6, cc1.Imaginary);
            Assert.AreEqual(-3, cc2.Real);
            Assert.AreEqual(1, cc2.Imaginary);
        }

        [TestMethod]
        public void Quadrant()
        {
            var c1 = new Complex(3, 3);
            var c2 = new Complex(-3, 3);
            var c3 = new Complex(-3, -3);
            var c4 = new Complex(3, -3);

            Assert.AreEqual(1, c1.Quadrant);
            Assert.AreEqual(2, c2.Quadrant);
            Assert.AreEqual(3, c3.Quadrant);
            Assert.AreEqual(4, c4.Quadrant);
        }

        [TestMethod]
        public void Equality()
        {
            var c1 = new Complex(1, 1);
            var c2 = new Complex(-1, 1);
            var c3 = new Complex(1, 1);

            Assert.AreNotEqual(c1, c2);
            Assert.AreEqual(c1, c3);
        }

        [TestMethod]
        public void ConvertToString()
        {
            var c1 = new Complex(1, 2);
            var c2 = new Complex(0, 3);
            var c3 = new Complex(4, 0);
            var c4 = new Complex(4, -5);
            var c5 = new Complex(-6, -7);

            Assert.AreEqual("1+2i", c1.ToString());
            Assert.AreEqual("3i", c2.ToString());
            Assert.AreEqual("4", c3.ToString());
            Assert.AreEqual("4-5i", c4.ToString());
            Assert.AreEqual("-6-7i", c5.ToString());
        }

        [TestMethod]
        public void ImportFromPolarForm()
        {
            var c1 = Complex.FromPolarCoordinates(Math.Sqrt(2), MathEx.ToRadians(45));
            var c2 = Complex.FromPolarCoordinates(8, Math.PI / 6);
            var c3 = Complex.FromPolarCoordinates(5, 0);


            Assert.AreEqual(1d, Math.Round(c1.Real, 5));
            Assert.AreEqual(1d, Math.Round(c1.Imaginary, 5));
            Assert.AreEqual(Math.Round(4 * Math.Sqrt(3), 14), c2.Real);
            Assert.AreEqual(4, Math.Round(c2.Imaginary, 5));
            Assert.AreEqual(5, Math.Round(c3.Real, 5));
            Assert.AreEqual(0, Math.Round(c3.Imaginary, 5));
        }

        [TestMethod]
        public void Addition()
        {
            var c1 = new Complex(4, 3);
            var c2 = new Complex(6, 7);

            Assert.AreEqual(10, (c1 + c2).Real);
            Assert.AreEqual(10, (c1 + c2).Imaginary);
        }

        [TestMethod]
        public void Soustraction()
        {
            var c1 = new Complex(4, 3);
            var c2 = new Complex(6, 7);

            Assert.AreEqual(-2, (c1 - c2).Real);
            Assert.AreEqual(-4, (c1 - c2).Imaginary);
        }

        [TestMethod]
        public void Multiplication()
        {
            var c1 = new Complex(4, 3);
            var c2 = new Complex(6, 7);

            Assert.AreEqual(3, (c1 * c2).Real);
            Assert.AreEqual(46, (c1 * c2).Imaginary);
        }

        [TestMethod]
        public void Division()
        {
            var c1 = new Complex(4, 3);
            var c2 = new Complex(6, 7);

            Assert.AreEqual(9d / 17d, (c1 / c2).Real);
            Assert.AreEqual(-2d / 17d, (c1 / c2).Imaginary);
        }

        [TestMethod]
        public void SolveQuadraticEquationsWithRealCoefficients()
        {
            var results1 = Complex.SolveQuadraticEquation(1, -4, 13);
            var results2 = Complex.SolveQuadraticEquation(1, -8, 20);

            Assert.AreEqual(new Complex(2, 3), results1[0]);
            Assert.AreEqual(new Complex(2, -3), results1[1]);
            Assert.AreEqual(new Complex(4, 2), results2[0]);
            Assert.AreEqual(new Complex(4, -2), results2[1]);
        }

        [TestMethod]
        public void Power()
        {
            var c1 = new Complex(1, -1).Power(4);
            var c2 = new Complex(-1, -2).Power(5);
            var c3 = new Complex(2, -1).Power(11);

            Assert.AreEqual(-4, Math.Round(c1.Real, 5));
            Assert.AreEqual(0, Math.Round(c1.Imaginary, 5));
            Assert.AreEqual(-41, Math.Round(c2.Real, 5));
            Assert.AreEqual(38, Math.Round(c2.Imaginary, 5));
            Assert.AreEqual(2642, Math.Round(c3.Real, 5));
            Assert.AreEqual(6469, Math.Round(c3.Imaginary, 5));
        }

        [TestMethod]
        public void Roots()
        {
            var c1 = new Complex(-119, 120).AllRoots(4).ToArray();
            
            Assert.AreEqual(4, c1.Length);
            Assert.AreEqual(3, Math.Round(c1[0].Real, 5));
            Assert.AreEqual(2, Math.Round(c1[0].Imaginary, 5));
            Assert.AreEqual(-2, Math.Round(c1[1].Real, 5));
            Assert.AreEqual(3, Math.Round(c1[1].Imaginary, 5));
            Assert.AreEqual(-3, Math.Round(c1[2].Real, 5));
            Assert.AreEqual(-2, Math.Round(c1[2].Imaginary, 5));
            Assert.AreEqual(2, Math.Round(c1[3].Real, 5));
            Assert.AreEqual(-3, Math.Round(c1[3].Imaginary, 5));
        }

        [TestMethod]
        public void SolveQuadraticEquationsWithComplexCoefficients()
        {
            var results1 = Complex.SolveQuadraticEquation(new Complex(1, 0), new Complex(5, 4), new Complex(27, 5));
            var results2 = Complex.SolveQuadraticEquation(new Complex(3, 0), new Complex(8, -66), new Complex(-167, -120));

            Assert.AreEqual(-2, Math.Round(results1[0].Real, 5));
            Assert.AreEqual(3, Math.Round(results1[0].Imaginary, 5));
            Assert.AreEqual(-3, Math.Round(results1[1].Real, 5));
            Assert.AreEqual(-7, Math.Round(results1[1].Imaginary, 5));

            Assert.AreEqual(-0.66667, Math.Round(results2[0].Real, 5));
            Assert.AreEqual(19, Math.Round(results2[0].Imaginary, 5));
            Assert.AreEqual(-2, Math.Round(results2[1].Real, 5));
            Assert.AreEqual(3, Math.Round(results2[1].Imaginary, 5));
        }
    }
}
