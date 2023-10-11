using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public GameObject snowballCloneTemplate;

    float currentSpeed, walkingSpeed = 2, runningSpeed = 5, backSpeed = 1;
    private float turningSpeed = 180;

    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        myAnimator = GetComponent<Animator>();


    }

    private float ySpeed;

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W)) 
        { myAnimator.SetBool("isWalking", true);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool("isWalking", true);
            transform.position -= currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed  * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down, turningSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newGO = Instantiate(snowballCloneTemplate);

            snowBallScrypt mySnowball = newGO.GetComponent<snowBallScrypt>();

            mySnowball.ImThrowingYou(this);
        }


    }
}
