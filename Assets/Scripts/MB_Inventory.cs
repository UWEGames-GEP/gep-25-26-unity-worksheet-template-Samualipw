using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class MB_Inventory : MonoBehaviour
{


    public List<string> items = new List<string>();

    public MB_GameManager gameManager;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<MB_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            AddItemToInventory("Tree");
        
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RemoveItemFromInventory("Tree");

        }
    }
    public void AddItemToInventory(string item) 
    {
        if (gameManager.state == GameState.GAMEPLAY) 
        {
            items.Add(item);
        }
    }

    public void RemoveItemFromInventory(string item)
    {
        if (gameManager.state == GameState.GAMEPLAY)
        {
            items.Remove(item);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        MB_Items collisionItem = hit.gameObject.GetComponent<MB_Items>();

        if (collisionItem != null) 
        { 
            AddItemToInventory(collisionItem.name);
            Destroy(collisionItem.gameObject);
        }
    }
    




}
