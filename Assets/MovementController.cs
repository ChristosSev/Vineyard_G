using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement {
    public string type;
    public float num = 0f;
    public string direction;
}

public class MovementController : MonoBehaviour
{
    public List<Movement> moveList = new List<Movement>();
    public float moveSpeed;
    public float turnSpeed;
    public int counter;
    public int currentCommand;
    
    private float distanceToMove;
    
    // Start is called before the first frame update
    void Start()
    {
        distanceToMove = moveList[0].num;
        //InvokeRepeating("takeScreenshot", 0.2f, 0.5f);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentCommand < moveList.Count)
        {
            Debug.Log(currentCommand);
            if (moveList[currentCommand].type == "move")
            {
                Move(moveList[currentCommand]);
            }

            if (moveList[currentCommand].type == "turn")
            {
                Turn(moveList[currentCommand]);
            }
        }
    }

    private void Move(Movement moveCommand)
    {
        Vector3 move = transform.forward;
        if (moveCommand.direction == "forward")
        {
            move = transform.forward;
        }
        if (moveCommand.direction == "left")
        {    
            move = transform.TransformDirection(Vector3.left); 
        }
        if (moveCommand.direction == "right")
        {
            move = transform.TransformDirection(Vector3.right); 
        }
        move = move * Time.deltaTime * moveSpeed;
        transform.position += move;
    
        distanceToMove -= moveSpeed * Time.deltaTime;
        if (distanceToMove <= 0)
        {
            currentCommand++;
            if (currentCommand < moveList.Count)
                distanceToMove = moveList[currentCommand].num;
            
        }
    }


    private void Turn(Movement turnCommand)
    {
        if (turnCommand.direction == "right")
        {
            Debug.Log("Right");
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
        if (turnCommand.direction == "left")
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -turnSpeed);
        }

        distanceToMove -= turnSpeed * Time.deltaTime;
        if (distanceToMove <= 0)
        {
            currentCommand++;
            if (currentCommand < moveList.Count)
                distanceToMove = moveList[currentCommand].num;
        }
    }

    /*
    private void takeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Images/" + counter.ToString() + ".png");
        counter++;
        
    }
    */
}
