using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MiddleCenter : MonoBehaviour {
    
    private Vector3 phalangeVector;
    private GameObject phalange;
    private int arrayIndex = 7;
    private int xOffset = 2;
    private int yOffset = 2;

    void Awake() {
        phalange = GameObject.Find("MiddleCenter");
        phalange.transform.Translate(xOffset, yOffset, 0);
    }

    void FixedUpdate() {
        phalangeVector.x = (float)GameObject.Find("Main Camera").GetComponent<TestScript>().yGyro[arrayIndex];
        phalangeVector.y = (float)GameObject.Find("Main Camera").GetComponent<TestScript>().zGyro[arrayIndex];
        phalangeVector.z = (float)GameObject.Find("Main Camera").GetComponent<TestScript>().xGyro[arrayIndex];
    }

    void Update() {
        phalange.transform.Rotate(phalangeVector, Space.Self);
    }
}