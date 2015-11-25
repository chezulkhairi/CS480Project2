using UnityEngine;
using System.Collections;

public class DataReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string text = System.IO.File.ReadAllText("Assets/test.txt");
        string[] nums = text.Split (' ');
        GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
        float x = 
        float y =
        float z =
        cube.transform.position = new Vector3(x, y, z);
	}

	// Update is called once per frame
	void Update () {

	}
}
