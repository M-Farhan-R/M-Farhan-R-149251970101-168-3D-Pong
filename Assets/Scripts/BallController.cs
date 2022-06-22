using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        RandomMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomMoveDirection()
    {
        float x = 0; 
        float z = 0;
        float minRange = 0.3f; //Agar bola tidak diam atau terlalu lambat

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
            Vector3 currentSpd = rig.velocity.normalized;
            if (pControl.rig.velocity.x > 0)
            {
                currentSpd.x -= 0.5f;
            }
            if (pControl.rig.velocity.x < 0)
            {
                currentSpd.x -= 1.5f;
            }
            if (pControl.rig.velocity.z > 0)
            {
                currentSpd.z -= 0.5f;
            }
            if (pControl.rig.velocity.z < 0)
            {
                currentSpd.z -= 1.5f;
            }
            Vector3 normal = collision.GetContact(0).normal;
            rig.velocity =  Vector3.Reflect(currentSpd, normal) * speed * 1.3f;
        }
        if (collision.gameObject.tag == "BallEnter")
        {
            rig.velocity *= 1.2f;
        }
    }
}
