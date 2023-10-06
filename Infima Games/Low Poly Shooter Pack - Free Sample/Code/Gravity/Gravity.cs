using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityStrength = 9.8f; // Adjust this value to control the strength of gravity
    public float jumpForce = 5.0f; // Adjust this value to control the strength of the jump

    [SerializeField] private bool isGrounded = true;

    void Update()
    {
        ApplyGravity();

        // Check for jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void ApplyGravity()
    {
        // Calculate the gravity vector
        Vector3 gravityVector = new Vector3(0, -gravityStrength, 0);

        // Apply gravity to the object using Unity's physics engine
        GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Force);
    }

    void Jump()
    {
        // Apply a force in the upward direction to simulate a jump
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Prevent multiple jumps until the object is grounded again
    }

    // Check if the object is grounded
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }
}
