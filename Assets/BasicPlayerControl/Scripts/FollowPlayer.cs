using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BasicPlayerController
{
    public class FollowPlayer : MonoBehaviour
    {
        public GameObject target;
        public Vector3 offset;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 newPos = target.transform.position + offset;
            transform.position = newPos;
        }
    }
}