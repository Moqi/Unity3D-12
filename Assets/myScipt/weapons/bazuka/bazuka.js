var projectile : Rigidbody;
var initialSpeed = 30;
var reloadTime = 0.5;
var ammoCount = 20;
private var lastShot = -10.0;


function Fire(){
	if(Time.time > reloadTime + lastShot && ammoCount > 0){
		audio.Play();
		var instantiatedProjective : Rigidbody = Instantiate(projectile , transform.position, transform.rotation);
		instantiatedProjective.transform.eulerAngles.x += 90;
		instantiatedProjective.velocity = transform.TransformDirection(Vector3(0,0,initialSpeed));
		Physics.IgnoreCollision(instantiatedProjective.collider, transform.root.collider);
		lastShot = Time.time;
		ammoCount--;
	}
	
}