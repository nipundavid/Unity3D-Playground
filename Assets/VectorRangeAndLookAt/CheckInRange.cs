using UnityEditor;
using UnityEngine;

namespace VectorRangeAndLookAt
{

    public class CheckInRange : MonoBehaviour
    {
        public Transform player;
        public Transform target;

        [Range(1f, 4f)]
        public float radius = 1f;

        [Range(0f, 1f)]
        public float preciseness = 0.5f;
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            #region Checks if Target is within range
            // Finds direction
            Vector3 dirFromTPlayerToTarget = (target.position - player.position).normalized;

            //draw line from player towards enemy
            Gizmos.DrawLine(player.position, player.position + dirFromTPlayerToTarget);

            //Checks if in radius
            bool isInRange = (target.position - player.position).magnitude < radius;
            
            // Change color if in range
            Handles.color = isInRange ? Color.red : Color.green;

            //draw red disc
            Handles.DrawWireDisc(player.position, Vector3.forward, radius);
            #endregion

            #region checks if Target is almost looking at the player
            Vector3 dirFromTargetToPlayer = (player.position - target.position).normalized;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(target.position, target.position + target.right);

             // -1 means opposite dir
            //  1 means same direction
            float lookThreshHold = Vector3.Dot(dirFromTargetToPlayer, target.right);
   
            bool isLookingAtPlayer = lookThreshHold >= preciseness;

            Gizmos.color = isLookingAtPlayer ? Color.green : Color.red;
            Gizmos.DrawLine(target.position, target.position + dirFromTargetToPlayer);

            #endregion

        }
    }
#endif
}
