using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeAppear : MonoBehaviour {

	public Text txt;
	public int score = 0;
	public GameObject cube;
	public GameObject planeObj;
	public PlaneObj thePlane;
	public float xSpotStart = -8.25f;
	public float xSpot;
	public float ySpot = -4.4f;
	public static int xGrid = 16;
	public static int yGrid = 9;
	public float moveBy = 1.1f;
	public turnColor[,] allSpaces = new turnColor[xGrid,yGrid];
	public Vector3[,] allCords = new Vector3[xGrid,yGrid];
	public int[] depot;// = new int[]{15,0};

	// Use this for initialization
	void Start () {
		depot = new int[]{15,0};
		txt.text = ("Score: " + score); 
		GameObject aPlane = Instantiate(planeObj,new Vector3(0,0,0),Quaternion.identity) as GameObject;
		thePlane = aPlane.GetComponent<PlaneObj>();
		for (int y = 0; y < yGrid; y++) {
			xSpot = xSpotStart;
			for(int x = 0; x < xGrid; x++){// the x side
				Vector3 pos = new Vector3(xSpot,ySpot,0);
				GameObject thisCube = Instantiate(cube,pos,Quaternion.identity) as GameObject;
				allSpaces[x,y] = thisCube.GetComponent<turnColor>();
				allCords[x,y] = pos;
				int[] cords = new int[]{x,y};
				allSpaces[x,y].SetCords(cords);
				xSpot = xSpot + moveBy;
			}
			ySpot = ySpot + moveBy;
		}
		allSpaces [depot[0],depot[1]].SetColor ();
		thePlane.StartPlane (new int[]{0,8}, allCords, depot);
	}

	public void ThingClicked (int[] cordsClicked){
		thePlane.thingClicked(cordsClicked);
	}

	public void UpdateScore (int amnt){
		score = score + amnt;
		txt.text = ("Score: " + score); 
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			thePlane.DirectSet (1);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			thePlane.DirectSet (2);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			thePlane.DirectSet (3);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			thePlane.DirectSet (4);
		}
	}
}
