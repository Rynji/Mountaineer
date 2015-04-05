using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Handling
    public bool allowManualControl;
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;

    float pushbackSpeed;
    public float _pushbackSpeed
    {
        get { return pushbackSpeed; }
        set { pushbackSpeed = value; }
    }

    int inputRight, inputForward;

    // System
    Quaternion targetRotation;

    // Components
    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        pushbackSpeed = 0.05f;
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
            moveForward(1);
        if (Input.GetKeyUp("w"))
            moveForward(0);
        if (Input.GetKeyDown("a"))
            moveLeft(1);
        if (Input.GetKeyUp("a"))
            moveLeft(0);
        if (Input.GetKeyDown("d"))
            moveRight(1);
        if (Input.GetKeyUp("d"))
            moveRight(0);

    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(inputForward, 0, -inputRight);

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);

        //Static pushing back.
        controller.Move(Vector3.left * pushbackSpeed);
    }

    public void moveLeft(int inputValue)
    {
        inputRight = -inputValue;
    }

    public void moveRight(int inputValue)
    {
        inputRight = inputValue;
    }

    public void moveForward(int inputValue)
    {
        inputForward = inputValue;
    }



}
