using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask lmGround;
    [SerializeField] LayerMask lmBomb;
    [SerializeField] float speed = 10;
    [SerializeField] float force = 100;
    [SerializeField] float rotateSpeed;
    [SerializeField] float launchSpeed = 10;
    [SerializeField] GameObject partiCULO;
    Rigidbody rb;
    bool isGrounded = true;
    float currentRotation;
    bool grabBomb = false;
    GameObject bombItem = null;
    
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
        //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"), Space.Self);

        float newRotation = currentRotation + Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        SetCurrentRotation(newRotation);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(force * Time.fixedDeltaTime * Vector3.up, ForceMode.Impulse);
        }


        if(Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit grab;
            if (!grabBomb && Physics.Raycast(transform.position, transform.right, out grab, 1, lmBomb))
            {
                bombItem = grab.collider.gameObject;
                grab.rigidbody.isKinematic = true;

                bombItem.transform.position = transform.position + new Vector3(0, 1.5f, 0);
                print("AAAAAAAAAAAAAAAAAAAAA");
                bombItem.transform.parent = transform;
                grabBomb = true;
             
            }
            else if (grabBomb)
            {
                print("BBBBBBBBBBBBBBBBBBBBBBBB");
                Rigidbody rbBomb = bombItem.GetComponent<Rigidbody>();
                rbBomb.isKinematic = false;
                bombItem.transform.parent = null;
                rbBomb.AddForce((transform.right + transform.up) * launchSpeed, ForceMode.VelocityChange);
                grabBomb = false;
                bombItem = null;
            }
            
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, lmGround))
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
        Vector3 traslation = (Vector3.right * Input.GetAxisRaw("Horizontal")).normalized;
        
        if(traslation.x != 0)
        {
            Destroy(Instantiate(partiCULO, transform.position - new Vector3(0.0f, .5f, 0.0f), transform.rotation), 1f);
        }
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * traslation);
    }

    void SetCurrentRotation(float rot)
    {
        currentRotation = Mathf.Clamp(rot, -180, 0);
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }

}
