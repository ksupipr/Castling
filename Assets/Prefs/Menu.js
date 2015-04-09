var isQuitBtn : boolean = false;
 
private var startColor : Color;
public var eventMenu = 1;

function Start() {
	Screen.showCursor = true; 
	Screen.lockCursor = false;
	startColor = renderer.material.color;
	Debug.Log(startColor);
}
  
  
function OnMouseEnter ()
{
Debug.Log("enter");
	renderer.material.color = Vector4(0.6, 0, 0, 1);
}
 
function OnMouseExit ()
{
Debug.Log("exit");
	renderer.material.color = startColor;
}
 
function OnMouseUp()
{
Debug.Log("up");
	if(isQuitBtn)
	{
		Application.Quit();
	}
	else
	{
		if (eventMenu == 1)
			Application.LoadLevel("7dFPS");
		if (eventMenu == 2)
			Application.LoadLevel("menu");
}
}