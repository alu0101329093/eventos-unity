using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Transform tf = GetComponent<Transform>();
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float rotationAxis = Input.GetAxis("Rotation");

        Vector3 movementVector = (Vector3.forward * verticalAxis + Vector3.right * horizontalAxis);
        tf.Translate(movementVector * Time.deltaTime * movementSpeed);
        Vector3 rotationVector = Vector3.up * rotationAxis;
        tf.Rotate(rotationVector * Time.deltaTime * rotationSpeed, Space.World);
    }
}
