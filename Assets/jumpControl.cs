using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpControl : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private bool jump;
    public float jumpPower = 1f;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private int count;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        winText.text = "";
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        jump = Input.GetButton("Jump");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }

   void Move()
    {
        rb.AddForce(moveDirection * speed);

    }
    void Jump()
    {
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
           

        }
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
           

        }



    }



}
