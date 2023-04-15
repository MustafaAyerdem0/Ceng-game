using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float maxMoveSpeed = 20f;
    public float jumpForce = 5.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;

    public Image speedImage;

    public GameObject[] CheckPoints;
    public int currentCp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    // Update is called once per frame
    void Update()
    {
         if (GameManager.instance.startGame)
        {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        //mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f); // Limit vertical rotation angle

        transform.eulerAngles = new Vector3(4.63f, mouseX, 0); // Rotate player view with mouse

      

        speedImage.fillAmount = Mathf.Lerp(speedImage.fillAmount, moveSpeed / maxMoveSpeed, 0.02f);
        speedImage.color = Color.Lerp(Color.red , Color.green, (moveSpeed / maxMoveSpeed) );
        transform.position = new Vector3(transform.position.x , -5.20f , transform.position.z); 
        }


    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
         if (GameManager.instance.startGame)
        {
        Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + moveDirection);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SpeedPotion"))
        {
            moveSpeed+=5;
            Invoke(nameof(DecreaseSpeed),5f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CheckPoint"))
        {
            CheckPoints[currentCp].SetActive(false);
            currentCp++;
            if(currentCp<CheckPoints.Length);
                CheckPoints[currentCp].SetActive(true);

        }
    }

    void DecreaseSpeed(){
         moveSpeed-=5;
    }
}




