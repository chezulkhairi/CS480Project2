using UnityEngine;
using System.Collections;

public class DataReader : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Read in input
		string text = System.IO.File.ReadAllText("Assets/test.txt");
		string[] rawNums = text.Split (' ');
		// Convert input to floats
		float[] nums = new float[3];
		nums [0] = float.Parse(rawNums [0]);
		nums [1] = float.Parse(rawNums [1]);
		nums [2] = float.Parse(rawNums [2]);
		// Create and position cube representing object in space
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		float x = nums [0] * Mathf.Cos (nums [1]);
		float y = nums [0] * -Mathf.Cos (nums [2]);
		float z = nums [0] * Mathf.Sin (nums [1]);
		cube.transform.position = new Vector3(x, y, z);
	}
}
