var explosionRadius = 3.0;
var explosionPower = 10.0;
var explosionDamage = 100.0;
var explosionTime = 1.0;
var i_grab_layer : int = LayerMask.NameToLayer("Default");

function Start () {
	var explosionPosition = transform.position;
	var colliders: Collider[]= Physics.OverlapSphere(explosionPosition, explosionRadius, explosionRadius);
	for (var hit in colliders){
		if(!hit)
			continue;
		if(hit.rigidbody){			
			hit.rigidbody.AddExplosionForce(explosionPower,explosionPosition, explosionRadius, 3.0);			
			var closestPoint = hit.rigidbody.ClosestPointOnBounds(explosionPosition);
			var distance = Vector3.Distance(closestPoint, explosionPosition);			
			var hitPoints = 1.0 - Mathf.Clamp01(distance / explosionRadius);
			hitPoints *= explosionDamage;			
			hit.rigidbody.SendMessageUpwards("ShiftHealth", -hitPoints, SendMessageOptions.DontRequireReceiver);
			
		}
	}
	Destroy(gameObject, explosionTime);
}

