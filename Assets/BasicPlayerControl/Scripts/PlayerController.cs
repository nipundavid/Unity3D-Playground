using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BasicPlayerController
{
    public class PlayerController : MonoBehaviour
    {

        private float speed = 20.0f;
        private float turnSpeed = 45f;
        private float horizontalInput;
        private float forwardInput;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Move the vehical forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            //Rotates the vehical
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }

        void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            horizontalInput = movementVector.x;
            forwardInput = movementVector.y;
        }
    }
}
