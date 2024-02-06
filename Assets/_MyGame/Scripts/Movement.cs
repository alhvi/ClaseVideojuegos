using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private CharacterController charController;
    private Animator animator;
    private float speed = 5f;
    
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(movX, 0, movZ);

        if (movementVector.magnitude > 0.1 )
        { 
            charController.SimpleMove(movementVector * speed);
            transform.forward = movementVector;
        }

        animator.SetFloat("Speed", movementVector.magnitude * speed);
    }
}
