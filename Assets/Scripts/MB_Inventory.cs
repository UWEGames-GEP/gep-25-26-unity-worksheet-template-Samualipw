using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using UnityEngine.InputSystem;

public class MB_Inventory : MonoBehaviour
{


    //public List<string> items = new List<string>();
    public List<MB_Items> MB_Items = new List<MB_Items>();


    public MB_GameManager gameManager;
    Transform worldItemsTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<MB_GameManager>();

        Transform worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            AddItemToInventory("Tree");
        
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RemoveItemFromInventory("Tree");

        }
        */
    }
    public void AddItemToInventory(MB_Items item) 
    {
        if (gameManager.state == GameState.GAMEPLAY) 
        {
            MB_Items.Add(item);
            //items.Add(item);
        }
    }


    // REMOVE ITEM FUNCTIONS

    // Specific Item Removal

    /*
    public void RemoveItemFromInventory(MB_Items item)
    {
        if (gameManager.state == GameState.GAMEPLAY)
        {
            MB_Items.Remove(item);
        }
    }

    public void RemoveItemFromInventory()
    {
        if ((gameManager.state == GameState.GAMEPLAY) && (MB_Items.Count > 0))
        {
            MB_Items item = MB_Items[0];

            // properties grab
            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 100);

            // Instanceing Time
            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            MB_Items.Remove(item);
            Destroy(item.gameObject);

        }


    }

    */




    public void RemoveItemFromInventory(MB_Items item)
    {
        // properties grab
        Vector3 currentPosition = transform.position;
        Vector3 forward = transform.forward;

        Vector3 newPosition = currentPosition + forward;
        newPosition += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 100);

        // Instanceing Time
        GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
        newItem.SetActive(true);

        MB_Items.Remove(item);
        Destroy(item.gameObject);
    }

    public void RemoveItemFromInventory()
    {
        if ((gameManager.state == GameState.GAMEPLAY) && (MB_Items.Count > 0))
        {
            MB_Items item = MB_Items[0];

            RemoveItemFromInventory(item);

        }


    }

    public void RemoveItemFromInventory(int i) 
    { 
        if (i < MB_Items.Count) 
        {
            RemoveItemFromInventory(MB_Items[i]);
        }
    }



    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        MB_Items collisionItem = hit.gameObject.GetComponent<MB_Items>();

        if (collisionItem != null) 
        { 
            AddItemToInventory(collisionItem);

            collisionItem.gameObject.SetActive(false);
            //Destroy(collisionItem.gameObject);
        }
    }
    
    



}
