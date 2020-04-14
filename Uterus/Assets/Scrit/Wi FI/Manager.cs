using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    InputController inputController;
    bool waitState = true;
    public GameObject cube;

    void Start()
    {
        //This will do the network stuff
        inputController = new InputController();
        inputController.Begin("192.168.0.150", 80);
    }

    void Update()
    {
        if (inputController.CurrentValue == 1 && waitState)
        {
            waitState = false;
            Signal();
        }
    }

    public void Signal()
    {
        Debug.Log("192.168.0.150");
        gameObject.transform.position = new Vector3(5f, 5f, 5f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        waitState = true;
    }
}
