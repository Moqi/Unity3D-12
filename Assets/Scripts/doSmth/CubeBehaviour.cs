using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
    public float RotationSpeed;
    public string HelloWorldString;

    void Start()
    {

    }
    void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(RotationSpeed * Time.deltaTime, Vector3.up);
        transform.rotation *= rotation;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 20), HelloWorldString);
    }
}
