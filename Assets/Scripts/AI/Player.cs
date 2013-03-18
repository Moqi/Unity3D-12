using UnityEngine;

public class Player : MonoBehaviour 
{
    public float moveSpeed;
    public float turnSpeed;

    private CharacterController _controller;
    private Transform _thisTransform;

    public void Awake()
    {
        moveSpeed = 5;
        turnSpeed = 100;
    }

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _thisTransform = transform;
    }

    public void FixedUpdate()
    {
        _controller.Move(_thisTransform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical") +
            Vector3.down * 10.0f * Time.deltaTime);
        
        Quaternion rot = Quaternion.AngleAxis(
            turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),Vector3.up);
        _thisTransform.rotation *= rot;
    }
	
}
