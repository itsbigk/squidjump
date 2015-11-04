using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
 
   public Transform squid;
    public float minSpeed;
    public float maxSpeed;

    private float screenWidth;

    // Use this for initialization
    void Start()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x * 2;
        screenWidth -= screenWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //  if (squid.transform.position.y > 100)
        //  {
            //  transform.position = Vector3.MoveTowards(transform.position, Vector3.left * Random.Range(-1, 1), Random.Range(minSpeed, maxSpeed));

            //  transform.position = new Vector2(Mathf.Repeat(transform.position.x, screenWidth), transform.position.y);
        //  }
        if (squid.transform.position.y - transform.position.y > 100)
        {
            Destroy(gameObject);
        }
    }
}
