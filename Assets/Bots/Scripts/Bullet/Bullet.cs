using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	private float liveTime = 10f;
	private float respTime = 0;
	
	public AudioClip Shoot;
	public AudioClip Fly;
	public AudioClip Exlosion;
	public int damage = 10;
	
	void Start () {
		//audio.Play("Rocket launch");
		audio.PlayOneShot(Shoot);
		audio.PlayOneShot(Fly);
		
		//audio.Play("Rocket fkight loop");
	}
	
	void OnCollisionEnter(Collision collision) {
		Kill();
		
		collision.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
		/*	
		foreach (ContactPoint contact in collision.contacts) {
			Debug.Log("contact = "+contact);
			//Instantiate(Sparks, transform.position, Quaternion.identity);
		}
		*/
		
	}
	
	void Update () {
	
		respTime += Time.deltaTime;
		if (respTime>liveTime) {
			Kill();
		}
		
	}
	
	void Kill() {
		audio.PlayOneShot(Exlosion);
		//audio.Stop("Rocket fkight loop");
		//audio.Play("Explosion short");
		Destroy(gameObject);
	}
}
