using UnityEngine;
using System.Collections;

public class FindAndRun : MonoBehaviour {
	
	public float agrRange = 30.0f; // радиус обнаружения
	public int speed = 6;
	
	public Transform target;
	
	void Start () {
		if (target == null && GameObject.FindWithTag("Player"))
		target = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
		
		if (target == null) {
			return;
		}
		
		//Debug.Log(CanSeeTarget ());
		
		if (!CanSeeTarget ()) {
			return;
		}
		
		
		
		// поворот в сторону игрока
		Vector3 targetPoint = target.position;
	
		

	    Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
	  //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		targetRotation.x = transform.rotation.x;
		targetRotation.z = transform.rotation.z;
			
		  transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
		
		//transform.RotateAround (Vector3.zero, 20 * Time.deltaTime, Vector3.forward);
		

		Vector3 forward = transform.TransformDirection(Vector3.forward); 
	    Vector3 targetDir = target.position - transform.position; 
		//Debug.Log(Vector3.Angle(forward, targetDir) + "<" + shootAngleDistance);
		if (Vector3.Angle(forward, targetDir) < 20) {
			Vector3 speedV3 = transform.forward;
			
			
            rigidbody.MovePosition(rigidbody.position + speedV3 * (Time.deltaTime*speed));
    
		}
		
		 
	}
	
	bool CanSeeTarget () {
			if (Vector3.Distance(transform.position, target.position) > agrRange) {
				return false;
			}
		
			RaycastHit hit;
		
		//    if (Physics.Raycast(transform.position, target.position, out Hit, Range)) {
			if (Physics.Linecast (transform.position, target.position, out hit)) {
				//return hit.transform == target;
				return true;
			}
		
		
			return false;
	}
	

}
