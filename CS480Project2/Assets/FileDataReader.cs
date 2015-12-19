using UnityEngine;
using System.Collections.Generic;

public class FileDataReader : MonoBehaviour {

	Dictionary<int, int> ranges = new Dictionary<int, int> ();
	float x;
	float y;
	float z;

	// Use this for initialization
	void Start () {
		// 100 cm range
		for (int idx = 0; idx < 5; idx++) {
			ranges[510 + idx] = 100;
		}
		// 105 cm range
		for (int idx = 0; idx < 5; idx++) {
			ranges[500 + idx] = 105;
		}
		// 110 cm range
		for (int idx = 0; idx < 10; idx++) {
			ranges[485 + idx] = 110;
		}
		// 115 cm range
		for (int idx = 0; idx < 9; idx++) {
			ranges[476 + idx] = 115;
		}
		// 120 cm range
		for (int idx = 0; idx < 5; idx++) {
			ranges[470 + idx] = 120;
		}
		// 125 cm range
		for (int idx = 0; idx < 8; idx++) {
			ranges[457 + idx] = 125;
		}
		// 130 cm range
		for (int idx = 0; idx < 6; idx++) {
			ranges[450 + idx] = 130;
		}
		// 135 cm range
		for (int idx = 0; idx < 6; idx++) {
			ranges[443 + idx] = 135;
		}
		// 140 cm range
		for (int idx = 0; idx < 7; idx++) {
			ranges[432 + idx] = 140;
		}

		string line;
		// Read the file and display it line by line.
		System.IO.StreamReader file = new System.IO.StreamReader("/Users/jabyam/Documents/jrbyam/CS480/CS480Project2/CS480Project2/Assets/test.txt");
		while((line = file.ReadLine()) != null) {
			string[] rawNums = line.Split (' ');
			string voltageStr = rawNums[0];
			float voltage;
			if (float.TryParse(voltageStr, out voltage)) {
				if (ranges.ContainsKey ((int) voltage)) {
					// Convert input to floats
					float[] nums = new float[3];
					nums [0] = ranges[(int) voltage];
					nums [1] = float.Parse (rawNums [1]);
					nums [2] = float.Parse (rawNums [2]);
					// Create and position cube representing object in space
					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					cube.transform.parent = GameObject.Find ("Cubes").transform;
					x = nums [0] * Mathf.Cos (Mathf.PI / 180 * nums [1]);
					y = nums [0] * Mathf.Sin (Mathf.PI / 180 * nums [2]);
					z = nums [0] * Mathf.Sin (Mathf.PI / 180 * nums [1]);
					cube.transform.position = new Vector3 (x, y, z);
					float cubeDimension = 10;
					cube.transform.localScale = new Vector3 (cubeDimension, cubeDimension, cubeDimension);
				}
			}
		}
		file.Close();
	}
}
