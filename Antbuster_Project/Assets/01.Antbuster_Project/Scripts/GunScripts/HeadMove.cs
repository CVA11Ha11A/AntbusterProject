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
        //Debug.LogFormat("타워의 값  포지션 -> {0}", transform.position);
        //Debug.LogFormat("타겟의 이름 -> {0}", target.name);

        //아래 변수가 AttackTime 일때 공격하게 만들예정
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
        
        //Debug.Log("콜라이더 Enter 들어오나?");
    }
    public void OnTriggerStay(Collider other)
    {
        //Vector3 dir = other.transform.position - this.transform.position;
        //Debug.LogFormat("dir 값 -> {0} rotate 값 -> {1}", dir, this.transform.rotation);

        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);

        //transform.LookAt(other.transform);
        //Debug.Log("인식은 되나?");

        if (other.tag == "Enemy" && other.gameObject == target)
        {
            canonBody.transform.LookAt(other.transform);
            GameObject bulletClone_ = default;

            if(attackTime < attackDelay) //if : 공격 타이밍 됬을떄 총알 생성
            {
                bulletClone_ = Instantiate(bulletClone, gunPoint.transform.position, gameObject.transform.rotation);
                attackDelay = 0;

                //Debug.LogFormat("Bullet rotation: {0}", bulletClone_.transform.localRotation);
            }

            //Debug.LogFormat("오브젝트 이름 -> {0} 오브젝트 테그 -> {1}", other.name, other.tag);
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

