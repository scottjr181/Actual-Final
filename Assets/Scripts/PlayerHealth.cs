using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) 
    {

        //Debug.Log("TAKING DAMAGE");
        currentHealth -= amount;
        if(currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
       
    }
}
