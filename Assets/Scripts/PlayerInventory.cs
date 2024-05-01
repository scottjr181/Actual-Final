using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
 
    public int NumberOfCarrots {  get; private set; }

    public UnityEvent<PlayerInventory> OnCarrotCollected;

    public void CarrotCollected()
    {
        
        NumberOfCarrots++;
        OnCarrotCollected.Invoke(this);
    }
 
}
