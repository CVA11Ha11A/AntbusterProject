using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon004 : MonoBehaviour
{
    // target�� ����δ°� ���� �Ʒ��� ������ ������Ʈ �־��ٰ���
    public GameObject target = default;

    private GameObject canonBody = default;
    private GameObject gunPointLeft = default;
    private GameObject gunPointRight = default;
    public GameObject bullet = default;

    private GameObject bulletClone = default;

    public float attackTime = 1f;
    public float attackDelay = 0;



    private void Awake()
    {
        canonBody = gameObject.FindChildObj("CanonBody_lvl_4");
        gunPointLeft = gameObject.FindChildObj("gunpoint_L");
        gunPointRight = gameObject.FindChildObj("gunpoint_R");
        bulletClone = bullet;
    }

    void Start()
    {

    }

    void Update()
    {

        //�Ʒ� ������ AttackTime �϶� �����ϰ� ���鿹��
        attackDelay += attackTime * 10 * Time.deltaTime;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (target == default)
            {
                target = other.gameObject;
            }


        }

    }
    public void OnTriggerStay(Collider other)
    {


        //transform.LookAt(other.transform);       

        if (other.tag == "Enemy" && other.gameObject == target)
        {
            canonBody.transform.LookAt(other.transform);
            GameObject bulletClone_ = default;

            if (attackTime <= attackDelay) //if : ���� Ÿ�̹� ������ �Ѿ� ����
            {
                bulletClone_ = Instantiate(bulletClone, gunPointLeft.transform.position, gameObject.transform.rotation);
                bulletClone_ = Instantiate(bulletClone, gunPointRight.transform.position, gameObject.transform.rotation);
                attackDelay = 0;

            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (target != default && target.gameObject && other.gameObject == target.gameObject)
        {            
            target = default;
            
        }
    }

    // LEGACY :
    //Vector3 dir = other.transform.position - this.transform.position;
    //Debug.LogFormat("dir �� -> {0} rotate �� -> {1}", dir, this.transform.rotation);

    //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);

    // LEGACY: 
    //Debug.LogFormat("Tower rotation Before: {0}", transform.localRotation.eulerAngles);
    //canonBody.transform.LookAt(other.transform);
    //Debug.LogFormat("Tower rotation After: {0}", transform.localRotation.eulerAngles);

    //Debug.LogFormat("Obj name: {0}, Obj tag: {1}, this.name: {2}", 
    //    other.name, other.tag, canonBody.name);

    //canonBody.transform.LookAt(other.transform);
}
