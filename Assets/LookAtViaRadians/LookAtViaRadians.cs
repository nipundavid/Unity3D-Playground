using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace LookAtViaRadians
{
    public class LookAtViaRadians : MonoBehaviour
    {
        public GameObject player;
        public GameObject target;

        [Range(0f, 90f)]
        public float limit = 30;
        private const float TAU = 6.28318530718f;
        private void OnDrawGizmos()
        {
            void DrawLine(Vector2 pos, Vector2 end)
            {
                Gizmos.DrawLine(pos, end);
            }


            Gizmos.color = Color.red;

            DrawLine(player.transform.position, player.transform.position + player.transform.right);

            DrawLine(target.transform.position, target.transform.position + target.transform.right);

            // find direction from target to player
            Vector3 dir = (player.transform.position - target.transform.position).normalized;
            // find dot product
            float dotProduct = Vector3.Dot(dir, target.transform.right);
            dotProduct = Mathf.Clamp(dotProduct, -1, 1);
            // find angle at which target is looking at in radians
            float angRadian = Mathf.Acos(dotProduct);


            // Vector2.Angle(dir, target.transform.right); // gives in degree - same as above

            //converts to radians
            float limitToRadian = limit * Mathf.Deg2Rad;

            bool isLooking = angRadian < limitToRadian;

            Gizmos.color = isLooking ? Color.green : Color.cyan;
            DrawLine(target.transform.position, target.transform.position + dir);
        }
    }
}