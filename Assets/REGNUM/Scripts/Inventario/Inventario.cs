using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public GameObject panelInventario;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (panelInventario.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }       
    }
}
