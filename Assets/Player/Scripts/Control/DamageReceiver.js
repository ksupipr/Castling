var hitPoints = 100.0;
var detonationDelay = 0.0;
var explosion : Transform;
var deadReplacement : Rigidbody;

var linkedObject : GameObject;

private var maxHealth;


var respawn : GameObject;


function Start() {
	maxHealth = hitPoints;
	
	if ((respawn == null) && (gameObject.tag == "Player")) {
		respawn = GameObject.FindGameObjectWithTag("Respawn");
		Respawn();
	}
	
}

function ApplyDamage (damage : float)
{
	if (hitPoints <= 0.0) 
	return;

	hitPoints -= damage; 
	
	if (gameObject.tag == "Player") {
		// эффект при попадании
		gameObject.SendMessage("ShaflCamStart");
	}
	
	
	if (hitPoints <= 0.0)
	{
		var emitter : ParticleEmitter = GetComponentInChildren(ParticleEmitter); 
		if (emitter)
		emitter.emit = true;
		Invoke("DelayedDetonate", detonationDelay);
	}
}

function DelayedDetonate ()
{
	BroadcastMessage ("Detonate");
}

function Detonate ()
{
	
	Die();
	
	if (explosion)
	Instantiate (explosion, transform.position, transform.rotation);
	
	if (deadReplacement)
	{
		var dead : Rigidbody = Instantiate(
		deadReplacement, transform.position, transform.rotation);
		dead.rigidbody.velocity = rigidbody.velocity; 
		dead.angularVelocity = rigidbody.angularVelocity;
	}
	
	var emitter : ParticleEmitter = GetComponentInChildren(ParticleEmitter); 
	if (emitter)
	{
		emitter.emit = false; emitter.transform.parent = null;
	}
}


function Die() {

if (linkedObject != null) {
	linkedObject.gameObject.SendMessage("ActivDie");
}

if (respawn == null) {
		Destroy(gameObject);
	} else {
	// если есть респ
		Respawn2();
	}
}

function Respawn() {
	hitPoints = maxHealth;
	
	
	var positionResp = respawn.transform.position;
	
	positionResp.y = positionResp.y+gameObject.transform.localScale.y+1f;
	
	gameObject.transform.position = positionResp;
}

function Respawn2() {
	hitPoints = maxHealth;
	Application.LoadLevel(Application.loadedLevel);
}