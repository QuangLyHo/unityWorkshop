using UnityEngine;

public class RandomRotator1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
    }
}
