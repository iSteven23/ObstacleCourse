using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float moveSpeed = 10.0f;
    float rotationSpeed = 800.0f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Vector3 moveDirection = new Vector3(xValue, 0, zValue);

        // Move the object
        transform.Translate(moveDirection, Space.World);

        // Rotate the object to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }


    void PrintInstructions()
    {
        Debug.Log("Welcome to the Game.");
        Debug.Log("Use 'WASD' or arrow keys to move.");
        Debug.Log("Press Space to jump.");
        Debug.Log("Don't hit the walls.");
    }
}
