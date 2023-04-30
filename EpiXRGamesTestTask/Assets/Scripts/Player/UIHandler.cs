using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI boxSpeedTextField;

    private Rigidbody boxRigidbody;

    private void Start()
    {
        boxRigidbody = GameObject.FindGameObjectWithTag("TriggerBox").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (boxRigidbody == null)
            return;

        boxSpeedTextField.text = "Box speed: " + boxRigidbody.velocity.magnitude.ToString();
    }
}
