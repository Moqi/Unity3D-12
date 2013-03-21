using UnityEngine;
using System.Collections;

public class tankPlayer : tank {
	public int typeControll = 1;
	public int rotateAngleTank;
	void Awake(){
		rotateAngleTank = (int)transform.rotation.eulerAngles.y+180;
		for(;;){
			if(rotateAngleTank>360)
				rotateAngleTank -= 360;
			else if (rotateAngleTank<0)
				rotateAngleTank += 360;
			else break;
		}
	}
	void Start () {
	}	
	void Update () {
//     	     _thisController.Move(
//      	 _thisTransform.forward * 
//      	 moveSpeed * Time.deltaTime * 
//      	 Input.GetAxis("Vertical"));
//	
//   	     Quaternion rot = Quaternion.AngleAxis(
//   	         turnSpeed * Time.deltaTime * 
//   	         Input.GetAxis("Horizontal"),
//    	            Vector3.up);
//
//    	    _thisTransform.rotation *= rot;
// mb smth like this?
		if(typeControll==1){
				if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
					ForceTank(speed, 0);			
				}
				if(Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))	{
					ForceTank(speed, 180);			
				}
				if(Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))	{
					ForceTank(speed, 90);
				}
				if(Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))	{
					ForceTank(speed, 270);			
				}
				if(Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))	{
					ForceTank(speed, 45);			
				}
				if(Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))	{
					ForceTank(speed, 135);			
				}
				if(Input.GetKey(KeyCode.S)&& Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))	{
					ForceTank(speed, 215);			
				}
				if(Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))	{
					ForceTank(speed, 305);		
				}			
		}else if(typeControll == 2){
				bool pov = false;
				if(Input.GetKey(KeyCode.D)){
					rotateAngleTank++;
					if (rotateAngleTank>360)
						rotateAngleTank = 0;
					pov = true;
				}
				if(Input.GetKey(KeyCode.A)){
					rotateAngleTank--;
					if (rotateAngleTank<0)
						rotateAngleTank = 360;
				    pov = true;
				}					
				if(Input.GetKey(KeyCode.W)){
					if(pov){
						FroceTankAlter(speed*0.7f);
						pov = false;
					}else
					FroceTankAlter(speed);
				}
				if(Input.GetKey(KeyCode.S)){
					if(pov){
						FroceTankAlter(-speed*0.7f);
						pov = false;
					}else
					FroceTankAlter(-speed);
				}
				rotateTank(rotateAngleTank);
			
		}
		if(Input.GetKey(KeyCode.Space))
			Fire();
	
	}
}
