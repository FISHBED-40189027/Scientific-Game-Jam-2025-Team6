using UnityEngine;

public class MoveZone2D : MonoBehaviour
{
    public float speed = 0.2f;      // —h‚ê‚Ì‘¬‚³
    public float radius = 8f;       // —h‚ê•

    // ‰æŠp“à‚Ì§ŒÀ
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    private float timeX;
    private float timeY;
    private Vector2 center;

    void Start()
    {
        center = transform.position;

        // ƒ‰ƒ“ƒ_ƒ€ƒXƒ^[ƒg‚Å©‘R‚È—h‚ê
        timeX = Random.value * 100f;
        timeY = Random.value * 100f;
    }

    void Update()
    {
        timeX += Time.deltaTime * speed;
        timeY += Time.deltaTime * speed;

        // PerlinNoise‚ÅŠŠ‚ç‚©‚É—h‚ê‚é
        float offsetX = (Mathf.PerlinNoise(timeX, 0f) * 2f - 1f) * radius;
        float offsetY = (Mathf.PerlinNoise(0f, timeY) * 2f - 1f) * radius;

        Vector2 nextPos = center + new Vector2(offsetX, offsetY);

        // ‰æ–Ê“à‚É§ŒÀ
        nextPos.x = Mathf.Clamp(nextPos.x, minX, maxX);
        nextPos.y = Mathf.Clamp(nextPos.y, minY, maxY);

        transform.position = nextPos;
    }
}
