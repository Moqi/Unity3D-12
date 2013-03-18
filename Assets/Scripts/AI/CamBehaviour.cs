using UnityEngine;
using System.Collections;

public class CamBehaviour : MonoBehaviour
{
    private Camera cam;
    private Player player;
    private Transform _playerTransform;
    private Transform _camTransform;

    public void Awake()
    {
        cam = GetComponent<Camera>();
        _camTransform = cam.transform;

        player = (Player)FindObjectOfType(typeof(Player));
        _playerTransform = player.transform;
    }

    public void FixedUpdate()
    {
        _camTransform.rotation = Quaternion.Slerp(
            _camTransform.rotation,
            Quaternion.LookRotation(
                _playerTransform.position -
                _camTransform.position),
            Time.deltaTime);
    }
}
