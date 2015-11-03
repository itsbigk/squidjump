using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    public float heightOffset = 2f;
    private Vector3 velocity = Vector3.zero;
    public Transform player;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 point = camera.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            destination.x = camera.transform.position.x;
            destination.y += heightOffset;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
