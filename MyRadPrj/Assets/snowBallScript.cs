using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBallScrypt : MonoBehaviour
{
    Rigidbody rb;
    internal int check = 5;
    // Start is called before the first frame update
    void Start()
    {
       
        rb.velocity = new Vector3(0, 10, -4);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch!");
        dealWithHeats thingIHit = collision.gameObject.GetComponent<dealWithHeats>();
        if (thingIHit != null)
        {
            thingIHit.IHitYou();
        }
    }

    internal void ImThrowingYou(CharControl CharControl)
    {
        transform.position = CharControl.transform.position + 2 * Vector3.up + 3 * CharControl.transform.forward;

        rb = GetComponent<Rigidbody>();

        rb.velocity = 10 * (2 * Vector3.up + 3 * CharControl.transform.forward);
    }

}
