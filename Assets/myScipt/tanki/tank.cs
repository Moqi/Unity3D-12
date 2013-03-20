using UnityEngine;
using System.Collections;

public class tank : MonoBehaviour {
	public float speed;
	public float Health;
	public float currentHealth;
	public float smooth;	
	public Rigidbody projectile;
	public Transform SpawnFire;
    public int initialSpeed;
    public float reloadTime;
	public int ammo;
	protected float lastShot;
	
	
	void Start () {
		if(speed == 0)
			speed = 1;
		if(gameObject.tag != "player"){
			ammo = -1;
		}			
		if(Health==0){
			Health = 100.0f;
			currentHealth = Health;
		}
		if(currentHealth==0)
			currentHealth = Health;
		if(smooth == 0)
			smooth = 5.0f;
		
		if(initialSpeed==0)
			initialSpeed = 30;
		if(reloadTime == 0)
			reloadTime = 0.5f;
		if(!SpawnFire)
			SpawnFire = transform;
		lastShot = -10.0f;
	}	
	void Update () {
			
	}
	public void Fire(){
		if(ammo<0){
			if(Time.time > reloadTime + lastShot){
				Rigidbody instantiatedProjective  = new Rigidbody();
				instantiatedProjective = Instantiate(projectile , SpawnFire.position, SpawnFire.rotation) as Rigidbody;			
				instantiatedProjective.velocity = transform.TransformDirection(new Vector3(0,initialSpeed,0));
				Physics.IgnoreCollision(instantiatedProjective.collider, transform.collider);
				lastShot = Time.time;
			}
		} else {
			if(Time.time > reloadTime + lastShot && ammo > 0){
				Rigidbody instantiatedProjective  = new Rigidbody();
				instantiatedProjective = Instantiate(projectile , SpawnFire.position, SpawnFire.rotation) as Rigidbody;			
				instantiatedProjective.velocity = transform.TransformDirection(new Vector3(0,initialSpeed,0));
				Physics.IgnoreCollision(instantiatedProjective.collider, transform.collider);
				lastShot = Time.time;
				ammo--;
				if(ammo < 0)
					ammo = 0;
			}
		}
	}
	public void ShiftHealth(float cheche){
		currentHealth += cheche;
		if(currentHealth<0)
			currentHealth = 0;
		currentHealth = Mathf.Round(currentHealth);
		if(currentHealth==0)
			Dead ();
		
	}
	public void ForceTank(float speed, int angleTank){
		rigidbody.AddForce(transform.up * speed, ForceMode.Impulse);
		Quaternion target = Quaternion.Euler(270, angleTank,180);
    	transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);		
	}
	public void rotateTank(int angleTank){
		Quaternion target = Quaternion.Euler(270, angleTank,180);
    	transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);		
	}
	public void rotateTank(Quaternion angleTank){
    	transform.rotation = Quaternion.Slerp(transform.rotation, angleTank, Time.deltaTime * smooth);		
	}
	public void FroceTankAlter(float speed){
		rigidbody.AddForce(transform.up * speed, ForceMode.Impulse);
	}
	protected void Dead(){
		Destroy(gameObject);
	}
}
