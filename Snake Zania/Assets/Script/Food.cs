using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SnakeMovement>().Grow();

            GameManager.instance.AddScore(1);

            GameManager.instance.PlayEatSound();


            FoodSpawner spawner = FindObjectOfType<FoodSpawner>();

            spawner.AddBall();
            spawner.SpawnFood();

            Destroy(gameObject);
        }
    }
}