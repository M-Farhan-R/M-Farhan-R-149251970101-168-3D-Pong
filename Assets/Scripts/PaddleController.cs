using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode KeyUp, KeyDown, KeyLeft, KeyRight;
    public Rigidbody rig;
    public float speed = 7;
    private Vector3 startPosition;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        startPosition = rig.transform.position;
    }

    
    void Update()
    {
        AttachMovement(GetMovement());
    }

    private Vector3 GetMovement()
    {
        Vector3 movement = Vector3.zero;

        //Cek Paddle bergerak di X atau Z axis
        if (transform.localScale.x > 2)
        {
            if (Input.GetKey(KeyLeft))
            {
                movement = Vector3.left * speed;

            } else if (Input.GetKey(KeyRight))
            {
                movement = Vector3.right * speed;
            }
        } else 
        {
            if (Input.GetKey(KeyUp))
            {
                movement = Vector3.forward * speed;

            } else if (Input.GetKey(KeyDown))
            {
                movement = Vector3.back * speed;
            }
        }

        return movement;
    }

    private void AttachMovement(Vector3 movement)
    {
        rig.velocity = movement;
    }

    public void PaddleDeactive()
    {
        gameObject.SetActive(false);
    }

    public void PaddleActive()
    {
        gameObject.SetActive(true);
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
