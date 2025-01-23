using UnityEngine;

public class DestroyByBoundary1 : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //other: Bolt object
    }

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
