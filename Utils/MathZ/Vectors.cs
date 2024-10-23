using System;
using UnityEngine;

namespace ZinklofDev.Utils.MathZ
{
    /// <summary>
    /// Vectors? VECTOR MATH BABY!
    /// </summary>
    static public class Vectors
    {
        /// <summary>
        /// Provides the Sqaure Distance between two points in one Dimension. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist1(double x, double y)
        {
            return Math.Abs(x - y);
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in two Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist2(Vector2 x, Vector2 y)
        {
            return Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * y.y));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in three Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist3(Vector3 x, Vector3 y)
        {
            return (Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * x.y)) + Numbers.Sqr((x.z * y.z)));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in four Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist4(Vector4 x, Vector4 y)
        {
            return (Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * x.y)) + Numbers.Sqr((x.z * y.z)) + Numbers.Sqr((x.w * y.w)));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in one Dimension. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist1f(float x, float y)
        {
            return Math.Abs(x - y);
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in two Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist2f(Vector2 x, Vector2 y)
        {
            return Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * y.y));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in three Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist3f(Vector3 x, Vector3 y)
        {
            return (Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * x.y)) + Numbers.Sqr((x.z * y.z)));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in four Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist4f(Vector4 x, Vector4 y)
        {
            return (Numbers.Sqr((x.x * y.x)) + Numbers.Sqr((x.y * x.y)) + Numbers.Sqr((x.z * y.z)) + Numbers.Sqr((x.w * y.w)));
        }
    }
}
