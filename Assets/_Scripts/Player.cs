using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask lmGround;
    [SerializeField] float speed = 10;
    [SerializeField] float force = 100;
    Rigidbody rb;
    [SerializeField] bool isGrounded = true;
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
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * traslation);
    }
}
