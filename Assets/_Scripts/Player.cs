using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask lmGround;
    [SerializeField] LayerMask lmBomb;
    [SerializeField] float speed = 10;
    [SerializeField] float force = 100;
    [SerializeField] float speedH;
    Rigidbody rb;
    bool isGrounded = true;
    bool dir = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(force * Time.fixedDeltaTime * Vector3.up, ForceMode.Impulse);
        }


        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit grab;
            if(dir)
            {
                if(Physics.Raycast(transform.position - new Vector3(0, 0.5f, 0), Vector3.right, out grab, 1, lmBomb))
                {
                    print("BOOOMB");
                }
            }
            else
            {
                if (Physics.Raycast(transform.position - new Vector3(0, 0.5f, 0), Vector3.left, out grab, 1, lmBomb))
                {
                    print("BOOOMB");
                }
            }
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1, lmGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        

    }

    void MoverPlayer()
    {
        Vector3 traslation = (transform.right * Input.GetAxisRaw("Horizontal")).normalized;
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            dir = true;
        } 
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            dir = false; 
        }

        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * traslation);
    }

}
