using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{ 

    [SerializeField] int score = 20;
    [SerializeField] GameObject player;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Collects mail for player, and adds to bag. Unless mailbag is full, then mail is not destroyed.
        if(other.gameObject.CompareTag("Player") && other.GetComponent<PlayerController>().currentBagSize < 2)
        {
            Destroy(gameObject);
            other.GetComponent<PlayerController>().currentBagSize++;
        }
    }
}
