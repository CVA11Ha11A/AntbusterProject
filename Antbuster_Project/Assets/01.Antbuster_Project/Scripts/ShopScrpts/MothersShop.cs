using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MothersShop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject canon001;
    private GameObject canon001Clone;

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
        // LEGACY : ������ ������Ʈ �����ڸ� ����
        //if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� ���� ��
        //{
        //    // ���콺 ��ġ���� ���̸� ��� �浹 ������ ���մϴ�.
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // �̹����� �巡���� ��ġ�� ������Ʈ ����
        //        canon001 = Instantiate(canon001, hit.point, Quaternion.identity);
        //    }
        //}

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� ���� ��
        {
            // �̹����� ���� ��ġ�� ������Ʈ ����
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && canon001Clone != null) // ���콺 ���� ��ư�� ������ �ִ� ����
        {
            // ���콺�� ����ٴϴ� ��ġ�� ������Ʈ �̵�
            canon001Clone.transform.position = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0) && canon001Clone != null) // ���콺 ���� ��ư�� �� ��
        {
            // ������Ʈ�� ���� ��ġ�� ������Ʈ ����
            Destroy(canon001Clone);
            canon001Clone = Instantiate(canon001, GetMouseWorldPosition(), Quaternion.identity);
        }
    

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


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

    //���콺 �������̽�
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


            //Debug.LogFormat("�������� ������ �غ� �Ǿ��� -> {0}",eventData.delta);

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
        //Vector3 mousePotition = eventData.
    }

}
