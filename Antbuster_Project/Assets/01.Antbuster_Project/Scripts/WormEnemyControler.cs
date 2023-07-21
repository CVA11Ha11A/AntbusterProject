using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemyControler : MonoBehaviour
{
    public GameObject wormObj;

    public float wormSpeed = 1.0f;

    public int checkPoint = 1;

    // Start is called before the first frame update
    void Start()
    {
        //wormObj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Z축을 -방향으로 이동해야함
        if(checkPoint == 1)
        {
            wormObj.transform.position += Vector3.back * (wormSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }
}
