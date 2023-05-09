// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
//This class controls the movement of the catterpillar


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gatherProject : MonoBehaviour
{


    //[SerializeField] private float threshold = 1;
   // [SerializeField] private float checkFrequency;

    GameObject head;
    GameObject tail;

    Rigidbody tailRb;
    Rigidbody headRb;


    float rotationAngle;
    float _Input;
    [SerializeField] private float stepMultiplyer;

    //private IEnumerator coroutine;

     event Action<float> translate;


    public GameObject cube;
    //private void OnEnable()
    //{
    //   ReadIMUSensor.dataRecieved += onChangedInput;
    //}
    //private void OnDisable()
    //{

    //    ReadIMUSensor.dataRecieved -= onChangedInput;
    //}

    void Start()
    {

        
             head = this.transform.Find("head").gameObject;
        //  headRb = head.GetComponent<Rigidbody>();
     

        
             tail = this.transform.Find("tail").gameObject;

        //tail.transform.position = head.transform.position + new Vector3(0, 0, 6);
        // tailRb = tail.GetComponent<Rigidbody>();

        //tailRb.isKinematic = false;
        // headRb.isKinematic = true;

        // coroutine = WaitAndSwitch(checkFrequency);
        // StartCoroutine(coroutine);

    }
    private void OnEnable()
    {
        ReadAnalogData.dataRecieved += onChangedInput;

    }
    private void OnDisable()
    {
        ReadAnalogData.dataRecieved -= onChangedInput;
    }
    // Update is called once per frame
    void Update()
    {
        //started working on the rotation so the catterpillar can change direction
        rotationAngle += Input.GetAxis("Horizontal");
        head.transform.localRotation = Quaternion.Euler(0, rotationAngle, 0);
        //keepGrounded(head);
        //keepGrounded(tail);
        keepGrounded(cube);
    }
    private void FixedUpdate()
    {
    }

   

    void keepGrounded(GameObject cell)
    {
        Ray ray = new Ray(cell.transform.position, -cell.transform.up);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 100);
        Debug.Log("hitObject" + hitInfo.collider);
        cell.transform.position = hitInfo.point+ hitInfo.normal;
        Debug.Log("hitInfo" + hitInfo.point);
        cell.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal); 
    }




    //on Input update simply assign the value from the sensor to a local float variable
    public void onChangedInput(float input)
    {
        _Input = input;
        float dInput = dInputFn(_Input);
        switchGrip(dInput);
        translate(dInput); // translate is a delegate that is either equal to pushHead or pullTail
    }

    float lastInput = 750; 
    // Important to set the initial value because it's the value the input from the sensor gives
    // when the sensor is not intact

    float dInputFn(float input)

    //What we care about is the delta value, if the value has increased or decreased
    // On each update we check the value and substract it from the last value we recorded from last update
    {
        float dInput = input - lastInput;
        lastInput = input;
        return dInput;

    }

    //We switch grip depending if dInput is negative or positive 
    // we either pull tail 
    // or push the head 
    void switchGrip(float dInput)
    {
        Debug.Log("dInput" + dInput);
        // if (Mathf.Abs(DInput) >= threshold & DInput > 0)

        if (dInput < 0)
        {
            translate = pullTail;
        }
        // if (Mathf.Abs(DInput) >= threshold & DInput < 0)

        if (dInput >= 0)
        {
            translate = pushHead;
        }


    }
    void pullTail(float step)
    {
        Debug.Log("pullTail");
        Debug.Log("setp" + step);

        // tail.transform.right=(step * stepMultiplyer * followVector() * Time.deltaTime);
        Vector3 follow= Vector3.Normalize(head.transform.position - tail.transform.position);
        
        tail.transform.Translate(step * stepMultiplyer * tail.transform.forward * Time.deltaTime);
       // tail.transform.rotation = Quaternion.FromToRotation(tail.transform.forward, follow);
    }

    
    Vector3 followVector()
    {
        return Vector3.Normalize(head.transform.position - tail.transform.position);
    }

    // 
    void pushHead(float step)
    {
        //tail.transform.position +=   step* tail.transform.forward
        //if(!exceedLength())

        Debug.Log("project");
        head.transform.Translate(-step * stepMultiplyer * head.transform.forward * Time.deltaTime);

        cube.transform.Translate(-step * stepMultiplyer * head.transform.forward * Time.deltaTime);

    }



    //private IEnumerator WaitAndSwitch(float waitTime)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //     //   Debug.Log("coRoutine");
    //        switchGrip(dInputFn(_Input));
    //    }
    //}




    //float maxLength;
    //float minLength;
    //bool exceedLength()
    //{
    //    float distanceHeadTail = Vector3.Distance(tail.transform.localPosition, head.transform.localPosition);
    //    Debug.Log(distanceHeadTail);
    //    if ( distanceHeadTail< maxLength)

    //        return false;
    //    else
    //    {
    //        return true;
    //    }
    //}
    //bool lessThanMin()
    //
    //    float distanceHeadTail = Vector3.Distance(tail.transform.localPosition, head.transform.localPosition);
    //    Debug.Log(distanceHeadTail);
    //    if (distanceHeadTail < minLength)

    //        return true;
    //    else
    //    {
    //        return false;
    //    }
    ////}
    //bool pushForward;

}
