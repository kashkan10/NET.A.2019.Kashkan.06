using NUnit.Framework;
using Polynomials;

namespace Tests
{
    public class PolynomialsTests
    {
        [Test]
        public void EqualsTest()
        {
            Polynomial polynom1 = new Polynomial(2, 5, 3, 6);
            Polynomial polynom2 = new Polynomial(2, 5, 3, 6);
            Polynomial polynom3 = polynom2 + polynom1;

            Assert.AreEqual(polynom1.Equals(polynom3), false);
            Assert.AreEqual(polynom1.Equals(polynom2), true);
        }

        [Test]
        public void ToStringTest()
        {
            Polynomial polynom1 = new Polynomial(2, 5, 3, 6);
            string expected = "2x3+5x2+3x1+6x0";

            Assert.AreEqual(polynom1.ToString(), expected);
        }

        [Test]
        public void GetHashCodeTest()
        {
            Polynomial polynom1 = new Polynomial(2, 5, 3, 6);
            Polynomial polynom2 = new Polynomial(1, 8, 3, 6);

            Assert.AreNotEqual(polynom1.GetHashCode(), polynom2.GetHashCode());
        }

        [Test]
        public void OperatorsTest()
        {
            Polynomial polynom1 = new Polynomial(2, 5, 3, 6);
            Polynomial polynom2 = new Polynomial(2, 8, 4, 6);
            Polynomial polynom3 = new Polynomial(2, 8, 4, 6);

            Assert.AreEqual(polynom1 != polynom2, true);

            Assert.AreEqual(polynom1 == polynom2, false);
            Assert.AreEqual(polynom3 == polynom2, true);

            Assert.AreEqual(polynom1 + polynom2, new Polynomial(4, 13, 7, 12));
            Assert.AreEqual(polynom1 - polynom2, new Polynomial(0, -3, -1, 0));
            Assert.AreEqual(polynom1 * polynom2, new Polynomial(4, 26, 54, 68, 90, 42, 36));

            Assert.AreEqual(polynom2 / 2, new Polynomial(1, 4, 2, 3));
            Assert.AreEqual(polynom1 * 2, new Polynomial(4, 10, 6, 12));
        }

    }
}