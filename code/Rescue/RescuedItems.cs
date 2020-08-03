using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuedItems : MonoBehaviour
{
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Stop at the land surface
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ground")
        {
            rigidBody.useGravity = false;
            rigidBody.velocity = Vector3.zero;
        }
    }
}
