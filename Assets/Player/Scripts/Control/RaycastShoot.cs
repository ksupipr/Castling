using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour {

	public float Force = 1000f;
	public float Range = 1000f;
	public Transform playerObj;
	public Transform crossHairs;

	void Start () {
		
	}
	
	void Update () {
		
		
		if (Input.GetKey(KeyCode.Escape))
		{
			//Debug.Log("esc");
			Application.LoadLevel("menu");
			//Application.Quit();
		}
		
		
		if (Input.GetMouseButtonDown(0)) {
			Fire();
		}
		
		
		HightLite();
	
	}
	
	void HightLite() {
		Vector3 DirectionRay = transform.TransformDirection(Vector3.forward);
//		RaycastHit Hit;
		
		Debug.DrawLine(transform.position , DirectionRay *Force, Color.red);
	}
	
	void Fire() {
		Vector3 DirectionRay = transform.TransformDirection(Vector3.forward);
		
		RaycastHit Hit;
		
		
		
		Debug.DrawLine(transform.position , DirectionRay *Force, Color.red);
		
				
		if (Physics.Raycast(transform.position, DirectionRay, out Hit, Range)) {
			
			// тут писать что делать при попадании... в частности в зависимости от тега
			if (Hit.transform.tag == "Bot_teleported" ) {
					//Hit.rigidbody.AddForceAtPosition(DirectionRay * Force, Hit.point);
					
					Hit.collider.enabled = false;
					playerObj.collider.enabled = false;
					Vector3 playerPosition = playerObj.transform.position;
					//Vector3 hitPosition = new Vector3(Hit.transform.position.x, playerObj.transform.position.y, Hit.transform.position.z); 
					Vector3 hitPosition = new Vector3(Hit.transform.position.x, Hit.transform.position.y+1, Hit.transform.position.z); 
					//Vector3 hitPosition = Hit.transform.position;
					playerObj.transform.position = hitPosition;
					Hit.transform.position = playerPosition;
					Hit.collider.enabled = true;
					playerObj.collider.enabled = true;
				
					audio.Stop();
					audio.Play();
					
					
			}
		}
	}
}
