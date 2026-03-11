using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject bigFoodPrefab;

    public int minX = -8;
    public int maxX = 8;
    public int minY = -4;
    public int maxY = 4;

    int ballCounter = 0;

    void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        int x = Random.Range(minX, maxX);
        int y = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(x, y);

        if (ballCounter >= 5)
        {
            Instantiate(bigFoodPrefab, spawnPos, Quaternion.identity);
            ballCounter = 0;
        }
        else
        {
            Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        }
    }

    public void AddBall()
    {
        ballCounter++;
    }
}