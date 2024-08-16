using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreationExample : MonoBehaviour {
    // Instantiate object
    public Transform crazyObject;

    private Transform obj1;
    private Transform obj2;
    private Transform obj3;
    private Transform obj4;
    
    // Start is called before the first frame update
    void Start() {
        obj1 = Instantiate(crazyObject);
        obj1.position = new Vector3(-3f, 0f, 0f);

        obj2 = Instantiate(crazyObject);
        obj2.eulerAngles = new Vector3(0f, 0f, 10f);
        obj2.position = new Vector3(-1.5f, 0f, 0f);

        obj3 = Instantiate(crazyObject);
        obj3.position = new Vector3(1.5f, 0f, 0f);
        obj3.localScale = new Vector3(1.0f, 2.0f, 1.0f);

        obj4 = Instantiate(crazyObject);
        obj4.position = new Vector3(3f, 0f, 0f);
        
        obj2.parent = obj1;
        obj3.parent = obj1;
        obj4.parent = obj1;
        obj1.eulerAngles = new Vector3(0f, 0f, 10f);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
