#pragma strict

function Start () {
	SelectWeapon(0);
}

function Update () {
	if(Input.GetButton("Fire1"))
		BroadcastMessage("Fire");
	if(Input.GetKeyDown("1"))
		SelectWeapon(0);
	if(Input.GetKeyDown("2"))
		SelectWeapon(1);	
}

function SelectWeapon(index:int){
	for (var i = 0; i<transform.childCount; i++){
		if(i == index)
			transform.GetChild(i).gameObject.SetActiveRecursively(true);
		else
			transform.GetChild(i).gameObject.SetActiveRecursively(true);
	}
}