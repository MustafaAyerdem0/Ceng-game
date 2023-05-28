using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

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

    public TMP_Text diveCountText;

    public GameObject[] CheckPoints;
    public int currentCp;

    bool isDiving;

    int diveCount;


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
            speedImage.color = Color.Lerp(Color.red, Color.green, (moveSpeed / maxMoveSpeed));
            diveCountText.text = "x" + diveCount.ToString();

            if(!isDiving)
                transform.position = new Vector3(transform.position.x, -5.20f, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isDiving && diveCount>0) // Burada Space tuşuna basılıp basılmadığını kontrol ediyoruz
        {
            // Space tuşuna basıldığında yapılması gereken işlemler buraya yazılır
            diveCount--;
            isDiving = true;
            print(transform.forward);
            transform.DOJump( transform.position + new Vector3 (transform.forward.x, 0, transform.forward.z)*40f, -5f, 1, 2f).
            OnComplete( () => isDiving=false );

           

        }


    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        if (GameManager.instance.startGame && !isDiving)
        {
            Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
            moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

            rb.MovePosition(transform.position + moveDirection);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPotion"))
        {
            moveSpeed += 5;
            Invoke(nameof(DecreaseSpeed), 5f);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnergyPotion"))
        {
            diveCount++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CheckPoint"))
        {
            CheckPoints[currentCp].SetActive(false);
            currentCp++;
            if (currentCp < CheckPoints.Length)
                CheckPoints[currentCp].SetActive(true);

        }

        if (other.CompareTag("FinishLine") && currentCp == 10)
        {
            if (GameManager.instance.PlayerPosition == 1)
                GameManager.instance.winPanel.SetActive(true);
            else
                GameManager.instance.LosePanel.SetActive(true);

            GameManager.instance.retryGameButton.SetActive(true);
            GameManager.instance.finishGame = true;
            GameManager.instance.startGame = false;
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody>());
            Cursor.lockState = CursorLockMode.None;


            Invoke(nameof(CloseScript), 0.5f);




        }
    }

    void CloseScript()
    {
        enabled = false;

    }

    void DecreaseSpeed()
    {
        moveSpeed -= 5;
    }

}




