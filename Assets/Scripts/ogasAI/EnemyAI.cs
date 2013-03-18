using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    private Transform _thisTransform;

    void Awake()
    {
        _thisTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    void Update()
    {
        Debug.DrawLine(_thisTransform.position,
                       target.position, 
                       Color.yellow);
        _thisTransform.rotation = Quaternion.Slerp(
            _thisTransform.rotation,
            Quaternion.LookRotation(target.position - 
                                    _thisTransform.position),
            rotationSpeed * Time.deltaTime);
    }

}
