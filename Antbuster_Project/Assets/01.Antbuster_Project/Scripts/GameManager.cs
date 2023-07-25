using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;
    public GameObject shopMotherObj;
    public TMP_Text nowLoundTime;
    public TMP_Text playerGoldText;
    public int Round = 1;

    //레이가 맞았다는걸 알려줄 변수
    RaycastHit rayHit;
    //레이변수
    Ray ray;

    public float loundTime = 10;
    //레이의 길이
    public float rayDistance;
    public int playerGold = 0;

    public bool isNextRound = false;
    public bool isOnGold = false;
    public bool isOpenShop = false;


    #region 싱글톤
    // 싱글톤 인스턴스를 저장할 private 정적 변수
    private static GameManager instance;

    // 다른 스크립트에서 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에만 새로 생성
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // 씬에서 인스턴스를 찾지 못한 경우, 새로운 게임 오브젝트에 추가하여 생성
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    instance = singletonObject.AddComponent<GameManager>();
                }

                // 씬이 변경되어도 삭제되지 않도록 설정
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    // 기타 싱글톤 클래스의 로직을 구현합니다.
    // 예를 들어, 공유할 데이터나 기능을 추가할 수 있습니다.
    // private 변수를 사용하여 다른 스크립트에서 접근하지 못하도록 할 수도 있습니다.
    // 예: private int score;

    private void Awake()
    {
        // 인스턴스가 이미 존재하는 경우 중복 생성을 방지합니다.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // 씬이 변경되어도 삭제되지 않도록 설정
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Round == 51)
        {
            //TODO : 게임 승리 
        }

        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        if(Physics.Raycast(ray.origin,ray.direction,out rayHit,rayDistance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }


        RoundTime();



        LookAtGold();

        LoolAtGoldTF();

        ShopOpenMethod();
    }

    public void RoundTime()
    {
        loundTime -= Time.deltaTime;
        nowLoundTime.text = "Round : " + Round + "     Time : " + loundTime;


        if (loundTime <= 0)
        {
            loundTime = 60;
            Round += 1;
            isNextRound = false;
            //Debug.LogFormat("Round 변수값 -> {0}    isNextRound bool 값 -> {1} ", Round, isNextRound);
        }
    }

    public void LookAtGold()
    {
        //if 골드 보이게할지 안보이게 할지
        if (isOnGold == true)
        {
            playerGoldText.text = "Gold : " + playerGold;
        }
        else if (isOnGold == false)
        {
            playerGoldText.text = "";
        }
    }

    public void LoolAtGoldTF()
    {
        if (Input.GetKeyDown(KeyCode.G)) // if : G키누르면 True False 바뀜
        {
            if (isOnGold == false)
            {
                isOnGold = true;
            }
            else if (isOnGold == true)
            {
                isOnGold = false;
            }
        }

        else { /*PASS*/ }
    }


    public void ShopOpenMethod()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isOpenShop == false)
            {
                shopMotherObj.SetActive(true);
                isOpenShop = true;

            }

            else if (isOpenShop == true)
            {
                shopMotherObj.SetActive(false);
                isOpenShop = false;
            }
        }
        else { /* PASS */ }

    }
}

