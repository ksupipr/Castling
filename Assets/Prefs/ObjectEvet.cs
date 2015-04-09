using UnityEngine;
using System.Collections;

public class ObjectEvet : MonoBehaviour {

	public int activDieCount = 1;
	
	void ActivDie() {
		activDieCount--;
		
		if (activDieCount <= 0) {
			Destroy(gameObject);
		}
	}
}
