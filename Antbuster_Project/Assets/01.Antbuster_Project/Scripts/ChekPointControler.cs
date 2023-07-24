using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPointControler : MonoBehaviour
{
    private GameObject chackPointObj;
    public BoxCollider checkPointCollider;

    // Start is called before the first frame update
    void Start()
    {
        chackPointObj = GetComponent<GameObject>();
        checkPointCollider = GetComponent<BoxCollider>();        

        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        //other.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        //Debug.LogFormat("{0}", other.gameObject.name);     
    }


}
