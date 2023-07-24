using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;

    public TMP_Text nowLoundTime;
    public int Round = 1;

    public float loundTime = 10;

    public bool isNextRound = false;

    public int playerGold = 0;

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

        loundTime -= Time.deltaTime;
        nowLoundTime.text = "Round : " + Round + "     Time : " + loundTime;
        if(loundTime <= 0)
        {
            loundTime = 60;
            Round += 1;
            isNextRound = false;
            Debug.LogFormat("Round ������ -> {0}    isNextRound bool �� -> {1} ", Round, isNextRound);
        }
    }
}
