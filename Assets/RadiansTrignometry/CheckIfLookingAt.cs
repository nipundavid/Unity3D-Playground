
using UnityEngine;

namespace RadiansTrignometry
{
    public class CheckIfLookingAt : MonoBehaviour
    {
        public Transform target;
        public float range;

        private void OnDrawGizmos()
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.right);

            float lookThreshHold = Vector3.Dot(directionToTarget, transform.right);

            Gizmos.color = lookThreshHold>= range ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, transform.position + directionToTarget);

        }


    }
}
