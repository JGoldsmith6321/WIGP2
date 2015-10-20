using UnityEngine;
using System.Collections;

public class turnColor : MonoBehaviour {
	public CubeAppear core;
	public int[] cords;
	public bool isPlane = false;
	public bool isActive = false;

	// Use this for initialization
	void Start () {
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<CubeAppear>();
	}

	void  OnMouseDown(){
		core.ThingClicked(cords);
	}

	public void SetCords (int[] cordsGet){
		cords = cordsGet;
	}

	public void IsActive (bool setActive){
		isActive = setActive;
		SetColor ();
	}

	public void IsPlane (bool plane){
		isPlane = plane;
		SetColor ();
	}
	void SetColor(){
		if (isActive == true && isPlane == true) {
			GetComponent<Renderer>().material.color = Color.magenta;
		}
		else if (isActive == true) {
			GetComponent<Renderer>().material.color = Color.blue;
		}
		else if (isPlane == true) {
			GetComponent<Renderer>().material.color = Color.red;
		}
		else{
			GetComponent<Renderer>().material.color = Color.white;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
