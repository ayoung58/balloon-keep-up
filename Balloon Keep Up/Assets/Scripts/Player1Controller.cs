using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // float turn = Input.GetAxis("Horizontal");
        // transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime);
        // Vector3 direction = (focalPoint.transform.position - transform.position).normalized;

        // if (Input.GetKey(KeyCode.UpArrow)) {
        //     rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
        // } else if (Input.GetKey(KeyCode.DownArrow)) {
        //     rb.MovePosition(transform.position - direction * Time.deltaTime * speed);
        // }
        
    }

    
}
