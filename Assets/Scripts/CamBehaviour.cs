using UnityEngine;
using System.Collections;

public class CamBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    private Transform _thisTransform;
    private Quaternion _oldAngle;


    public void Awake()
    {
        _thisTransform = transform;
        
        rotationSpeed = 5.0f;
    }

    public void FixedUpdate()
    {        
        _thisTransform.RotateAround(
            Vector3.zero,
            _thisTransform.up,
            rotationSpeed * Time.deltaTime);
        _thisTransform.rotation =
            Quaternion.LookRotation(
                Vector3.zero - _thisTransform.position);
        // I need more effective way to do such things, do you know one?
        // more than that, now camera slowly going down, and it will lay on the ground after 5-10 minutes
    }
}
