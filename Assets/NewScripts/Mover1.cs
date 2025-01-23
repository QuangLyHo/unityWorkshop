using UnityEngine;

public class Mover1 : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed; //new Vector3(0, 0.1)
    }
}
