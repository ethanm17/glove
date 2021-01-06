using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;

public class TestScript : MonoBehaviour {
    public volatile double[] xAccel = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
    public volatile double[] yAccel = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
    public volatile double[] zAccel = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
    public volatile double[] xGyro =  new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
    public volatile double[] yGyro =  new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
    public volatile double[] zGyro =  new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

    public static SerialPort _SlPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);

    void Update() {
        _SlPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        if (Input.GetKey("1")) {servoSignal(1);}
        if (Input.GetKey("2")) {servoSignal(2);}
        if (Input.GetKey("3")) {servoSignal(3);}
        if (Input.GetKey("4")) {servoSignal(4);}
        if (Input.GetKey("5")) {servoSignal(5);}

        if (GameObject.Find("ThumbTip").GetComponent<ThumbTip>().thumbTipCollided) {servoSignal(1);}
        if (GameObject.Find("PointerTip").GetComponent<PointerTip>().pointerTipCollided) {servoSignal(2);}
        if (GameObject.Find("MiddleTip").GetComponent<MiddleTip>().middleTipCollided) {servoSignal(3);}
        if (GameObject.Find("RingTip").GetComponent<RingTip>().ringTipCollided) {servoSignal(4);}
        if (GameObject.Find("PinkyTip").GetComponent<PinkyTip>().pinkyTipCollided) {servoSignal(5);}
    }

    void servoSignal(int servoNum) {
        _SlPort.WriteLine(Convert.ToString(servoNum));
    }

    void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
        SerialPort sp = (SerialPort)sender;
        string inData = sp.ReadLine();
        Console.WriteLine(inData);
        string[] parsedData = inData.Split(' ');
        int length = parsedData.Length - 1;
        Console.WriteLine("{0} valid data pieces this read", length);
        string identifier = parsedData[0];
        int intIdentifier = 0;
        double dblParsedData = 0.0;
        if (identifier[0] == 'a')
        {
            identifier.Trim('a');
            Int32.TryParse(identifier, out intIdentifier);
            if (intIdentifier > 4) {
                double.TryParse(parsedData[1], out dblParsedData);
                yAccel[intIdentifier] = dblParsedData;
            }
            for (uint i = 1; i < 4; i++)
            {
                double.TryParse(parsedData[i], out dblParsedData);
                switch (i)
                {
                    case 1:
                        xAccel[intIdentifier] = dblParsedData;
                        break;
                    case 2:
                        yAccel[intIdentifier] = dblParsedData;
                        break;
                    case 3:
                        zAccel[intIdentifier] = dblParsedData;
                        break;
                    default:
                        Console.Write("accel switch case returned default");
                        Console.WriteLine(" i was {0}", i);
                        break;
                }
            }
        }
        else
        {
            identifier.Trim('g');
            Int32.TryParse(identifier, out intIdentifier);
            if (intIdentifier > 4) {
                double.TryParse(parsedData[1], out dblParsedData);
                yAccel[intIdentifier] = dblParsedData;
            }
            for (uint i = 1; i < 4; i++)
            {
                double.TryParse(parsedData[i], out dblParsedData);
                switch (i)
                {
                    case 1:
                        xGyro[intIdentifier] = dblParsedData;
                        break;
                    case 2:
                        yGyro[intIdentifier] = dblParsedData;
                        break;
                    case 3:
                        zGyro[intIdentifier] = dblParsedData;
                        break;
                    default:
                        Console.Write("gyro switch case returned default -- ");
                        Console.WriteLine("i was {0}", i);
                        break;
                }
            }
        }
    }
}