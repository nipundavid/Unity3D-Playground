using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CrossProductToFindOrientation
{
    public class CrossProductToFindOrientation : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Vector3 headPos = transform.position;
            Vector3 lookDir = transform.forward;

            void DrawRay(Vector3 p, Vector3 dir) => Handles.DrawAAPolyLine(p, p + dir);
            
            if(Physics.Raycast(transform.position, transform.forward,out RaycastHit hit))
            {
                Vector3 hitPos = hit.point;
                Vector3 up = hit.normal;
                Vector3 right = Vector3.Cross( up, lookDir).normalized;
                Vector3 forward = Vector3.Cross(right, up);


                Handles.color = Color.white;
                Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture,5,headPos, hitPos);

                Handles.color = Color.green;
                DrawRay(hitPos, up);

                Handles.color = Color.red;
                DrawRay(hitPos, right);

                Handles.color = Color.cyan;
                DrawRay(hitPos, forward);
            }
            else
            {
                Handles.color = Color.red;
                Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture, 5, headPos, headPos + lookDir);

            }
        }
    }
}