using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour
{
    public float speed;
    //  public float heightOffset;	

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
    }
}
