using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 1;
    public float keepUpStrength = 5;
    public float rotationSpeed = 30;
    private GameObject focalPoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point 1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime * horizontalInput);
        // rb.MoveRotation(rb.rotation * deltaRotation);
        // rb.(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime);
        Vector3 direction = (focalPoint.transform.position - transform.position).normalized;

        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            rb.MovePosition(transform.position - direction * Time.deltaTime * speed);
        }
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Balloon")) {
            Rigidbody balloonRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 keepUpDirection = collision.gameObject.transform.position - transform.position;
            
            balloonRb.AddForce(keepUpDirection * keepUpStrength, ForceMode.Impulse);
        }
    }
}
