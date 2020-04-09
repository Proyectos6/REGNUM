using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Inventario_UI inventarioUI;
    void Awake()
    {
        inventory = new Inventory();
        inventarioUI.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
