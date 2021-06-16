using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RegularPolygons {
    public class RegularPolygons : MonoBehaviour
    {
        private const float TAU = 6.28318530718f;
        [Range(3,10)]
        public int polygonVertexCount = 3;

        [Range(1, 4)]
        public int density = 1;

        private void OnDrawGizmos()
        {

            Vector2 AngToDir(float angRad)
            {
                return new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));
            }

            Vector2[] verts = new Vector2[polygonVertexCount];

            Gizmos.color = Color.red;

            //calculate points
            for (int i = 0; i < polygonVertexCount; i++)
            {
                float t = i / (float)polygonVertexCount;

                float radAng = TAU * t;

                verts[i] = AngToDir(radAng);

                Gizmos.DrawSphere(verts[i], 0.05f);
            }

            //draw line
            Gizmos.color = Color.white;

            for (int i = 0; i < polygonVertexCount; i++)
            {
                Gizmos.DrawLine(verts[i], verts[(i+ density) % polygonVertexCount]);
            }
        }
    }
}
