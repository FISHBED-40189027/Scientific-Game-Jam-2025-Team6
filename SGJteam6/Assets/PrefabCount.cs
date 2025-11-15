using UnityEngine;

public class PrefabCount : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int InstanceCount { get; private set; }

    void OnEnable()
    {
        InstanceCount++;
    }

    void OnDisable()
    {
        InstanceCount--;
    }
}
