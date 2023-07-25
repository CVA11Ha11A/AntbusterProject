using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemyControler : MonoBehaviour
{
    private GameObject bullet;

    public float wormSpeed = 1.0f;

    public int checkPoint = 1;

    public int enemyHp = 100;

    public void Awake()
    {
        enemyHp = enemyHp * GameManager.Instance.Round;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyDie();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint1"))
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            checkPoint = 1;
        }

        if(other.gameObject.CompareTag("CheckPoint2"))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            checkPoint = 2;
        }
        if (other.gameObject.CompareTag("CheckPoint3"))
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            checkPoint = 3;
        }
        if (other.gameObject.CompareTag("CheckPoint4"))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            checkPoint = 4;
        }
        else { /* Pass */ }

    

    }

    public void EnemyDie()
    {
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.playerGold += 20;
        }
    }

    public void EnemyMove()
    {
        // Z���� -�������� �̵��ؾ���
        if (checkPoint == 1)
        {
            transform.position += Vector3.back * (wormSpeed * Time.deltaTime);
        }
        if (checkPoint == 2)
        {
            transform.position += Vector3.right * (wormSpeed * Time.deltaTime);
        }
        if (checkPoint == 3)
        {
            transform.position += Vector3.forward * (wormSpeed * Time.deltaTime);
        }
        if (checkPoint == 4)
        {
            transform.position += Vector3.left * (wormSpeed * Time.deltaTime);
        }
    }

}
