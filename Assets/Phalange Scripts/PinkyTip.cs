using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PinkyTip : MonoBehaviour {

    private Vector3 phalangeVector;
    private GameObject phalange;
    private int arrayIndex = 10;
    private int xOffset = 4;
    private int yOffset = 3;
    public volatile bool pinkyTipCollided = false;

    void OnCollisionEnter(Collision col) {
        pinkyTipCollided = true;
    }

    void Awake() {
        phalange = GameObject.Find("PinkyTip");
        phalange.transform.Translate(xOffset, yOffset, 0);
    }

    void FixedUpdate() {
        phalangeVector.x = (float)(GameObject.Find("Main Camera").GetComponent<TestScript>().yGyro[arrayIndex - 1]
                         + (GameObject.Find("Main Camera").GetComponent<TestScript>().yGyro[arrayIndex - 1])
                         - (GameObject.Find("Main Camera").GetComponent<TestScript>().yGyro[arrayIndex - 2]) / 2);
        phalangeVector.y = (float)(GameObject.Find("Main Camera").GetComponent<TestScript>().zGyro[arrayIndex - 1]
                         + (GameObject.Find("Main Camera").GetComponent<TestScript>().zGyro[arrayIndex - 1])
                         - (GameObject.Find("Main Camera").GetComponent<TestScript>().zGyro[arrayIndex - 2]) / 2);
        phalangeVector.z = (float)(GameObject.Find("Main Camera").GetComponent<TestScript>().xGyro[arrayIndex - 1]
                         + (GameObject.Find("Main Camera").GetComponent<TestScript>().xGyro[arrayIndex - 1])
                         - (GameObject.Find("Main Camera").GetComponent<TestScript>().xGyro[arrayIndex - 2]) / 2);
    }

    void Update() {
        phalange.transform.Rotate(phalangeVector, Space.Self);
    }
}