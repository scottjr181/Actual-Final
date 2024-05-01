using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    float damageTimer;
    public float DamageInterval = 2f;

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            damageTimer = 0;
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            damageTimer += Time.deltaTime;
            if(damageTimer > DamageInterval)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
                damageTimer = 0;
            }
        }
    }



}
