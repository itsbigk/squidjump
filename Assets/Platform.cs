using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{

    Transform squid;
    public float minSpeed;
    public float maxSpeed;

    private float screenWidth;

    float speed = 1;

    // Use this for initialization
    void Start()
    {
        squid = GameObject.FindGameObjectWithTag("Player").transform;
        var dist = (transform.position - Camera.main.transform.position).z;
        screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x * 2;
        screenWidth -= screenWidth / 2;

        var random = Random.value;
        if (random > 0.5f)
            move = new Vector3(1, 0, 0);
        else
            move = new Vector3(-1, 0, 0);

        speed = Random.Range(minSpeed, maxSpeed);
    }

    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        if (maxSpeed > 0)
        {
            transform.position += move * speed * Time.deltaTime;

            if (transform.position.x < -6) move = new Vector3(1, 0, 0);
            if (transform.position.x > 0) move = new Vector3(-1, 0, 0);
            //  transform.position = new Vector2(Mathf.Repeat(transform.position.x, screenWidth), transform.position.y);
        }

        if (squid.transform.position.y > transform.position.y + 50)
        {
            Pool();
        }
    }

    void Pool()
    {
        SimplePool.Despawn(gameObject);
    }
}
