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
        float minRange = 0.6f; //Agar bola tidak diam atau terlalu lambat

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
}
