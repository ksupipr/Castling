using UnityEngine;
using System.Collections;

public class endTheGame : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		Screen.showCursor = true; 
		Screen.lockCursor = false;
		Application.LoadLevel("end");
	}
}


