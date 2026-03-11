using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Transform bodyPrefab;

    List<Transform> body = new List<Transform>();

    Vector2 direction = Vector2.right;

    float moveTimer;
    public float moveRate = 0.2f;

    public int minX = -8;
    public int maxX = 8;
    public int minY = -4;
    public int maxY = 4;

    void Start()
    {
        body.Add(this.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector2.down)
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector2.up)
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2.right)
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2.left)
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    void FixedUpdate()
    {
        moveTimer += Time.fixedDeltaTime;

        if (moveTimer >= moveRate)
        {
            Move();
            moveTimer = 0;
        }
    }

    void Move()
    {
        Vector2 nextPosition = (Vector2)transform.position + direction;

        // Check wall collision
        if (nextPosition.x < minX || nextPosition.x > maxX ||
            nextPosition.y < minY || nextPosition.y > maxY)
        {
            GameManager.instance.GameOver();
            return;
        }

        // Move body
        for (int i = body.Count - 1; i > 0; i--)
        {
            body[i].position = body[i - 1].position;
        }

        transform.position = nextPosition;
    }

    public void Grow()
    {
        Transform segment = Instantiate(bodyPrefab);
        segment.position = body[body.Count - 1].position;
        body.Add(segment);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.instance.GameOver();
        }
    }
}