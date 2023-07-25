using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower004 : MonoBehaviour
{
    public GameObject canon004;
    private GameObject canon004Clone;

    private bool isBuying = false;

  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // LEGACY : Ÿ�� ������ ����� ������ ������ ������ ������ ������ �ִ°͵� �ٵ�
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.playerGold >= 500 && !isBuying) // ���콺 ���� ��ư�� ���� ��
        {
            isBuying = true;
            //plyaer ��� �Һ�
            GameManager.Instance.playerGold = GameManager.Instance.playerGold - 500;
            // �̹����� ���� ��ġ�� ������Ʈ ����
            canon004Clone = Instantiate(canon004, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && canon004Clone != null && isBuying) // ���콺 ���� ��ư�� ������ �ִ� ����
        {

            // ���콺�� ����ٴϴ� ��ġ�� ������Ʈ �̵�
            canon004Clone.transform.position = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0) && canon004Clone != null && isBuying) // ���콺 ���� ��ư�� �� ��
        {

            // ������Ʈ�� ���� ��ġ�� ������Ʈ ����
            Destroy(canon004Clone);
            canon004Clone = Instantiate(canon004, GetMouseWorldPosition(), Quaternion.identity);
            isBuying = false;
        }


        Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    

    }

  

}   // nameSpace

