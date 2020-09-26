using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 25.0f;
    public int currentBagSize = 0;
    private GameManager gameManager;


    //Movement controls
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
        if (currentBagSize > 0 && other.CompareTag("Dropoff"))
        {

            if (currentBagSize > 1)
                gameManager.score += currentBagSize * (currentBagSize * 20);
            else
                gameManager.score += 20;

            gameManager.mailbag = 0;
            currentBagSize = 0;
        }
        //Will add the mail too the the current mailbag if there is room left
        if (other.CompareTag("Mail") && currentBagSize < 5)
        {
            currentBagSize++;
            gameManager.mailbag++;
            gameManager.totalVotes++;
        }
    }

 

}
