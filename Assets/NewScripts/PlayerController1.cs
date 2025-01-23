using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary1
{
    public float xMin,xMax,zMin,zMax;
}

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    public Boundary1 boundary1;

    public float fireRate;
    private float nextFire;

    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody playerRigidbody;
    private AudioSource weaponAudio;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        weaponAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            weaponAudio.Play();
        }
    }

    void FixedUpdate() 
    {
        //get player input coordinates
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //calculate movement
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;

        //apply movement directly to the rigidbody velocity
        playerRigidbody.linearVelocity = movement;

        //clamp players position within boundaries
        playerRigidbody.position = new Vector3 
        (
            Mathf.Clamp (playerRigidbody.position.x, boundary1.xMin, boundary1.xMax),
            0.0f,
            Mathf.Clamp (playerRigidbody.position.z, boundary1.zMin, boundary1.zMax)
        );

    }

}