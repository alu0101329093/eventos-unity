using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    public Notifier notifier;
    // Start is called before the first frame update
    void Start()
    {
        notifier.OnMessage += Response;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Response()
    {
        Renderer rd = GetComponent<Renderer>();
        rd.material.color = Random.ColorHSV();
        Debug.Log("Changing color ...");
    }
}
