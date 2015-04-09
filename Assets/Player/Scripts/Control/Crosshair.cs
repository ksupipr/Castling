using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public Texture2D crosshairTexture;
	public int xOver = 0;
	public int yOver = 0;
	Rect position;
	
	// Use this for initialization
	void Start () {
		position = new Rect(((Screen.width - crosshairTexture.width)/2)+xOver, ((Screen.height-crosshairTexture.height)/2)+yOver, crosshairTexture.width, crosshairTexture.height);
		//position = new Rect(transform.position.y, transform.position.x, crosshairTexture.width, crosshairTexture.height);
	}
	
	
	void OnGUI () {
		GUI.DrawTexture(position, crosshairTexture);
	}
}
