using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 25.0f;
    //[SerializeField] int bagCapacity = 10;
    public int currentBagSize = 0;
    private GameManager gameManager;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the vehicle based on horizontal input
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Will add the mail and score to the post office, and will empty the bag of carrying mail
        if (currentBagSize > 0 && gameObject.CompareTag("Dropoff"))
        {
            gameManager.score += currentBagSize * 20;
            currentBagSize = 0;
        }
    }

 

}
