using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyControler : MonoBehaviour
{
    public float wormSpeed = 3.0f;

    public int checkPoint = 1;

    public int enemyHp = 50;

    public void Awake()
    {
        //���尡 �������� ������ HP�� �þ��
        enemyHp = enemyHp * GameManager.Instance.Round;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        MonsterMove();
        EnemyDie();


    }

    public void OnTriggerEnter(Collider other)
    {
        //üũ����Ʈ�� ������ Rotaiton�� �ٲٰ� üũ����Ʈ ��ȭ
        if (other.gameObject.CompareTag("CheckPoint1"))
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            checkPoint = 1;
        }

        if (other.gameObject.CompareTag("CheckPoint2"))
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
    }

    public void MonsterMove()
    {
        // üũ ����Ʈ���� ���������ϴ� ����
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

    public void EnemyDie()
    {
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.playerGold += 20;
        }
    }
}
