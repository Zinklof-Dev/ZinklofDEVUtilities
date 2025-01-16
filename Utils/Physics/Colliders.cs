using System;
using UnityEngine;
using ZinklofDev.Utils.MathZ;

Namespace ZinklofDev.Physics
{
    class Sphere // The most basic primitive to do this stuff with other than a point
    {
        public Vector3 position = new Vector3(0,0,0); // world space position.
        public float radius = 1;
        public float radiusSqr { get; private set; }

        public Sphere(Vector3 Ppsiton = Vector3.Empty, float radius = 1)
        {
            this.position = position;
            this.radius = radius;
        }

        public bool PointInSphere(Vector3 point)
        {
            if (Vectors.SqrDist3(position, point) < (radius * radius))
            {
                return true;
            }
            else
                return false
        }

        public Vector3 ClosestPoint(Vector3 point)
        {
            Vector3 dir = Vector3.Normalize(position - point) // vector dir pointing from sphere to the point
            return dir * radius;
        }
    }
}
