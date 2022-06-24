using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOut : MonoBehaviour
{
    public GameObject ball;
    public BallManager ballManager;
    public void OnTriggerEnter(Collider collision)
    {
        //Menggunakan Tag, karena dengan Collider ball, ball clone(child)nya tidak mentrigger
        if (collision.tag == ball.tag)
        {
            ballManager.RemoveBall(collision.gameObject);
        }
    }
}
