using UnityEngine;
using System.Collections;

public class SquidMovement : MonoBehaviour
{
    public float movementForce = 1f;
    public float jumpForce = 1000f;
    public float AccJumpForcePerFrame;
    public float MaxAccJumpForce;
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    private float screenWidth;
    private float accJumpForce;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        var dist = (transform.position - Camera.main.transform.position).z;
        screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x - 1;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Repeat(transform.position.x, screenWidth), transform.position.y);
    }

    bool isTouching = false;
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (!isTouching)
                isTouching = true;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                accJumpForce = 0;
                isAnimatingFullPowerSprite = false;
            }

            accJumpForce = Mathf.Clamp(accJumpForce + AccJumpForcePerFrame, 1, MaxAccJumpForce);
            UpdateSprite();
        }
        else if (isTouching)
        {
            isTouching = false;
            if (_rigidbody.velocity.y == 0)
                Jump(accJumpForce);
            accJumpForce = 0;
            isAnimatingFullPowerSprite = false;
            UpdateSprite();
        }

        if (_rigidbody.velocity.y < 0)
        {
            gameObject.layer = 9;//Player layer
        }

        var movement = Input.acceleration.x;
        if (Mathf.Abs(movement) > 0.1f)
            _rigidbody.AddForce(Vector2.right * movement * movementForce, ForceMode2D.Force);
    }

    void Jump(float force)
    {
        gameObject.layer = 8;//PlayerInAir Layer
        _rigidbody.AddForce(new Vector2(0f, jumpForce * force), ForceMode2D.Impulse);
    }

    void UpdateSprite()
    {
        var animProgress = accJumpForce / MaxAccJumpForce;
        var spriteIndex = 0;
        if (animProgress >= 1)
        {
            if (!isAnimatingFullPowerSprite)
            {
                isAnimatingFullPowerSprite = true;
                StartCoroutine("AnimateFullPowerSprite");
            }
            return;
        }
        else if (animProgress > 0.8)
            spriteIndex = 5;
        else if (animProgress > 0.6)
            spriteIndex = 3;
        else if (animProgress > 0.4)
            spriteIndex = 2;
        else if (animProgress > 0.2)
            spriteIndex = 1;

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    bool isAnimatingFullPowerSprite = false;

    int lastSprite = 0;
    IEnumerator AnimateFullPowerSprite()
    {
        while (isAnimatingFullPowerSprite)
        {
            switch (lastSprite)
            {
                case 0:
                    spriteRenderer.sprite = sprites[4];
                    lastSprite = 1;
                    break;
                case 1:
                    spriteRenderer.sprite = sprites[5];
                    lastSprite = 0;
                    break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Lava")
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }
}
