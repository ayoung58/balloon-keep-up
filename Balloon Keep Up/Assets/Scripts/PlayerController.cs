using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float keepUpStrength = 5;
    public float rotationSpeed = 30;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Balloon")) {
            Rigidbody balloonRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 keepUpDirection = collision.gameObject.transform.position - transform.position;
            
            balloonRb.AddForce(keepUpDirection * keepUpStrength, ForceMode.Impulse);
        }
    }
}
