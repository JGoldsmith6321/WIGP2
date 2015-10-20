using UnityEngine;
using System.Collections;

public class CubeAppear : MonoBehaviour {
	public GameObject cube;
	public float xSpotStart = -8.25f;
	public float xSpot;
	public float ySpot = -4.4f;
	public static int xGrid = 16;
	public static int yGrid = 9;
	public float moveBy = 1.1f;
	public turnColor[,] allSpaces = new turnColor[xGrid,yGrid];
	public int[] lastPlaneClicked;
	public int[] lastActiveClicked = new int[]{0,8};
	public bool readyMovePlane = false;

	// Use this for initialization
	void Start () {
		for (int y = 0; y < yGrid; y++) {
			xSpot = xSpotStart;
			for(int x = 0; x < xGrid; x++){// the x side
				Vector3 pos = new Vector3(xSpot,ySpot,0);
				GameObject thisCube = Instantiate(cube,pos,Quaternion.identity) as GameObject;
				allSpaces[x,y] = thisCube.GetComponent<turnColor>();
				int[] cords = new int[]{x,y};
				allSpaces[x,y].SetCords(cords);
				xSpot = xSpot + moveBy;
			}
			ySpot = ySpot + moveBy;
		}
		lastPlaneClicked = new int[]{0,8};
		allSpaces[0,8].IsPlane(true);
	}

	public void ThingClicked (int[] cordsClicked){
		bool thisSpacePlane = allSpaces [cordsClicked [0], cordsClicked [1]].isPlane;
		bool thisSpaceActive = allSpaces [cordsClicked [0], cordsClicked [1]].isActive;

		if (thisSpaceActive == false && thisSpacePlane == false && readyMovePlane == true) {//totally empty, and a plane is active
			allSpaces [lastPlaneClicked [0], lastPlaneClicked [1]].IsPlane(false);//last plane space is empty
			allSpaces [cordsClicked [0], cordsClicked [1]].IsPlane(true);//new plane space set
			allSpaces [lastActiveClicked [0], lastActiveClicked [1]].IsActive(false);//last active spot off
			lastPlaneClicked = cordsClicked;
			readyMovePlane = false;
		}
		else if (thisSpacePlane == true && thisSpaceActive == true) {
			allSpaces [cordsClicked [0], cordsClicked [1]].IsActive(false);
			readyMovePlane = false;
		}
		else if (thisSpacePlane == true) {
			allSpaces [cordsClicked [0], cordsClicked [1]].IsActive(true);
			lastActiveClicked = cordsClicked;
			readyMovePlane = true;
		}
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
