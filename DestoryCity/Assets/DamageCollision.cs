using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * 
 * 检测是否受到粒子碰撞
 * 
 */
public class DamageCollision: MonoBehaviour
{
    public Slider sliders;
    //public int bloodValue = 10;

    public float currentHealth;

    public float health = 10;
    float damage = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (sliders.value == 0)
        {
            Destroy(this.gameObject);
        }
    }
/*
    private void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        Debug.Log("currentHealth = "+currentHealth);
    }
*/

    //检测是否碰撞到粒子
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == ("aa"))
        {
            sliders.value -= damage;
            Debug.Log("sliders.value = " + sliders.value);
        }
        if (other.tag == ("bb"))
        {
            sliders.value -= damage;
            Debug.Log("sliders.value = " + sliders.value);
        }

    }
}
