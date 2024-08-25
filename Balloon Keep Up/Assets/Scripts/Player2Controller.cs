using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 1;
    public float keepUpStrength = 5;
    public float rotationSpeed = 30;
    // private GameObject focalPoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // focalPoint = GameObject.Find("Focal Point 2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical2");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal2") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // float turn = Input.GetAxis("Horizontal2");
        // transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime);
        // Vector3 direction = (focalPoint.transform.position - transform.position).normalized;

        // if (Input.GetKey(KeyCode.W)) {
        //     rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
        // } else if (Input.GetKey(KeyCode.S)) {
        //     rb.MovePosition(transform.position - direction * Time.deltaTime * speed);
        // }
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Balloon")) {
            Rigidbody balloonRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 keepUpDirection = collision.gameObject.transform.position - transform.position;
            
            balloonRb.AddForce(keepUpDirection * keepUpStrength, ForceMode.Impulse);
        }
    }
}
