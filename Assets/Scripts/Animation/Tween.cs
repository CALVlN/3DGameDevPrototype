using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour {
    public Vector3 moveAmount = Vector3.zero;
    public float smoothTime = 0.2f;
    public float size = 1;

    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private Vector3 size_v;
    private float xpos;
    private bool movingTowardTarget = true;
    
    public bool cyclic = false;
    public bool funnyScale = false;

    // Start is called before the first frame update
    void Start() {
        startingPosition = transform.position;
        targetPosition = transform.position+moveAmount;
    }

    // Update is called once per frame
    void Update() {
        if (movingTowardTarget) {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            if ((transform.position - targetPosition).sqrMagnitude < 0.1f) {
                movingTowardTarget = false;
            }
        }
        else if (cyclic){
            transform.position = Vector3.SmoothDamp(transform.position, startingPosition, ref velocity, smoothTime);
            if (((transform.position - startingPosition).sqrMagnitude < 0.1f)) {
                movingTowardTarget = true;
            }
        }
    }
    
    void FixedUpdate() {
        // update size
        if (funnyScale) {
            xpos = transform.position[0];
            size_v = new Vector3 (xpos, xpos, xpos);
            transform.localScale = size_v;
        } else {
            size_v = new Vector3 (size, size, size);
            transform.localScale = size_v;
        }
    }
}
