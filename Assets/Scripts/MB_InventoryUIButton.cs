using TMPro;
using UnityEngine;

public class MB_InventoryUIButton : MonoBehaviour
{

    public TMP_Text text;
    public void SetButton(MB_Items Item) 
    {
        text.text = Item.Name;
    
    
    
    }
}
