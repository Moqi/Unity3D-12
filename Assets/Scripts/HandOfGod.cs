using UnityEngine;
using System.Collections;

public class HandOfGod : MonoBehaviour
{
    public float pushStrength;
    public GameObject[] cube;
    
    public void Awake()
    {
        cube = GameObject.FindGameObjectsWithTag("Player");
        pushStrength = 80.0f;
    }

    public void FixedUpdate()
    {
        int ind = Random.Range(0, cube.Length - 1);      
        if (cube[ind].transform.localPosition.y < 4.0f)
            cube[ind].rigidbody.AddForce(Vector3.up * pushStrength);
    }
}
