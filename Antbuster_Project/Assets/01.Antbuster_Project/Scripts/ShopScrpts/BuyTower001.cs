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
        // 마우스 왼쪽 버튼을 누르고 있을 때 오브젝트를 생성합니다.
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.playerGold >= 100 && !tower001Buying)
        {
            tower001Buying = true;
            //plyaer 골드 소비
            GameManager.Instance.playerGold -= 100;
            // 이미지를 누른 위치에 오브젝트 생성
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }

        // 마우스 왼쪽 버튼을 누르고 있는 동안 오브젝트를 따라다니도록 합니다.
        if (Input.GetMouseButton(0) && canon001Clone != null && tower001Buying)
        {
            // 마우스를 따라다니는 위치로 오브젝트 이동
            canon001Clone.transform.position = GetMouseWorldPosition();
        }

        // 마우스 왼쪽 버튼을 뗄 때 오브젝트를 최종 위치에 생성합니다.
        if (Input.GetMouseButtonUp(0) && canon001Clone != null && tower001Buying)
        {
            Destroy(canon001Clone);

            // 오브젝트의 최종 위치에 오브젝트 생성
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
