using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaneObj : MonoBehaviour{

	public UnityEngine.UI.Text cargoTxt;
	public int[] cords;
	public Vector3[,] allCords;
	public int cargo;
	public int cargoAdd = 10;
	public int cargoMax = 90;
	public int directGo;
	public bool isActive = false;
	public float moveBy = 1.1f;
	public int[] cordsStart;
	public float lastTurnTime = 0;
	public float turnLength = 1.5f;

	void Start (){
	}

	public void StartPlane(int[] at, Vector3[,] allOtherCords) {
		GetComponent<Renderer> ().material.color = Color.red;
		allCords = allOtherCords;
		cordsStart = at;
		cargo = 0;
		directGo = 0;
		cords = at;
		Move ();
	}
	
	public void thingClicked (int[] clicked){
		if (clicked == cords) {
			//SetActive ();
		} else{
			MoveClicked (clicked);
		}
	}
	
	public void OnMouseDown(){//prev: SetActive
		if (isActive == true) {//if previously clicked
			isActive = false;
			GetComponent<Renderer> ().material.color = Color.red;
		} else {// if not
			isActive = true;
			GetComponent<Renderer>().material.color = Color.magenta;
		}
	}
	
	public void MoveClicked(int[] clicked){
		if (isActive == true) {
			cords = clicked;
			GetComponent<Renderer> ().material.color = Color.red;
			Move ();
		}
	}
	
	public void MoveKeys(){// make so it only moves onece per turn
		if (isActive == true) {
			if (directGo == 1) {//up
				cords [0] = (int)((float)cords [0] + moveBy);
			}
			if (directGo == 2) {//down
				cords [0] = (int)((float)cords [0] - moveBy);
			}
			if (directGo == 3) {//left
				cords [1] = (int)((float)cords [1] - moveBy);
			}
			if (directGo == 4) {//right
				cords [1] = (int)((float)cords [1] + moveBy);
			}
			GetComponent<Renderer> ().material.color = Color.red;
		}
	}

	void Move(){
		isActive = false;
		Vector3 newCords = allCords [cords [0], cords [1]];
		newCords.z = -1f; // so it's above the grid
		transform.position = newCords;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= lastTurnTime + turnLength) {
			if (cords[0] == cordsStart[0] && cords[1] == cordsStart[1]){//cords == cordsStart didn't work for some reason
				if (cargo != cargoMax){
					cargo = cargo + cargoAdd;
					cargoTxt.text = "" + cargo;
				}
			}
			//Move ();
			lastTurnTime = Time.time;
		}

	}
}