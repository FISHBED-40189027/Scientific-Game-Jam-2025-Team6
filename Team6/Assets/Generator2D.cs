using UnityEngine;

public class Generator2D : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 xRange = new Vector2(-8.5f, 8.5f);
    [SerializeField] private Vector2 yRange = new Vector2(-3.5f, 3.5f);

    [SerializeField] private float spawnInterval = 10f;
    private float timer = 0f;

    void Start()
    {
        SpawnRandom(5);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            int count = Random.Range(1, 4);
            SpawnRandom(count);
            timer = spawnInterval + Random.Range(-0.5f, 0.5f);
        }
    }

    public void SpawnRandom(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(xRange.x, xRange.y);
            float randomY = Random.Range(yRange.x, yRange.y);

            Vector2 spawnPos = new Vector2(randomX, randomY);
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
