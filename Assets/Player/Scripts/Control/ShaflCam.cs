using UnityEngine;
using System.Collections;

public class ShaflCam : MonoBehaviour {
	
	private Camera playerCamera;
	private Vector3 fpp;
	private Vector3 fpp_now;
	private bool shaf = false;

	void Start () {
		playerCamera = Camera.mainCamera;
		fpp = playerCamera.transform.localPosition;
	}
	
	void Update () {
		if (shaf==true) {

				fpp_now = playerCamera.transform.localPosition;
				fpp_now.x = fpp_now.x + (0.1f * Random.Range(-1f, 1f));
				fpp_now.y= fpp_now.y + (0.1f * Random.Range(-1f, 1f));
				playerCamera.transform.localPosition = fpp_now;
				 InvokeRepeating("ShaflCamStop", 0.2f, 1);
					
				
			}
		
	}
	
	void ShaflCamStart() {
		shaf = true;
	}

	void ShaflCamStop() {
		shaf = false;
		playerCamera.transform.localPosition = fpp;
	}

}
