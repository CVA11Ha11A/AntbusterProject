using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterSponer : MonoBehaviour
{
    //float sponTime = 1;

    public GameObject warriorEnemy;
    public GameObject flyEnemy;

    private GameObject warriorClone;
    private GameObject flyClone;
    

    // Start is called before the first frame update
    public void Awake()
    {

    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isNextRound == false)
        {
            WhyMonter();
            GameManager.Instance.isNextRound = true;
        }
    }

    public void MakeWarrior()
    {
        warriorClone = Instantiate(warriorEnemy, transform.position, warriorEnemy.transform.rotation);
    }

    public void MakeFly()
    {
        flyClone = Instantiate(flyEnemy, transform.position, flyEnemy.transform.rotation);
    }

    public void WhyMonter()
    {
        //라운드 10 이하일때
        if (GameManager.Instance.Round * 0.1 <= 1)
        {
            for (int x = 0; x < 30; x++)
            {
                Invoke("MakeWarrior", 1f * x);
            }            
        }
        //라운드 20 이하일때
        else if (GameManager.Instance.Round * 0.1 <= 2)
        {
            for (int x = 0; x < 30; x++)
            {
                Invoke("MakeFly", 1f * x);
            }
        }
        //라운드 30 이하일때
        else if (GameManager.Instance.Round * 0.1 <= 3)
        {
            for (int x = 0; x < 30; x++)
            {
                Invoke("MakeWarrior", 1f * x);
            }
        }
        //라운드 40 이하일떄
        else if (GameManager.Instance.Round * 0.1 <= 4)
        {
            for (int x = 0; x < 30; x++)
            {
                Invoke("MakeFly", 1f * x);
            }
        }
        //라운드 50 이하일때
        else if (GameManager.Instance.Round * 0.1 <= 5)
        {
            for (int x = 0; x < 30; x++)
            {
                Invoke("MakeFly", 1f * x);
            }
        }

        


    }
}
