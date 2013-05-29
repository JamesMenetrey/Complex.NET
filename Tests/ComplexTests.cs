/*
* Complex.NET
* https://github.com/ZenLulz/Complex.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-29
*/

using System;
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


            Assert.AreEqual(1d, c1.Real);
            Assert.AreEqual(1d, c1.Imaginary);
            Assert.AreEqual(Math.Round(4 * Math.Sqrt(3), 14), c2.Real);
            Assert.AreEqual(4, c2.Imaginary);
            Assert.AreEqual(5, c3.Real);
            Assert.AreEqual(0, c3.Imaginary);
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
    }
}
