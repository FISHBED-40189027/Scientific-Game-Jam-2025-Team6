using UnityEngine;

public class MoveZone : MonoBehaviour
{
    public float speed = 0.2f;              // 揺れの速さ
    public float radius = 8f;             // 揺れ幅（大きくすると大きく動く）

    // 画角内の制限
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    float timeX;
    float timeY;
    Vector3 center;

    void Start()
    {
        center = transform.position;

        // それぞれランダムスタート
        timeX = Random.value * 100f;
        timeY = Random.value * 100f;
    }

    void Update()
    {
        timeX += Time.deltaTime * speed;
        timeY += Time.deltaTime * speed;

        float offsetX = (Mathf.PerlinNoise(timeX, 0f) * 2f - 1f) * radius;
        float offsetY = (Mathf.PerlinNoise(0f, timeY) * 2f - 1f) * radius;

        Vector3 nextPos = center + new Vector3(offsetX, offsetY, 0);

        // 画角の中に閉じ込める（はみ出し防止）
        nextPos.x = Mathf.Clamp(nextPos.x, minX, maxX);
        nextPos.y = Mathf.Clamp(nextPos.y, minY, maxY);

        transform.position = nextPos;
    }
}
