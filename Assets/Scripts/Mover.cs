using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float moveSpeed = 9f;
    float rotationSpeed = 800.0f;

    public float raycastDistance = 25.0f; // Distance ahead of the GameObject to cast the ray
    public LayerMask collisionLayerMask; // Layer mask to filter which objects the ray should detect

    private Rigidbody rb; // Rigidbody component of the GameObject

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RaycastCollisionDetector();

    }


    void PrintInstructions()
    {
        Debug.Log("Welcome to the Game.");
        Debug.Log("Use 'WASD' or arrow keys to move.");
        Debug.Log("Press Space to jump.");
        Debug.Log("Don't hit the walls.");
    }

    void MovePlayer()
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
    void RaycastCollisionDetector()
    {
        // Cast a ray forward from the GameObject
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits any collider within raycastDistance
        if (Physics.Raycast(ray, out hit, raycastDistance, collisionLayerMask))
        {
            // Log the name of the hit object
            Debug.Log("Raycast hit: " + hit.collider.name);

            // Stop the GameObject's movement
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }

            // Optionally, you can perform other actions upon collision,
            // like playing a sound, changing animation, etc.
        }
    }
}
