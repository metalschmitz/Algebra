using Linear_Algebra.Exceptions;
using System;
using System.Collections.Generic;

namespace Linear_Algebra.Types
{
    /// <summary>
    /// A general vector of arbitrary size.
    /// </summary>
    class Vector
    {
        #region Constructors
        /// <summary>
        /// Construct a vector of a specific size.
        /// </summary>
        /// <param name="dimension"></param>
        public Vector(uint dimension)
        {
            Values = new double[dimension];
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="vector"></param>
        public Vector(Vector vector)
        {
            Values = new double[vector.Dimensions];
            for (uint i = 0; i < vector.Dimensions; i++)
            {
                Values[i] = vector[i];
            }
        }

        /// <summary>
        /// Construct a vector from values of an array.
        /// </summary>
        /// <param name="values"></param>
        public Vector(double[] values)
        {
            Values = values;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the values of the vector.
        /// </summary>
        public double[] Values
        {
            get;
        }

        /// <summary>
        /// Size of the vector.
        /// </summary>
        public uint Dimensions => (uint) Values.GetLength(0);

        /// <summary>
        /// Access specific values of the vector.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[uint index]
        {
            get => Values[index];            
            set => Values[index] = value;
        }
        #endregion

        #region Operators
        /// <summary>
        /// Add two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if(vector1.Dimensions != vector2.Dimensions)
            {
                throw new WrongFormatException("Vectors must be of the same dimension for this operation.");
            }

            Vector result = new Vector(vector1.Dimensions);
            for(uint i = 0; i < vector1.Dimensions; i++)
            {
                result.Values[i] = vector1[i] + vector2[i];
            }
            return result;
        }

        /// <summary>
        /// Subtract two vectors.
        /// </summary>
        /// <param name="vector1"></param>subtract
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
            {
                throw new WrongFormatException("Vectors must be of the same dimension for this operation.");
            }

            Vector result = new Vector(vector1.Dimensions);
            for (uint i = 0; i < vector1.Dimensions; i++)
            {
                result.Values[i] = vector1[i] - vector2[i];
            }
            return result;
        }

        /// <summary>
        /// Multiply a vector with a scalar value.
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector operator *(double scalar, Vector vector)
        {
            Vector result = new Vector(vector);

            for (uint i = 0; i < result.Dimensions; i++)
            {
                result.Values[i] *= scalar;
            }
            return result;
        }

        /// <summary>
        /// Check if two vectors are equal.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException();
            }

            if (vector1.Dimensions != vector2.Dimensions)
            {
                return false;
            }

            for(uint i = 0; i < vector1.Dimensions; i++)
            {
                if(vector1[i] != vector2[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if two vectors are not equal.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static bool operator !=(Vector vector1, Vector vector2) => !(vector1 == vector2);

        /// <summary>
        /// Override of object comparison.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var vector = obj as Vector;
            return vector != null &&
                   EqualityComparer<double[]>.Default.Equals(Values, vector.Values) &&
                   Dimensions == vector.Dimensions;
        }

        /// <summary>
        /// Override of hash code function.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1466858141;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[]>.Default.GetHashCode(Values);
            hashCode = hashCode * -1521134295 + Dimensions.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
