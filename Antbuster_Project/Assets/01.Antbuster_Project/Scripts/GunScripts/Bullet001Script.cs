using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet001Script : MonoBehaviour
{
    public float bulletSpeed = 70.0f;
    public int bulletDamage = 50;

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
        //Debug.LogFormat("dir �� -> {0} rotate �� -> {1}", dir, this.transform.rotation);
        //Debug.LogFormat("Ÿ���� ���� �� �������� ->{0}   Ÿ���� �̸� -> {1}", target.transform.position,target.name);

        //transform.rotation = Quaternion.Euler(0,0,90);
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

            transform.position += dir * 3 * Time.deltaTime;
            
            
        }

        //transform.position += Vector3.positiveInfinity * bulletSpeed * Time.deltaTime;


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
                Debug.Log("���� ��� ������?");
            }
        }
    }
}
