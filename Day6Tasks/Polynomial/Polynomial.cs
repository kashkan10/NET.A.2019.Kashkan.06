using System;
using System.Linq;

namespace Polynomial
{
    public class Polynomial
    {
        /// <summary>
        /// Property for polynom
        /// </summary>
        public double[] Polynom { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="polynom">Sz-array</param>
        public Polynomial(params double[] polynom)
        {
            Polynom = polynom;
        }

        /// <summary>
        /// Overload of operator +
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            CheckArguments(p1, p2);

            (double[] max, double[] min) = p1.Polynom.Length > p2.Polynom.Length ? ((double[])p1.Polynom.Clone(), (double[])p2.Polynom.Clone()) : ((double[])p2.Polynom.Clone(), (double[])p1.Polynom.Clone());

            for (int i = min.Length - 1; i >= 0; i--)
            {
                max[i] += min[i];
            }

            return new Polynomial(max);
        }

        /// <summary>
        /// Overload of operator -
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            CheckArguments(p1, p2);

            (double[] max, double[] min) = p1.Polynom.Length > p2.Polynom.Length ? ((double[])p1.Polynom.Clone(), (double[])p2.Polynom.Clone()) : ((double[])p2.Polynom.Clone(), (double[])p1.Polynom.Clone());

            for (int i = min.Length - 1; i >= 0; i--)
            {
                max[i] -= min[i];
            }

            return new Polynomial(max);
        }

        /// <summary>
        /// Overload of operator *
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            CheckArguments(p1, p2);

            double[] mas = new double[p1.Polynom.Length + p2.Polynom.Length - 1];
            for (int i = 0; i < p1.Polynom.Length; i++)
            {
                for (int j = 0; j < p2.Polynom.Length; j++)
                {
                    mas[i + j] += p1.Polynom[i] * p2.Polynom[j];
                }
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator *
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="number"></param>
        public static Polynomial operator *(Polynomial p1, double number)
        {
            CheckArguments(p1);

            double[] mas = (double[])p1.Polynom.Clone();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] *= number;
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator /
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial p1, double number)
        {
            CheckArguments(p1);

            if (number == 0)
            {
                throw new DivideByZeroException();
            }

            double[] mas = (double[])p1.Polynom.Clone();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] /= number;
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator ==
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if ((object)p1 == null || (object)p2 == null)
            {
                if ((object)p1 == null && (object)p2 == null)
                {
                    return true;
                }
                else return false;
            }

            if (p1.Polynom.Length != p2.Polynom.Length)
            {
                return false;
            }

            return p1.Polynom.SequenceEqual(p2.Polynom);
        }

        /// <summary>
        /// Overload of operator !=
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Overriding of object.ToString() method
        /// </summary>
        /// <returns>String representaition of polynom</returns>
        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < Polynom.Length; i++)
            {
                result += Polynom[i] + "x" + (Polynom.Length - i - 1) + "+";
            }

            return result;
        }

        /// <summary>
        /// Overriding of object.Equals() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Equality comparison result</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial p = obj as Polynomial;
            if (p == null)
            {
                return false;
            }

            return p.Polynom.SequenceEqual(this.Polynom);
        }

        /// <summary>
        /// Overriding of object.GetHashCode() method
        /// </summary>
        /// <returns>Hash code of polynom</returns>
        public override int GetHashCode()
        {
            return Polynom.Length * (int)Polynom.First() / (int)Polynom.Last();
        }

        /// <summary>
        /// Arguments checking
        /// </summary>
        /// <param name="arr">Array of polynomials</param>
        private static void CheckArguments(params Polynomial[] arr)
        {
            foreach (Polynomial pol in arr)
            {
                if (pol == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}
