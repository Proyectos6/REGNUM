using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator animator;
    

    bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorControl("open");
        } 
    }

    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorControl("close");
        }
    }

    void DoorControl (string direction)
    {
        animator.SetTrigger(direction);
    }
}
