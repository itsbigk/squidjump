using UnityEngine;
using System.Collections;

public class SquidMovement : MonoBehaviour
{
    public float movementForce = 1f;
    public float jumpForce = 1000f;
    private Rigidbody2D _rigidbody;
    private float screenWidth;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        var dist = (transform.position - Camera.main.transform.position).z;
        screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Repeat(transform.position.x, screenWidth), transform.position.y);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            gameObject.layer = 8;//PlayerInAir Layer
        }
        if (_rigidbody.velocity.y < 0)
        {
            gameObject.layer = 9;//Player layer
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
            _rigidbody.AddForce(Vector2.right*Input.GetAxis("Horizontal")*movementForce, ForceMode2D.Force);
    }
}
