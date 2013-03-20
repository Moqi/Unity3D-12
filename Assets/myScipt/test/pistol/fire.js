#pragma strict

var projectile : Rigidbody;
var speed = 20;

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Fire1")){
		var instantiatedProjective : Rigidbody = Instantiate(projectile , transform.position, transform.rotation);
		instantiatedProjective.velocity = transform.TransformDirection(Vector3(0,0,speed));
		Physics.IgnoreCollision(instantiatedProjective.collider, transform.root.collider);
	}

}