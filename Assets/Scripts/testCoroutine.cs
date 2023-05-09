using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    Rigidbody rb;
    private IEnumerator coroutine;

    void Start()
    {
        rb = cube.GetComponent<Rigidbody>();
        // - After 0 seconds, prints "Starting 0.0"
        // - After 0 seconds, prints "Before WaitAndPrint Finishes 0.0"
        // - After 2 seconds, prints "WaitAndPrint 2.0"
        print("Starting " + Time.time);

        // Start function WaitAndPrint as a coroutine.

        coroutine = WaitAndPrint(.5f);
        StartCoroutine(coroutine);
      
        print("Before WaitAndPrint Finishes " + Time.time);
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }
            else
            {
                rb.isKinematic = true;
            }
        }
    }
}
