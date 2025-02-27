using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set;}
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotManager> slots = new List<SlotManager>();
   
    // Update is called once per frame...
    void Update()
    {
        if(InputsHandler.GetInstance().inventoryButtonPressed())
        {
            ToggleTempInventory();
        }
        Refresh();
    }

    public void ToggleTempInventory()
    {
        
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
           
        }
        else
        {
            inventoryPanel.SetActive(false);   
        }
    }

    public void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i= 0; i<slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableItemsType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotNUM)
    {  
            player.inventory.Remove(slotNUM);
    }

}
