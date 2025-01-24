using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        if (rb != null)
        {
            rb.velocity = velocity;
        }
    }

    public void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
    }
}
