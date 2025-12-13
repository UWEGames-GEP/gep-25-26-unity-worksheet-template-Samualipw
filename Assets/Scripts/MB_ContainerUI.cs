using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MB_ContainerUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public MB_Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        RefreshInventroy();
    }

    void RefreshInventroy() 
    {
        Debug.Log("Refresh Inventory UI");

        //stuff

        foreach (GameObject uiButton in inventoryUIButtons) 
        { 
            uiButton.SetActive(false);
        }


        for (int i = 0; i < inventory.MB_Items.Count; i++)
        {
            if (i < inventoryUIButtons.Count) 
            {
                MB_InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<MB_InventoryUIButton>();
                MB_Items item = inventory.MB_Items[i];

                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);

            }

        }    

    }

    public void OnInventoryUIButton(int i) 
    {
        inventory.RemoveItemFromInventory(i);
        RefreshInventroy();
    
    
    
    }
}
