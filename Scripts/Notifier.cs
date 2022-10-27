using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public delegate void Message();
    public event Message OnMessage;
    public float loopTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InfiniteLoop());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator InfiniteLoop()
    {
        WaitForSeconds waitTime = new WaitForSeconds(loopTime);
        while (true)
        {
            yield return waitTime;
            OnMessage();
        }
    }
}
