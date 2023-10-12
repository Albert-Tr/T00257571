using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatCubeControlScript : MonoBehaviour
{
    Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
       myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRB.AddForce(transform.forward);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRB.AddExplosionForce(25, transform.position + Vector3.down, 5);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            myRB.AddExplosionForce(25, transform.position + Vector3.up, 5);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 90  * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
    }
}
