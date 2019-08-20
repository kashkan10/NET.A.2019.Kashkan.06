using System;
using System.Linq;

namespace Polynomials
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            CheckArguments(left, right);

            (double[] max, double[] min) = left.Polynom.Length > right.Polynom.Length ? ((double[])left.Polynom.Clone(), (double[])right.Polynom.Clone()) : ((double[])right.Polynom.Clone(), (double[])left.Polynom.Clone());

            for (int i = min.Length - 1; i >= 0; i--)
            {
                max[i] += min[i];
            }

            return new Polynomial(max);
        }

        /// <summary>
        /// Overload of operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            CheckArguments(left, right);

            int len = left.Polynom.Length > right.Polynom.Length ? left.Polynom.Length : right.Polynom.Length;
            double[] array = new double[len];
            double[] leftArr = (double[])left.Polynom.Clone();
            double[] rightArr = (double[])right.Polynom.Clone();

            for (int i = 0; i < array.Length; i++)
            {
                if (i == leftArr.Length)
                {
                    array[i] = 0 - rightArr[i];
                }
                else
                {
                    array[i] = leftArr[i] - rightArr[i];
                }
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Overload of operator *
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            CheckArguments(left, right);

            double[] mas = new double[left.Polynom.Length + right.Polynom.Length - 1];
            for (int i = 0; i < left.Polynom.Length; i++)
            {
                for (int j = 0; j < right.Polynom.Length; j++)
                {
                    mas[i + j] += left.Polynom[i] * right.Polynom[j];
                }
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator *
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="number"></param>
        public static Polynomial operator *(Polynomial polynom, double number)
        {
            CheckArguments(polynom);

            double[] mas = (double[])polynom.Polynom.Clone();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] *= number;
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator /
        /// </summary>
        /// <param name="polynom"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial polynom, double number)
        {
            CheckArguments(polynom);

            if (number == 0)
            {
                throw new DivideByZeroException();
            }

            double[] mas = (double[])polynom.Polynom.Clone();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] /= number;
            }

            return new Polynomial(mas);
        }

        /// <summary>
        /// Overload of operator ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial left, Polynomial right)
        {
            if ((object)left == null || (object)right == null)
            {
                if ((object)left == null && (object)right == null)
                {
                    return true;
                }
                else return false;
            }

            if (left.Polynom.Length != right.Polynom.Length)
            {
                return false;
            }

            return left.Polynom.SequenceEqual(right.Polynom);
        }

        /// <summary>
        /// Overload of operator !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial left, Polynomial right)
        {
            return !(left == right);
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
                if (Polynom[i] >= 0)
                {
                    if (i != 0)
                    {
                        result += "+" + Polynom[i] + "x" + (Polynom.Length - i - 1);
                    }
                    else
                    {
                        result +=Polynom[i] + "x" + (Polynom.Length - i - 1);
                    }
                }
                else
                {
                    result += Polynom[i] + "x" + (Polynom.Length - i - 1);
                }
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