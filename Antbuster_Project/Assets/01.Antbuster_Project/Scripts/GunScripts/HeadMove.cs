using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{

    public GameObject target;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        transform.LookAt(other.transform);
        Debug.Log("콜라이더 Enter 들어오나?");
    }
    public void OnTriggerStay(Collider collider)
    {
        //Vector3 dir = other.transform.position - this.transform.position;
        //Debug.LogFormat("dir 값 -> {0} rotate 값 -> {1}", dir, this.transform.rotation);

        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);

        transform.LookAt(collider.transform);
        Debug.Log("인식은 되나?");
    }
}
