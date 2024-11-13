using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody playerRB;
    public float moveSpeed = 5.0f;
    private float pushStrentgh = 15;

    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;

    public bool isPowerupActive = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardIput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position + new Vector3(0,-.5f,0);
        playerRB.AddForce(focalPoint.transform.forward * forwardIput * moveSpeed);
    }

    IEnumerator PowerupTimerRoutine()
    {
        yield return new WaitForSeconds(8);
        isPowerupActive = false;
       powerupIndicator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            isPowerupActive = true;
            StartCoroutine(PowerupTimerRoutine());
            powerupIndicator.gameObject.SetActive(true);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPowerupActive)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushEnemyDir = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(pushEnemyDir * pushStrentgh, ForceMode.Impulse);
        }
    }
}