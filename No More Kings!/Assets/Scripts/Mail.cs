using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mail : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        //Destroys mail object, if player mailbag is not full
        if(other.gameObject.CompareTag("Player") && other.GetComponent<PlayerController>().currentBagSize < 5)
        {
            Destroy(gameObject);
        }
    }
}
