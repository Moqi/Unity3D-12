using UnityEngine;
using System.Collections;

public class enityTank : tank {
	public int distanceLook=15;	
	
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.up), out hit, distanceLook))
			if(hit.collider.tag=="Player"){				
				Debug.DrawLine(transform.position, hit.point, Color.yellow);
				Fire ();
			}	
	}
	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag=="Player"){
			Vector3 relativePos = other.transform.position - transform.position;
      		Quaternion rotationn = Quaternion.LookRotation(relativePos);
			Quaternion rotation = Quaternion.Euler(270, rotationn.eulerAngles.y,180);
       	    rotateTank(rotation);
		}
	}
	
}
