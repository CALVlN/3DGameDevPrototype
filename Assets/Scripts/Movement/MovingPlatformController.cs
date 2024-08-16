using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.gameObject.CompareTag("MovingPlatform")) {
            if (Vector3.Dot(collisionInfo.GetContact(0).normal, Vector3.up) > 0.05f) {
                transform.parent = collisionInfo.collider.transform;
            }
        }
    }

    void OnCollisionExit(Collision collisionInfo) {
        if (collisionInfo.gameObject.CompareTag("MovingPlatform")) {
            transform.parent = null;
        }
    }
}
