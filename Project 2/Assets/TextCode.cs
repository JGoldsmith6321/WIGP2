using UnityEngine;
using System.Collections;

public class TextCode : MonoBehaviour {

	public UnityEngine.TextMesh compTxt;

	// Use this for initialization
	void Start () {
		compTxt = GetComponent<TextMesh>();
	}

	public void SetAll (string txt, Vector3 place){
		transform.position = place;
		compTxt.text = txt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
