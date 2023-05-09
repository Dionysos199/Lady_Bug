//// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler

// Turned out it was comnplicated to use rigidbodies and friction
// I abandonned 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatterpillerMove : MonoBehaviour
{
    [SerializeField] private float yOffset;
    [SerializeField] private float xOffset;

    [SerializeField] private float mvtDetection=1;
    GameObject middleCell;
    GameObject head;
    GameObject tail;

    Rigidbody tailRb;
    Rigidbody headRb;
    PhysicMaterial headPhysMat;
    PhysicMaterial tailPhysMat;

    [SerializeField] private float minFriction = .1f;
    [SerializeField] private float maxFriction=   5;

    [SerializeField] private float bigMass =5;
    [SerializeField] private float smallMass =1;
    float Height;
    [SerializeField] private GameObject cube1;
    [SerializeField] private GameObject cube2;
    [SerializeField] private float checkFrequency;



    private IEnumerator coroutine;
    private void OnEnable()
    {
        ReadAnalogData.dataRecieved += liftMiddleCell;
    }
    private void OnDisable()
    {

        ReadAnalogData.dataRecieved -= liftMiddleCell;
    }
    // Start is called before the first frame update
    void Start()
    {
      middleCell= this.transform.Find("midCell").gameObject;

        head = this.transform.Find("head").gameObject;
        tail = this.transform.Find("tail").gameObject;

         tailRb = tail.GetComponent<Rigidbody>();
         headRb = head.GetComponent<Rigidbody>();
        //tailRb.isKinematic = false;
       // headRb.isKinematic = true;

        coroutine = WaitAndSwitch(checkFrequency);
        StartCoroutine(coroutine);



        headPhysMat = head.GetComponent<CapsuleCollider>().material;
        tailPhysMat = tail.GetComponent<CapsuleCollider>().material;

    }

        // Update is called once per frame
        void Update()
    {

    }

         
    
    public void liftMiddleCell(float height)
    {
        head.transform.Translate ( new Vector3(0, height-yOffset, xOffset));

        Height = height;
      //  Debug.Log(height);

        
    }
    private IEnumerator WaitAndSwitch(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            switchGrip(Height);
        }
    }

    void slide(GameObject cube, float value)
    {
        cube.transform.Translate(new Vector3(value, 0, 0));
    }

    float lastHeight;
     void switchGrip(float height)
    {
        float DHeight = height - lastHeight;
        if ( Mathf.Abs(DHeight) >= mvtDetection & DHeight>0)
        {
            gather();
           Debug.Log("gather");
        }
        if (Mathf.Abs(DHeight) >= mvtDetection & DHeight < 0)
        {
            project();
            Debug.Log("project");
        }
        if (DHeight < mvtDetection)
        {
            project();
        }
        float angles = head.transform.rotation.eulerAngles.z;
      //  head.transform.rotation= Mathf.Clamp()
       
        lastHeight=height;
    }
    bool pushForward;
    void gather()
    {
        //Debug.Log(endRb);
        //endRb.isKinematic = true;
       // headRb.isKinematic = false;
        headPhysMat.dynamicFriction = maxFriction;
        headRb.drag = maxFriction;
        headRb.mass = bigMass;
       // headRb.isKinematic = true;
      // if (pushForward == true) 
      // head.transform.Translate(head.transform.forward);
      //pushForward = false;

      tailPhysMat.dynamicFriction = minFriction;
        headRb.drag = minFriction;
        tailRb.mass = smallMass;

       // tailRb.isKinematic = false;

    }
    void project()
    {
        pushForward = true;
        // endRb.isKinematic = false;
        // headRb.isKinematic = true  ;
        headPhysMat.dynamicFriction = minFriction;
        headRb.drag = minFriction;
        headRb.mass = smallMass;

        //headRb.isKinematic = false;
        //middleCell.transform.position = Vector3.Lerp(middleCell.transform.position, 
        // middleCell.transform.position + middleCell.transform.right, 2);

        tailPhysMat.dynamicFriction = maxFriction;
        headRb.drag = maxFriction;
        tailRb.mass = bigMass;

        //tailRb.isKinematic = tru;

    }
}
