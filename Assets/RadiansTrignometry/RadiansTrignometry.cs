using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RadiansTrignometry
{
    public class RadiansTrignometry : MonoBehaviour
    {
        const float TAU = 6.28318530718f;

        public int dotCount = 16;
        public float radius = 1;
        private void OnDrawGizmos()
        {
            Vector2 AngToDir(float angRad)
            {
                return new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));
            }

            float DirToAng(Vector2 v)
            {
                return Mathf.Atan2(v.y, v.x);
            }


            for (int i = 0; i < dotCount; i++)
            {
                float t = i / (float)dotCount;

                float angRad = TAU * t;

                float x = Mathf.Cos(angRad);
                float y = Mathf.Sin(angRad);

                Vector2 point = new Vector2(x, y);

                Gizmos.DrawSphere(point * radius, 0.06f);
            }
        }
    }
}