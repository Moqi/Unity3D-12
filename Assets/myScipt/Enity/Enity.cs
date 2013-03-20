using UnityEngine;
using System.Collections;

public class Enity : MonoBehaviour {
	public float Health;
	public float currentHealth;
	void Start (){ 
		if(Health==0){
			Health = 100.0f;
			currentHealth = Health;
		}
		if(currentHealth==0)
			currentHealth = Health;
	
	}	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.F))	
			ShiftHealth(-10.0f);
		 
	}
	void ShiftHealth(float cheche){
		currentHealth += cheche;
		if(currentHealth<0)
			currentHealth = 0;
		if(currentHealth==0)
			Dead ();
		
	}
	void Dead(){
		Debug.Log(gameObject.tag +" Dead");
	}
	
}
