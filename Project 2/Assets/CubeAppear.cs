using UnityEngine;
using System.Collections;

public class CubeAppear : MonoBehaviour {
	public GameObject cube;
	public float x = -10.0f;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 16; i++){
			Instantiate(cube,new Vector3(x,0,0),Quaternion.identity);
			x = x + 1.1f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
