using UnityEngine;
using System.Collections;

public class Ammount : MonoBehaviour {
	public int count = 10;
	public tankPlayer tank;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag=="Player"){
			tank = other.gameObject.GetComponent<tankPlayer>();
			tank.ammo += count;
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
