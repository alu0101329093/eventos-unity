using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorB : MonoBehaviour
{
    public float growthFactor;
    public GameObject lookAtObject;
    bool lookAt = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision.OnCollision += Growth;
        PlayerNear.OnRange += LookAt;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt)
        {
            transform.LookAt(lookAtObject.transform);
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.red);
        }
    }

    void Growth(string notifierTag)
    {
        if (notifierTag == "ObjectA")
        {
            transform.localScale *= growthFactor;
        }
    }

    void LookAt(string notifierTag)
    {
        if (notifierTag == "ObjectC")
        {
            StartCoroutine(ToggleLookAt());
        }
    }

    IEnumerator ToggleLookAt()
    {
        lookAt = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        yield return new WaitForSeconds(1.0f);
        lookAt = false;
        rb.isKinematic = false;
    }
}
