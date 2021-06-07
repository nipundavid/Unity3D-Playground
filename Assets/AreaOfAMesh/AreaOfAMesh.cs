﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace AreaOfAMesh
{
    public class AreaOfAMesh : MonoBehaviour
    {
        public Mesh mesh;
        public float area;

        private void OnDrawGizmos()
        {
            Vector3[] vert = mesh.vertices;
            int[] tris = mesh.triangles;

            float _area = 0;

            for (int i = 0; i < tris.Length; i+=3)
            {
                Vector3 aPos = vert[tris[i]];
                Vector3 bPos = vert[tris[i+1]];
                Vector3 cPos = vert[tris[i+2]];

                _area += Vector3.Cross(bPos - aPos, cPos - aPos).magnitude;

                Gizmos.DrawSphere(transform.TransformPoint(aPos), 0.01f);
                Gizmos.DrawSphere(transform.TransformPoint(bPos), 0.01f);
                Gizmos.DrawSphere(transform.TransformPoint(cPos), 0.01f);
            }
            area = _area / 2;
        }
    }
}
