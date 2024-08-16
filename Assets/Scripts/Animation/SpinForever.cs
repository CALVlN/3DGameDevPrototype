using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinForever : MonoBehaviour {
    public float speed = 100f;

    void FixedUpdate() {
        transform.rotation = Quaternion.AngleAxis(Time.time * speed, transform.up);
    }
}
