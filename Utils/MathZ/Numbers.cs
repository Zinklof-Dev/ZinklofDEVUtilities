

using System;

namespace ZinklofDev.Utils.MathZ
{
    /// <summary>
    /// Doing math with El Numeros
    /// </summary>
    static public class Numbers
    {
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public double Sqr(double x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public float Sqr(float x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public int Sqr(int x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public long Sqr(long x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public short Sqr(short x) { return (short)(x * x); }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public uint Sqr(uint x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public ulong Sqr(ulong x) { return x * x; }
        /// <summary>
        /// Provides the Square Value of a number.
        /// </summary>
        /// <param name="x">Value to square</param>
        /// <returns>Sqaured Value of X</returns>
        static public ushort Sqr(ushort x) { return (ushort)(x * x); }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public double Cube(double x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public float Cube(float x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public int Cube(int x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public long Cube(long x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public short Cube(short x) { return (short)(x * x * x); }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public uint Cube(uint x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public ulong Cube(ulong x) { return x * x * x; }
        /// <summary>
        /// Provides the Cubed Value of a number.
        /// </summary>
        /// <param name="x">Value to cube</param>
        /// <returns>Cubed Value of X</returns>
        static public ushort Cube(ushort x) { return (ushort)(x * x * x); }
        /// <summary>
        /// Returns X to the Y power.
        /// </summary>
        /// <param name="x">Number to raise to Y power</param>
        /// <param name="y">power to raise X to</param>
        /// <returns>X^Y / X to the Y power</returns>
        static public double Power(double x, double y)
        {
            double temp = x;
            for (int i = 0; i <= y; i++)
            {
                temp = temp * x;
            }
            return temp;
        }
        /// <summary>
        /// Returns X to the Y power.
        /// </summary>
        /// <param name="x">Number to raise to Y power</param>
        /// <param name="y">power to raise X to</param>
        /// <returns>X^Y / X to the Y power</returns>
        static public float Power(float x, float y)
        {
            float temp = x;
            for (int i = 0; i <= y; i++)
            {
                temp = temp * x;
            }
            return temp;
        }
    }
}
