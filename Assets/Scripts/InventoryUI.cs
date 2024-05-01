using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI carrotText;

    // Start is called before the first frame update
    void Start()
    {
        carrotText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCarrotText(PlayerInventory playerInventory)
    {
        carrotText.text = playerInventory.NumberOfCarrots.ToString();
        
    }

}
