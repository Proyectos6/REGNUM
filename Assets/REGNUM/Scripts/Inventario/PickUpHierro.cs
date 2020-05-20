using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHierro : MonoBehaviour
{
    public Item item;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private GameObject player;

    public GameObject lingoteHierro;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_2");
        if (player != null)
            inventory = player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
    }

    //La diferencia entre este script y el de PickUpItem es que este no depende de la distancia en float si no de si está dentro del trigger o no.

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && inventory != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entra en contacto el lingoteHierro con el jugador");
            if (inventory.ItemsInInventory.Count < (inventory.width * inventory.height))
            {;
                inventory.addItemToInventory(item.itemID, item.itemValue);
                inventory.updateItemList();
                inventory.stackableSettings();
                Destroy(this.gameObject);;
            }
            bool check = inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
            if (check)
            {          
                inventory.addItemToInventory(item.itemID, item.itemValue);
                inventory.updateItemList();
                inventory.stackableSettings();
                Destroy(this.gameObject);
            }

        }
    }
}
