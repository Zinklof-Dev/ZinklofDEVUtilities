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
            return Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in three Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist3(Vector3 x, Vector3 y)
        {
            return (Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y)) + Numbers.Sqr((x.z - y.z)));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in four Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public double SqrDist4(Vector4 x, Vector4 y)
        {
            return (Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y)) + Numbers.Sqr((x.z - y.z)) + Numbers.Sqr((x.w - y.w)));
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
            return Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in three Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist3f(Vector3 x, Vector3 y)
        {
            return (Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y)) + Numbers.Sqr((x.z - y.z)));
        }
        /// <summary>
        /// Provides the Sqaure Distance between two points in four Dimensions. (cheaper than sqrt distance)
        /// </summary>
        /// <param name="x">Point 1</param>
        /// <param name="y">Point 2</param>
        /// <returns>Square Distance between Point 1 and Point 2</returns>
        static public float SqrDist4f(Vector4 x, Vector4 y)
        {
            return (Numbers.Sqr((x.x - y.x)) + Numbers.Sqr((x.y - y.y)) + Numbers.Sqr((x.z - y.z)) + Numbers.Sqr((x.w - y.w)));
        }
        /// <summary>
        /// Provides a point that is x units in the direction provided from the start point provided
        /// <summary>
        /// <param name="startPoint">Point to start from</param>
        /// <param name="dir">Quaternion direction to move in</param>
        /// <param name="dist">How far ahead of the start point should this new point be</param>
        /// <returns>A point that is dist units away from the startPoint in the dir direction.</returns>
        static public Vector3 DirPoint(Vector3 startPoint, Quaternion dir, float dist)
        {
            Vector3 vectorDir = dir * startPoint;
            Vector3 returnPoint = startPoint + vectorDir.normalized * dist;
            return returnPoint;
        }
        /// <summary>
        /// Provides a point that is x units in the direction provided from the start point provided (slightly more expensive than the overload that uses a quaternion)
        /// <summary>
        /// <param name="startPoint">Point to start from</param>
        /// <param name="eulerDir">Vector3 direction to move in</param>
        /// <param name="dist">How far ahead of the start point should this new point be</param>
        /// <returns>A point that is dist units away from the startPoint in the eulerDir direction.</returns>
        static public Vector3 DirPoint(Vector3 startPoint, Vector3 eulerDir, float dist)
        {
            Quaternion dir = Quaternion.Euler(eulerDir);
            Vector3 vectorDir = dir * startPoint;
            Vector3 returnPoint = startPoint + vectorDir.normalized * dist;
            return returnPoint;
        }
    }
}
