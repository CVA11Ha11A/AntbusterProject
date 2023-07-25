using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{

    public GameObject target = default;
    private GameObject canonBody = default;
    private GameObject gunPoint = default;
    public GameObject bullet = default;

    private GameObject bulletClone = default;

    public float attackTime = 1;
    public float attackDelay = 0;
    


    private void Awake()
    {
        canonBody = gameObject.FindChildObj("CanonBody_lvl_1");
        gunPoint = gameObject.FindChildObj("gunpoint");
        bulletClone = bullet;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogFormat("Ÿ���� ��  ������ -> {0}", transform.position);
        //Debug.LogFormat("Ÿ���� �̸� -> {0}", target.name);

        //�Ʒ� ������ AttackTime �϶� �����ϰ� ���鿹��
        attackDelay += attackTime* Time.deltaTime;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (target == default)
            { 
              target = other.gameObject;
            }

            // LEGACY: 
            //Debug.LogFormat("Tower rotation Before: {0}", transform.localRotation.eulerAngles);
            //canonBody.transform.LookAt(other.transform);
            //Debug.LogFormat("Tower rotation After: {0}", transform.localRotation.eulerAngles);

            //Debug.LogFormat("Obj name: {0}, Obj tag: {1}, this.name: {2}", 
            //    other.name, other.tag, canonBody.name);

            //canonBody.transform.LookAt(other.transform);
        }
        
        //Debug.Log("�ݶ��̴� Enter ������?");
    }
    public void OnTriggerStay(Collider other)
    {
        //Vector3 dir = other.transform.position - this.transform.position;
        //Debug.LogFormat("dir �� -> {0} rotate �� -> {1}", dir, this.transform.rotation);

        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);

        //transform.LookAt(other.transform);
        //Debug.Log("�ν��� �ǳ�?");

        if (other.tag == "Enemy" && other.gameObject == target)
        {
            canonBody.transform.LookAt(other.transform);
            GameObject bulletClone_ = default;

            if(attackTime < attackDelay) //if : ���� Ÿ�̹� ������ �Ѿ� ����
            {
                bulletClone_ = Instantiate(bulletClone, gunPoint.transform.position, gameObject.transform.rotation);
                attackDelay = 0;

                //Debug.LogFormat("Bullet rotation: {0}", bulletClone_.transform.localRotation);
            }

            //Debug.LogFormat("������Ʈ �̸� -> {0} ������Ʈ �ױ� -> {1}", other.name, other.tag);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(target != default && target.gameObject && other.gameObject == target.gameObject)
        {
            target = default;
        }
    }
}

