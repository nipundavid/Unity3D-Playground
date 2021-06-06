using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceTransformations
{
    public class SpaceTransformations : MonoBehaviour
    {

        public Vector2 localPoint;
        public Transform locaPoint;
        public Vector2 WorldPoint;

        private void OnDrawGizmos()
        {
            Vector2 objPos = transform.position;
            Vector2 right = transform.right;
            Vector2 up = transform.up;

            DrawBasisVector(objPos, right, up);
            DrawBasisVector(Vector3.zero, Vector3.right, Vector3.up);

            Vector2 LocalToWorld(Vector2 localPt)
            {
                Vector2 worldOffset = right * localPt.x + up * localPt.y;
                return (Vector2)transform.position + worldOffset;
            }

            Vector2 WorldToLocal(Vector2 worldPoint)
            {
                Vector2 relPoint = WorldPoint - objPos;
                float x = Vector2.Dot(relPoint, right);
                float y = Vector2.Dot(relPoint, up);
                return new Vector2(x, y);
            }

            Vector2 _worldSpacePostion = LocalToWorld(localPoint);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(_worldSpacePostion, 0.1f);

            locaPoint.localPosition = WorldToLocal(WorldPoint);
        }


        void DrawBasisVector(Vector2 pos, Vector2 right, Vector2 up)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(pos, right);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(pos, up);
            Gizmos.color = Color.white;
        }
    }
}