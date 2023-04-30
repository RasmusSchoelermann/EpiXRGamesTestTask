using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float roatationSpeed;

    private bool isWalking = false;

    private Vector3 movementVector;

    [SerializeField]
    private Rigidbody pRigidbody;

    [SerializeField]
    private Animator pAnimator;

    // Update is called once per frame
    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        movementVector = new Vector3(horizontalMovement, 0, verticalMovement);
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;
        pRigidbody.MovePosition(transform.position + movementVector);

        isWalking = movementVector.x != 0f || movementVector.z != 0f;

        pAnimator.SetBool("isWalking", isWalking);
    }

    private void Rotate()
    {
        if (movementVector != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), roatationSpeed);
    }
}
