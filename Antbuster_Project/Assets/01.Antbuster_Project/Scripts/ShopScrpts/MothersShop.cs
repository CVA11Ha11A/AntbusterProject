using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MothersShop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public bool isOpenShop = false;
    public bool isDraging = false;


    public int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

 

        ShopOpenMethod();
    }

    public void ShopOpenMethod()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isOpenShop == false)
            {
                gameObject.SetActive(true);
                isOpenShop = true;

            }

            else if (isOpenShop == true)
            {
                gameObject.SetActive(false);
                isOpenShop = false;
            }
        }
        else { /* PASS */ }
        
    }

    //마우스 인터페이스
    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (isDraging)
        {
            //LEGACY:
            //itemRect.anchoredPosition += eventData.delta;
            //canon001Clone.anchoredPosition += (eventData.delta / uiCanvas.scaleFactor);

           //canon001Clone = Instantiate(canon001,)


            //Debug.LogFormat("아이콘을 움직일 준비가 되었음 -> {0}",eventData.delta);

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
        //Vector3 mousePotition = eventData.
    }

    // LEGACY : 포탑 드래그해서 놓았을때 포탑 생성 로직
    /*
       if (Input.GetMouseButtonDown(0) && GameManager.Instance.playerGold >= 100) // 마우스 왼쪽 버튼을 누를 때
        {
            //plyaer 골드 소비
            GameManager.Instance.playerGold = GameManager.Instance.playerGold - 100;
            // 이미지를 누른 위치에 오브젝트 생성
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && canon001Clone != null) // 마우스 왼쪽 버튼을 누르고 있는 동안
        {
            // 마우스를 따라다니는 위치로 오브젝트 이동
            canon001Clone.transform.position = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0) && canon001Clone != null) // 마우스 왼쪽 버튼을 뗄 때
        {
            // 오브젝트의 최종 위치에 오브젝트 생성
            Destroy(canon001Clone);
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }
    

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
     */

    // LEGACY : 누를때 오브젝트 누른자리 생성
    /*if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 누를 때
    //{
    //    // 마우스 위치에서 레이를 쏘아 충돌 지점을 구합니다.
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        // 이미지를 드래그한 위치에 오브젝트 생성
    //        canon001 = Instantiate(canon001, hit.point, Quaternion.identity);
    //    }
    }*/


}
