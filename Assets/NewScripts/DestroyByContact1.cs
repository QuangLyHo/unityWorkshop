using UnityEngine;
using TMPro;

public class DestroyByContact1 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController1 gameController;
    public int scoreValue;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if ( gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController1>();
        }
        else
        {
            Debug.Log("Cannot find 'Game Controller'");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.tag == "Boundary1")
            return;

        if (other.tag == "Player") 
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOver();
        }

        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
