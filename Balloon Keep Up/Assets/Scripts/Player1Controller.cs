using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 1;
    public float keepUpStrength = 5;
    public float rotationSpeed = 30;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float turn = Input.GetAxis("Turn1");

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Balloon")) {
            Rigidbody balloonRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 keepUpDirection = collision.gameObject.transform.position - transform.position;
            
            balloonRb.AddForce(keepUpDirection * keepUpStrength, ForceMode.Impulse);
        }
    }
}
