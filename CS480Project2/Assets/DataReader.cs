using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class DataReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("readSerialPort", 0, 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	void readSerialPort () {
		SerialPort port = new SerialPort ("/dev/cu.usbmodemFA131", 9600);
		port.Open ();
		string text = port.ReadLine ().ToString ();
		string[] rawNums = text.Split (' ');
		if (rawNums.Length == 3) { // Avoid bad data
			// Convert input to floats
			float[] nums = new float[3];
			nums [0] = float.Parse (rawNums [0]);
			nums [1] = float.Parse (rawNums [1]);
			nums [2] = float.Parse (rawNums [2]);
			// Create and position cube representing object in space
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			float x = nums [0] * Mathf.Cos (nums [1]);
			float y = 0; //nums [0] * -Mathf.Cos (nums [2]);
			float z = nums [0] * Mathf.Sin (nums [1]);
			cube.transform.position = new Vector3 (x, y, z);
		}
	}
}
