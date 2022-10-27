using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BehaviorA : MonoBehaviour
{
    // public PlayerCollision playerCollision;
    public float pushForce;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision.OnCollision += MoveToObjectC;
        PlayerNear.OnRange += ChangeColor;
        PlayerNear.OnRange += Jump;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveToObjectC(string notifierTag)
    {
        if (notifierTag == "ObjectB")
        {
            GameObject[] objectCList = GameObject.FindGameObjectsWithTag("ObjectC");
            if (objectCList.Length == 0) return;

            GameObject objectC = objectCList.OrderBy(objectC => (objectC.transform.position - transform.position).sqrMagnitude).First();
            Vector3 moveDirection = (objectC.transform.position - transform.position).normalized;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(moveDirection * pushForce);
        }
    }

    void ChangeColor(string notifierTag)
    {
        if (notifierTag == "ObjectC")
        {
            Renderer rd = GetComponent<Renderer>();
            rd.material.color = Random.ColorHSV();
        }
    }

    void Jump(string notifierTag)
    {
        if (notifierTag == "ObjectC")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
