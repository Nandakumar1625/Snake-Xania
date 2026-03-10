using UnityEngine;
using UnityEngine.UI;

public class BigBall : MonoBehaviour
{
    public float maxTime = 5f;
    float timer;

    void Start()
    {
        timer = maxTime;
        GameManager.instance.ShowSlider(maxTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        GameManager.instance.UpdateSlider(timer);

        if (timer <= 0)
        {
            GameManager.instance.HideSlider();

            FindObjectOfType<FoodSpawner>().SpawnFood();

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int bonusScore = Mathf.RoundToInt(timer * 10);

            GameManager.instance.AddScore(bonusScore);

            GameManager.instance.PlayEatSound();


            GameManager.instance.HideSlider();

            FindObjectOfType<FoodSpawner>().SpawnFood();

            Destroy(gameObject);
        }
    }
}