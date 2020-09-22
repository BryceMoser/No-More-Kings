using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mail : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        //Collects mail for player, and adds to bag. Unless mailbag is full, then mail is not destroyed.
        if(other.gameObject.CompareTag("Player") && other.GetComponent<PlayerController>().currentBagSize < 5)
        {
            Destroy(gameObject);
        }
    }
}
