var explosion: GameObject;
var timeOut = 5.0;



function Start () {
	Invoke("Kill", timeOut);
	//коррекция для танков
	transform.eulerAngles.x += 90;
	transform.eulerAngles.z += 180;
}

function OnCollisionEnter(collision: Collision){
	var contact : ContactPoint = collision.contacts[0];
	var rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
	Instantiate (explosion, contact.point, rotation);
	Kill();
}

function Kill(){
	var emitter : ParticleEmitter = GetComponentInChildren(ParticleEmitter);
	if(emitter)
		emitter.emit = false;
	
	script = GetComponentInChildren(detachPoint);
	script.detachExplosion();
	Destroy(gameObject);
}

@script RequireComponent (Rigidbody)