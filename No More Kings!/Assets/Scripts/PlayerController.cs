using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] int bagCapacity = 10;
    public int currentBagSize;

    private void Start()
    {
        currentBagSize = 0;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the vehicle based on horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

}
