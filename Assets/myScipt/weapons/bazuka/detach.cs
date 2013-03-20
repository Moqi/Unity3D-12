using UnityEngine;
using System.Collections;

public class detach : MonoBehaviour {

	// Use this for initialization
	public void detachExplosion(){
		transform.DetachChildren();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
