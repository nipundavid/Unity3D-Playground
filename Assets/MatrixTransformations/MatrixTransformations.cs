using UnityEditor;
using UnityEngine;

namespace MatrixTransformations
{
    public class MatrixTransformations : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Vector3 headPos = transform.position;
            Vector3 lookDir = transform.forward;

            void DrawRay(Vector3 p, Vector3 dir) => Gizmos.DrawRay(p, p + dir);

            if (Physics.Raycast(headPos, transform.forward, out RaycastHit hit))
            {
                Vector3 hitPos = hit.point;

                Vector3 up = hit.normal;
                Vector3 right = Vector3.Cross(up, lookDir).normalized;
                Vector3 forward = Vector3.Cross(right, up);

                Quaternion turretRot = Quaternion.LookRotation(forward, up);

                // gives a transform space that we can use as a origin
                Matrix4x4 turretToWorld = Matrix4x4.TRS(hitPos, turretRot, Vector3.one);

                // changed the transformation space to turretToWorld
                Gizmos.matrix = turretToWorld;

                Vector3[] pts = new Vector3[]
               {
                    new Vector3(1,0,1),
                    new Vector3(-1,0,1),
                    new Vector3(-1,0,-1),
                    new Vector3(1,0,-1),
                    new Vector3(1,2,1),
                    new Vector3(-1,2,1),
                    new Vector3(-1,2,-1),
                    new Vector3(1,2,-1),
               };

                Gizmos.color = Color.red;
                for (int i = 0; i < pts.Length; i++)
                {
                    // transform local space to world space 
                    // Vector3 worldPt = turretToWorld.MultiplyPoint3x4(pts[i]); // Not needed as we changed the matrix for Gizmos above
                    Gizmos.DrawSphere(pts[i], 0.075f);
                }

                // reset transformation space
                //Gizmos.matrix = Matrix4x4.identity;

                Handles.color = Color.white;
                Handles.DrawAAPolyLine( headPos, hitPos);

                Gizmos.color = Color.green;
                DrawRay(Vector3.zero, Vector3.up); // Vector3.zero bcz we changed the space above

                Gizmos.color = Color.red;
                DrawRay(Vector3.zero, Vector3.right); // Vector3.zero bcz we changed the space above

                Gizmos.color = Color.cyan;
                DrawRay(Vector3.zero, Vector3.forward); // Vector3.zero bcz we changed the space above
            }
            else
            {
                Handles.color = Color.red;
                Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture, 5, headPos, headPos + lookDir);

            }
        }
    }
}