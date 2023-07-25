using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower001 : MonoBehaviour
{
    public GameObject canon001;
    private GameObject canon001Clone;

    private bool tower001Buying = false;

   

 

    void Start()
    {
        
    }

    void Update()
    {
        // ���콺 ���� ��ư�� ������ ���� �� ������Ʈ�� �����մϴ�.
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.playerGold >= 100 && !tower001Buying)
        {
            tower001Buying = true;
            //plyaer ��� �Һ�
            GameManager.Instance.playerGold -= 100;
            // �̹����� ���� ��ġ�� ������Ʈ ����
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }

        // ���콺 ���� ��ư�� ������ �ִ� ���� ������Ʈ�� ����ٴϵ��� �մϴ�.
        if (Input.GetMouseButton(0) && canon001Clone != null && tower001Buying)
        {
            // ���콺�� ����ٴϴ� ��ġ�� ������Ʈ �̵�
            canon001Clone.transform.position = GetMouseWorldPosition();
        }

        // ���콺 ���� ��ư�� �� �� ������Ʈ�� ���� ��ġ�� �����մϴ�.
        if (Input.GetMouseButtonUp(0) && canon001Clone != null && tower001Buying)
        {
            Destroy(canon001Clone);

            // ������Ʈ�� ���� ��ġ�� ������Ʈ ����
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
            tower001Buying = false;
        }


        Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

}   //nameSpace
