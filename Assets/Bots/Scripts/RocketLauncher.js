var projectile : Rigidbody; 
var initialSpeed = 10.0; 
var reloadProjTime = 0.5; 
var reloadTime = 5.0; 
var ammoCount = 20; 
private var lastShot = -10.0;
private var maxAmmo;

var bulletSpawnPoint: Transform;

function Start()
{
	maxAmmo = ammoCount;
	
	}


function Fire ()
{

if (Time.time > reloadProjTime + lastShot && ammoCount > 0)
	{
	//Debug.Log("piu");
	
	var instantiatedProjectile : Rigidbody = Instantiate (projectile, 
	bulletSpawnPoint.position, transform.rotation);
	
	instantiatedProjectile.velocity = transform.TransformDirection( Vector3 (0, 0, initialSpeed));
		
	lastShot = Time.time; 
	ammoCount-- ;
	}
	
if (Time.time > reloadTime + lastShot && ammoCount <= 0) {
		lastShot = Time.time; 
		ammoCount = maxAmmo;
	}
}