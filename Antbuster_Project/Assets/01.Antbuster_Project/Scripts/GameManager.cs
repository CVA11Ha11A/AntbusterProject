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

    //���̰� �¾Ҵٴ°� �˷��� ����
    RaycastHit rayHit;
    //���̺���
    Ray ray;

    public float loundTime = 10;
    //������ ����
    public float rayDistance;
    public int playerGold = 0;

    public bool isNextRound = false;
    public bool isOnGold = false;
    public bool isOpenShop = false;


    #region �̱���
    // �̱��� �ν��Ͻ��� ������ private ���� ����
    private static GameManager instance;

    // �ٸ� ��ũ��Ʈ���� �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡�� ���� ����
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // ������ �ν��Ͻ��� ã�� ���� ���, ���ο� ���� ������Ʈ�� �߰��Ͽ� ����
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    instance = singletonObject.AddComponent<GameManager>();
                }

                // ���� ����Ǿ �������� �ʵ��� ����
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    // ��Ÿ �̱��� Ŭ������ ������ �����մϴ�.
    // ���� ���, ������ �����ͳ� ����� �߰��� �� �ֽ��ϴ�.
    // private ������ ����Ͽ� �ٸ� ��ũ��Ʈ���� �������� ���ϵ��� �� ���� �ֽ��ϴ�.
    // ��: private int score;

    private void Awake()
    {
        // �ν��Ͻ��� �̹� �����ϴ� ��� �ߺ� ������ �����մϴ�.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // ���� ����Ǿ �������� �ʵ��� ����
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
            //TODO : ���� �¸� 
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
            //Debug.LogFormat("Round ������ -> {0}    isNextRound bool �� -> {1} ", Round, isNextRound);
        }
    }

    public void LookAtGold()
    {
        //if ��� ���̰����� �Ⱥ��̰� ����
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
        if (Input.GetKeyDown(KeyCode.G)) // if : GŰ������ True False �ٲ�
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

