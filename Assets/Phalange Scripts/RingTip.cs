using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RingTip : MonoBehaviour {

    private Vector3 phalangeVector;
    private GameObject phalange;
    private int arrayIndex = 9;
    private int xOffset = 3;
    private int yOffset = 3;
    public volatile bool ringTipCollided = false;

    void OnCollisionEnter(Collision col) {
        ringTipCollided = true;
    }

    void Awake() {
        phalange = GameObject.Find("RingTip");
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