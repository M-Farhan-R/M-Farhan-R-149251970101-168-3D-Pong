using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    private Vector3 lastVelocity;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        RandomMoveDirection();
    }

    public void RandomMoveDirection()
    {
        float x = 0; 
        float z = 0;
        float minRange = 0.7f; //Agar bola tidak diam atau terlalu lambat

        //Cek posisi spawn bola dan menentukan arah geraknya
        if (gameObject.transform.position.z > 0 && gameObject.transform.position.x < 0)
        {
            //Menggunakan Random Range agar bola tidak bergerak lurus dari sudut ke sudut(jika nilainya 1 atau -1)
            x = Random.Range(minRange,1f);
            z = -Random.Range(minRange,1f);
        } 
        if (gameObject.transform.position.z > 0 && gameObject.transform.position.x > 0)
        {
            x = -Random.Range(minRange,1f);
            z = -Random.Range(minRange,1f);
        } 
        if (gameObject.transform.position.z < 0 && gameObject.transform.position.x < 0)
        {
            x = Random.Range(minRange,1f);
            z = Random.Range(minRange,1f);
        } 
        if (gameObject.transform.position.z < 0 && gameObject.transform.position.x > 0)
        {
            x = -Random.Range(minRange,1f);
            z = Random.Range(minRange,1f);
        }

        rig.velocity = new Vector3(speed * x, 0, speed * z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            PaddleController pControl = collision.gameObject.GetComponent<PaddleController>();
            Vector3 currentSpd = rig.velocity;
            float counterDirection = 0.8f;
            float sameDirection = 0f;
            if (pControl.rig.velocity.x > 0)
            {
                if (currentSpd.x > 0)
                {
                    currentSpd.x += sameDirection * speed;
                } else
                {
                    currentSpd.x += counterDirection * speed;
                }
            }
            if (pControl.rig.velocity.x < 0)
            {
                if (currentSpd.x < 0)
                {
                    currentSpd.x -= sameDirection * speed;
                } else
                {
                    currentSpd.x -= counterDirection * speed;
                }
            }
            if (pControl.rig.velocity.z > 0)
            {
                if (currentSpd.z < 0)
                {
                    currentSpd.z -= sameDirection * speed;
                } else
                {
                    currentSpd.z -= counterDirection * speed;
                }
            }
            if (pControl.rig.velocity.z < 0)
            {
                if (currentSpd.z < 0)
                {
                    currentSpd.z -= sameDirection * speed;
                } else
                {
                    currentSpd.z -= counterDirection * speed;
                }
            }
            Vector3 normal = collision.GetContact(0).normal;
            rig.velocity =  Vector3.Reflect(currentSpd, normal).normalized * speed * 1.4f;
        }
        if (collision.gameObject.tag == "BallEnter")
        {
            Vector3 normal = collision.GetContact(0).normal;
            rig.velocity =  Vector3.Reflect(rig.velocity, normal).normalized * speed * 1.2f;
        }
    }
}
