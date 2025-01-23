using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float speed;
    private float seconds = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(randomMoves());
    }

    private IEnumerator randomMoves()
    {
        while (true)
        {
            moveLeftorRight();
            yield return new WaitForSeconds(seconds);
        }

    }
    // Update is called once per frame
    private void moveLeftorRight()
    {
        float randomDirection = Random.Range(-1f, 1f);

        transform.Translate(new Vector3(randomDirection * speed, 0 , 0) * Time.deltaTime);
    }
}
