using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 1f;
    public int numClicked = 0;
    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();

        transform.position += moveVector.normalized * speed * Time.deltaTime;

    }

    void getInput()
    {
        //forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVector += transform.forward;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVector -= transform.forward;
        }


        //backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveVector -= transform.forward;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            moveVector += transform.forward;
        }

        //left
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveVector -= transform.right;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moveVector += transform.right;
        }

        //right
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveVector += transform.right;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveVector -= transform.right;
        }


    }

    private void OnMouseDown()
    {
        numClicked++;
        speed += 1.0f;
    }
}
