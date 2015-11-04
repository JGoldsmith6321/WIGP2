using UnityEngine;
using System.Collections;

public class turnColor : MonoBehaviour {
	public CubeAppear core;
	public int[] cords;
	public bool isPlane = false;
	public bool isActive = false;
	public bool isDepot = false;
	
	// Use this for initialization
	void Start () {
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<CubeAppear>();
	}
	
	void OnMouseEnter()
	{
		if (isDepot == false) {
			GetComponent<Renderer> ().material.color = Color.blue;
		} else {
			GetComponent<Renderer> ().material.color = Color.gray;
		}
	}
	
	void OnMouseExit()
	{
		if (isDepot == false) {
			GetComponent<Renderer> ().material.color = Color.white;
		} else {
			GetComponent<Renderer> ().material.color = Color.black;
		}
	}
	
	
	void  OnMouseDown(){
		core.ThingClicked(cords);
	}
	
	public void SetCords (int[] cordsGet){
		cords = cordsGet;
	}
	
	public void SetColor(){
		GetComponent<Renderer>().material.color = Color.black;
		isDepot = true;
	}
}