using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private bool isCollectable = true;
    private bool isMoving = false;

    public Vector3 movementDestination;

    [SerializeField]
    private float moveSpeed = 3f;

    private Vector3 desiredVelocity;
    private float lastSqrMag;

    [SerializeField]
    private Rigidbody boxRigidbody;

    [SerializeField]
    private Material boxMaterial;

    private Color currentColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        if (!isCollectable)
            return;

        EnterBox();
    }

    private void Start()
    {
        boxMaterial.SetColor("_Color", Color.green);
    }

    private void Update()
    {
        CheckForFinishedDestination();
    }

    private void FixedUpdate()
    {
        boxRigidbody.velocity = desiredVelocity;
    }

    private void EnterBox()
    {
        EventManager.OnTriggerBoxCollection?.Invoke();

        isCollectable = false;
        ColorChange();

        SetDestination();
    }

    private void CheckForFinishedDestination()
    {
        if (!isMoving)
            return;

        float sqrMag = (movementDestination - transform.position).sqrMagnitude;

        if(sqrMag > lastSqrMag)
        {
            desiredVelocity = Vector3.zero;

            isMoving = false;
            isCollectable = true;

            ColorChange();
        }

        lastSqrMag = sqrMag;
    }

    private void SetDestination()
    {
        int x = Random.Range(-4, 4);
        int z = Random.Range(-4, 4);

        Vector3 movementVector = new Vector3(x, 0, z);
        movementDestination = movementVector;

        Vector3 directionalVector = (movementDestination - transform.position).normalized * moveSpeed;

        lastSqrMag = Mathf.Infinity;

        desiredVelocity = directionalVector;

        isMoving = true;
    }

    private void ColorChange()
    {
        if(isCollectable)
        {
            currentColor = Color.green;
            boxMaterial.SetColor("_Color", currentColor);
        }
        else
        {
            currentColor = Color.red;
            boxMaterial.SetColor("_Color", currentColor);
        }

        currentColor = boxMaterial.color;
    }

}
