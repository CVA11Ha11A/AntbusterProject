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

        // LEGACY : 타워 눌러서 끌어다 놓으면 생성됨 하지만 여러개 있을떄 있는것들 다됨
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.playerGold >= 500 && !isBuying) // 마우스 왼쪽 버튼을 누를 때
        {
            isBuying = true;
            //plyaer 골드 소비
            GameManager.Instance.playerGold = GameManager.Instance.playerGold - 500;
            // 이미지를 누른 위치에 오브젝트 생성
            canon004Clone = Instantiate(canon004, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && canon004Clone != null && isBuying) // 마우스 왼쪽 버튼을 누르고 있는 동안
        {

            // 마우스를 따라다니는 위치로 오브젝트 이동
            canon004Clone.transform.position = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0) && canon004Clone != null && isBuying) // 마우스 왼쪽 버튼을 뗄 때
        {

            // 오브젝트의 최종 위치에 오브젝트 생성
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

