using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PointerBase : MonoBehaviour {

    private Vector3 phalangeVector;
    private GameObject phalange;
    private int arrayIndex = 1;
    private int xOffset = 1;
    private int yOffset = 1;

    void Awake() {
        phalange = GameObject.Find("PointerBase");
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