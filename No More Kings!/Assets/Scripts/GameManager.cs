using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mail;

    // Start is called before the first frame update
    void Start()
    {
        //Entering specific transform locations for all spawn locations
        Vector3[] positions = new Vector3[]
        {
            new Vector3(-173f, 0f, -222f),
            new Vector3(-173f, 0f, -323f),
            new Vector3(-173f, 0f, -421.5f),
            new Vector3(123f, 0f, -222f),
            new Vector3(123f, 0f, -323f),
            new Vector3(123f, 0f, -421.5f),
            new Vector3(-131f, 0f, -280f),
            new Vector3(-75f, 0f, -280f),
            new Vector3(19f, 0f, -280f),
            new Vector3(75f, 0f, -280f),
            new Vector3(-131f, 0f, -385f),
            new Vector3(-75f, 0f, -385f),
            new Vector3(19f, 0f, -385f),
            new Vector3(75f, 0f, -385f),
            new Vector3(-131f, 0f, -480f),
            new Vector3(-75f, 0f, -480f),
            new Vector3(19f, 0f, -480f),
            new Vector3(75f, 0f, -480f)

        };

        Instantiate(mail, positions[0], mail.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
