using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public GameObject snowballCloneTemplate;

    Rigidbody myRB;

    float currentSpeed, walkingSpeed = 2, runningSpeed = 5, backSpeed = 1;
    private float turningSpeed = 180;

    public float jumpForce = 500f;

    protected bool doJump = false;

    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        myAnimator = GetComponent<Animator>();

        myRB = GetComponent<Rigidbody>();

    }

    private float ySpeed;
    private object rb;

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
        if(Input.GetKeyDown("space"))
        {
            doJump = true;
        }

        if(transform.position.y< -5f)
        {
            Debug.Log("Game end");
        }

        if(doJump)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            doJump = false;
        }


    }
}
