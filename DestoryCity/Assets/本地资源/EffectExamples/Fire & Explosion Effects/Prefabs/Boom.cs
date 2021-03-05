using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boom : MonoBehaviour
{

    private int damage = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //爆炸范围半径
        float R = 2;
        //得到圆心为collision.contacts[0] 半径为R的圆中所有的碰撞体
        Collider[] colliders = Physics.OverlapSphere(collision.contacts[0].point, R);
        foreach(Collider collider in colliders)
        {
            //如果监测到碰撞体
            if (collider.tag == "House")
            {
                //添加爆炸力
                //collider.GetComponent<Rigidbody>().AddExplosionForce(2000f, collision.contacts[0].point, R);
                collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                
                //collider.gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.blue;
                //collider.gameObject.GetComponent<duixiang>().TakeDamage(damage);

                
            }
        }
    }
}
