using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{ public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded = true;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        //mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f); // Limit vertical rotation angle

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, mouseX, 0); // Rotate player view with mouse

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + moveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}




