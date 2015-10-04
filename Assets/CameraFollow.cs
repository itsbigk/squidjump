using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    Vector3 cameraHeight;

    // Use this for initialization
    void Start()
    {
        cameraHeight = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 3)
        {
            cameraHeight.y = player.transform.position.y - 3;
            this.transform.position = cameraHeight;
        }
    }
}
