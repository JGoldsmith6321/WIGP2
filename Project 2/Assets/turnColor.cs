using UnityEngine;
using System.Collections;

public class turnColor : MonoBehaviour {
	public GameObject[] cubes;

	// Use this for initialization
	void Start () {
		cubes = GameObject.FindGameObjectsWithTag ("cube");
	}
	void  OnMouseDown(){
		foreach (GameObject aCube in cubes) {
			aCube.GetComponent<Renderer>().material.color = Color.white;
		}
		GetComponent<Renderer>().material.color = Color.red;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
