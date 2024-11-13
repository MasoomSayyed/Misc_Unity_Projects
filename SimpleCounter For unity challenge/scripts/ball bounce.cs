using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballbounce : MonoBehaviour
{
    private float bounceForce = 5f;
    public bool isOnGround = false;
    private Rigidbody rbBall;

    private void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isOnGround)
        {
            rbBall.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            BounceCount.Instance.UpdateBounceCount();
        }
    }
}
