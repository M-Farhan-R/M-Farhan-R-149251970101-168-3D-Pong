using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public GameObject ball;
    public GameManager gameManager;
    public BallManager ballManager;
    public bool goalP1, goalP2, goalP3, goalP4;

    public void OnTriggerEnter(Collider collision)
    {
        //Menggunakan Tag, karena dengan Collider ball, ball clone(child)nya tidak mentrigger
        if (collision.tag == ball.tag)
        {
            ballManager.RemoveBall(collision.gameObject);

            if (goalP1)
            {
                gameManager.AddScoreP1();
            }
            if (goalP2)
            {
                gameManager.AddScoreP2();
            }
            if (goalP3)
            {
                gameManager.AddScoreP3();
            }
            if (goalP4)
            {
                gameManager.AddScoreP4();
            }
        }
    }

    public void TriggerOff()
    {
        Vector3 wallPosition = transform.position;
        float close = 1f;
        gameObject.GetComponent<Collider>().isTrigger = false;
        if (goalP1)
        {
            transform.position = new Vector3(wallPosition.x, wallPosition.y, wallPosition.z + close);
        }
        if (goalP2)
        {
            transform.position = new Vector3(wallPosition.x + close, wallPosition.y, wallPosition.z);
        }
        if (goalP3)
        {
            transform.position = new Vector3(wallPosition.x, wallPosition.y, wallPosition.z - close);
        }
        if (goalP4)
        {
            transform.position = new Vector3(wallPosition.x - close, wallPosition.y, wallPosition.z);
        }
    }
}
