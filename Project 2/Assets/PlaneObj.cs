﻿using UnityEngine;
using System.Collections;

public class PlaneObj : MonoBehaviour{
	
	public CubeAppear core;
	public TextCode cargoTxt;
	public GameObject txt;
	public int[] cords;
	public int[] newCords;
	public Vector3[,] allCords;
	public int cargo;
	public int cargoAdd = 10;
	public int cargoMax = 90;
	public bool isActive = false;
	public int directToGo;
	public int[] cordsStart;
	public float lastTurnTime = 0;
	public float turnLength = 1.5f;
	public int[] depot;
	public int[] cordsGoToClicked;
	public bool goToClicked = false;
	//public Color active = new Color();
	
	void Start (){
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<CubeAppear>();
		cargoTxt = txt.GetComponent<TextCode>();
	}
	
	public void StartPlane(int[] at, Vector3[,] allOtherCords, int[] depotAt, int[] start) {
		GetComponent<Renderer> ().material.color = Color.red;
		depot = depotAt;
		allCords = allOtherCords;
		cordsStart = start;// if I set it to = at, it changes, this seemed like an easy fix
		newCords = at;
		cargo = 0;
		cords = at;
		Vector3 newCordsVect = allCords [newCords [0], newCords [1]];
		newCordsVect.z = -1f; // so it's above the grid
		transform.position = newCordsVect;
	}
	
	public void thingClicked (int[] clicked){
		if (clicked == cords) {
		} else{
			goToClicked = true;
			cordsGoToClicked = clicked;
		}
	}
	
	
	public void OnMouseDown(){//prev: SetActive
		if (isActive == true) {//if previously clicked
			isActive = false;
			GetComponent<Renderer> ().material.color = Color.red;
			goToClicked = false;// it stops if you deactivate it, and 'forgets' the cords you told it to go to.
		} else {// if not
			isActive = true;
			GetComponent<Renderer>().material.color = Color.yellow;
		}
	}
	
	void MoveClicked(){//move to clicked spot slowly
		if (isActive == true) {
			newCords = cords;
			// the x spot:
			if (cords[0] > cordsGoToClicked[0]){
				newCords[0]--;
			}
			if (cords[0] < cordsGoToClicked[0]){
				newCords[0]++;
			}
			// the y spot:
			if (cords[1] > cordsGoToClicked[1]){
				newCords[1]--;
			}
			if (cords[1] < cordsGoToClicked[1]){
				newCords[1]++;
			}
		}
	}
	
	public void DirectSet(int directGo){
		directToGo = directGo;
	}
	
	public void MoveKeys(){
		if (isActive == true) {
			if (directToGo == 1 && cords[1] < 8) {//up
				newCords [1] = cords [1] + 1;
				goToClicked = false;
			}
			if (directToGo == 2 && cords[1] > 0) {//down
				newCords [1] = cords [1] - 1;
				goToClicked = false;
			}
			if (directToGo == 3 && cords[0] > 0) {//left
				newCords [0] = cords [0] - 1;
				goToClicked = false;
			}
			if (directToGo == 4 && cords[0] < 15) {//right
				newCords [0] = cords [0] + 1;
				goToClicked = false;
			}
		}
	}
	
	void Move(){
		MoveKeys ();
		if (isActive == true && goToClicked == false) {// teleports to arrow button placement
			Vector3 newCordsVect = allCords [newCords [0], newCords [1]];
			newCordsVect.z = -1f; // so it's above the grid
			transform.position = newCordsVect;
			cords = newCords;
		}
		
		if (isActive == true && goToClicked == true) {
			MoveClicked ();
			Vector3 newCordsVect = allCords [newCords [0], newCords [1]];
			newCordsVect.z = -1f; // so it's above the grid
			transform.position = newCordsVect;
			cords = newCords;
		}
		
		if (cords[0] == depot[0] && cords[1] == depot[1]) {
			core.UpdateScore(cargo);
			cargo = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= lastTurnTime + turnLength) {
			if (cords[0] == cordsStart[0] && cords[1] == cordsStart[1]){//cords == cordsStart didn't work for some reason
				if (cargo != cargoMax){
					cargo = cargo + cargoAdd;
				}
			}
			Move ();
			cargoTxt.SetAll(""+cargo,allCords [cords [0], cords [1]]);
			directToGo = 0;
			lastTurnTime = Time.time;
		}
		
	}
}