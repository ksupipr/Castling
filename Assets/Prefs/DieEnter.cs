using UnityEngine;
using System.Collections;

public class DieEnter : MonoBehaviour {

	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		col.SendMessage("Die", null, SendMessageOptions.DontRequireReceiver);
	}
}

