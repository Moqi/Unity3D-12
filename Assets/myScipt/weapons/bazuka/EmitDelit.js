#pragma strict
var timeOut = 5.0;
function Start () {
	Invoke("Kill", timeOut);
}

function Kill(){
	Destroy(gameObject);
}