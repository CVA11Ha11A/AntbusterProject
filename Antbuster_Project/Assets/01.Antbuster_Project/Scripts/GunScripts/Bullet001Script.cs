using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet001Script : MonoBehaviour
{
    public float bulletSpeed = 3.0f;
    public int bulletDamage = 50;
    public bool isHit = false;

    public HeadMove classInTarget;


    private GameObject target;


    public void Awake()
    {
        classInTarget = FindObjectOfType<HeadMove>();
        target = classInTarget.target;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 5f);
        //Debug.LogFormat("dir 값 -> {0} rotate 값 -> {1}", dir, this.transform.rotation);
        //Debug.LogFormat("타겟의 값이 잘 들어오는지 ->{0}   타겟의 이름 -> {1}", target.transform.position,target.name);

        //transform.rotation = Quaternion.Euler(0,0,90);
        Invoke("MoreSpeed", 3f);
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null || target != default)
        {
            
            Vector3 dir = target.transform.position - this.transform.position;
            // Quaternion rot = Quaternion.LookRotation(dir.normalized);
            //transform.rotation = Quaternion.LookRotation(dir);

            //transform.rotation = Quaternion.LookRotation(dir);
            //transform.rotation = Quaternion.Euler(dir);

            transform.LookAt(target.transform);

            if(isHit == false)
            {
                transform.position += dir * bulletSpeed * Time.deltaTime;
            }

            
            
        }

        //transform.position += Vector3.positiveInfinity * bulletSpeed * Time.deltaTime;


    }

    public void MoreSpeed()
    {
        bulletSpeed = 10;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.name == "Enemy_Warrio(Clone)")
            { 
                WormEnemyControler enemyHit01 = other.GetComponent<WormEnemyControler>();
                enemyHit01.enemyHp = enemyHit01.enemyHp - bulletDamage;
                Destroy (gameObject);
                
            }

            else if(other.name == "Enemy_Fly(Clone)")
            {
                FlyEnemyControler enemyHit02 = other.GetComponent<FlyEnemyControler>();
                enemyHit02.enemyHp = enemyHit02.enemyHp - bulletDamage;
                Destroy(gameObject);
                Debug.Log("여기 계속 들어오나?");
            }
        }
    }
}
