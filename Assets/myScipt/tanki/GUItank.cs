using UnityEngine;
using System.Collections;

public class GUItank : MonoBehaviour {
	public GameObject target;
	public tankPlayer tank;
		
	// Use this for initialization
	void Start () {
		tank = target.GetComponent<tankPlayer>();
	}
	
	// Update is called once per frame
	void OnGUI(){
		GUI.Box(new Rect(10,10,50,20),tank.currentHealth.ToString());
	}
	
	void Update () {
	}
}
