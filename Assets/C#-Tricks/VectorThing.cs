using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorThing : MonoBehaviour
{

    public Transform a_;
    public Transform b_;

    [Range(1f, 4f)]
    public float offset = 1f;
    private void OnDrawGizmos()
    {
        Vector2 a = a_.position;
        Vector2 b = b_.position;

        Vector2 normalized = (b - a).normalized;
        Vector2 dirAtoB = normalized;


        //Gizmos.DrawLine(Vector3.zero, dirAtoB);
        Gizmos.DrawLine(a, a+ dirAtoB);

        Vector2 VecOffset = dirAtoB * offset;
        Gizmos.DrawSphere(a + VecOffset, 0.05f);
    }

    private void Update()
    {
        Vector2 a = a_.position;
        Vector2 b = b_.position;

        Vector2 normalized = (a - b).normalized;
        Vector2 dirAtoB = normalized;

        b_.transform.Translate(dirAtoB * 2 * Time.deltaTime);
    }
}
