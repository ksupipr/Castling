using UnityEngine;
using System.Collections;

// скрипт наведения на цель
public class FindAndShoot : MonoBehaviour {
	
	public float attackRange = 30.0f; // радиус обнаружения и атаки
	public float shootAngleDistance = 10.0f;
	public Transform target;
	public bool shootFlag = true;
	public float outerY = 0.8f; //смещение по высоте для стрельбы
	
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
	//	targetPoint.y = targetPoint.y + outerY;
	    Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
	    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		
		
		Vector3 forward = transform.TransformDirection(Vector3.forward); 
	    Vector3 targetDir = target.position - transform.position; 
		//Debug.Log(Vector3.Angle(forward, targetDir) + "<" + shootAngleDistance);
		if ((Vector3.Angle(forward, targetDir) < shootAngleDistance) && (shootFlag==true)) {
			Shoot();
		}
		

	}
	
	bool CanSeeTarget () {
			if (Vector3.Distance(transform.position, target.position) > attackRange) {
				return false;
			}
		
			RaycastHit hit;
		
			if (Physics.Linecast (transform.position, target.position, out hit)) {
				//return hit.transform == target;
				return true;
			} 
		
			return false;
	}
	
	void Shoot() {
		SendMessage("Fire");
		//	Debug.Log("Shooooot!");
	}
	

}
