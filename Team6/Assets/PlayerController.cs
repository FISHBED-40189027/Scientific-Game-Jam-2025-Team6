using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Text CO2ScoreUI;
    [SerializeField] private Text ConcreteScoreUI;
    [SerializeField] private float CreateCrystalTime = 1f;

    public static int CO2Score;
    public static int ConcreteScore;

    bool inCrystalZone = false;
    float zoneTimer = 0f;

    void Update()
    {
        // ★ 新InputSystemなし：Input.GetAxisを使う
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, y, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (inCrystalZone)
        {
            zoneTimer += Time.deltaTime;

            if (zoneTimer >= CreateCrystalTime)
            {
                DoCrystalReaction();
                zoneTimer = 0f;
            }
        }
    }

    // --- 2Dトリガー ---
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("CO2"))
        {
            GetCO2(1);
            Destroy(other.gameObject);
            return;
        }

        if (other.CompareTag("Concrete"))
        {
            GetConcrete(1);
            Destroy(other.gameObject);
            return;
        }

        if (other.CompareTag("CrystalZone"))
        {
            Debug.Log("CrystalZone");
            inCrystalZone = true;
            zoneTimer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CrystalZone"))
        {
            inCrystalZone = false;
            zoneTimer = 0f;
        }
    }

    void GetCO2(int count)
    {
        CO2Score += count;
        CO2ScoreUI.text = "CO2Score: " + CO2Score;
    }

    void GetConcrete(int count)
    {
        ConcreteScore += count;
        ConcreteScoreUI.text = "ConcreteScore: " + ConcreteScore;
    }

    void DoCrystalReaction()
    {
        if (CO2Score > 0 && ConcreteScore > 0)
        {
            GetCO2(-1);
            GetConcrete(-1);
        }
    }
}
