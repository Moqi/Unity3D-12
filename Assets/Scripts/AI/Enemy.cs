using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private CharacterController _controller;
    private Transform _thisTransform;
    private Transform _playerTransform;

    public void Awake()
    {
        moveSpeed = 3;
        turnSpeed = 90;
    }

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _thisTransform = transform;

        Player player = (Player)FindObjectOfType(typeof(Player));
        _playerTransform = player.transform;
    }

    public void FixedUpdate()
    {
        Vector3 playerDirection = (_playerTransform.position -
                                   _thisTransform.position).normalized;
        float angle = Vector3.Angle(_thisTransform.forward,
                                    playerDirection);
        float maxAngle = turnSpeed * Time.deltaTime;

                
        Quaternion rot = Quaternion.LookRotation(_playerTransform.position -
                                                 _thisTransform.position);
        if (maxAngle < angle)
        {
            _thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation,
                                                       rot, maxAngle / angle);
        }
        else
        {
            _thisTransform.rotation = rot;
        }

        if (Random.Range(1, 100) == 1)
            _controller.Move(_thisTransform.up * 20.0f * Time.deltaTime);  

        if (Vector3.Distance(_thisTransform.position,
                            _playerTransform.position) > 3.0f)
        {            
            _controller.Move(_thisTransform.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            _controller.Move(Vector3.up * 2.5f * Time.deltaTime);                          
        }

        _controller.Move(Vector3.down * 1.0f * Time.deltaTime);
    }
}
