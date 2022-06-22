using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public GameObject ball;
    
    public BallManager ballManager;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == ball.tag)
        {
            ballManager.RemoveBall(collision.gameObject);
        }
    }


}
