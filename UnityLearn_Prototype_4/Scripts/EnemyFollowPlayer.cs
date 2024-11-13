using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    [SerializeField] private float followSpeed;
    private GameObject playerGameobject;
    private Rigidbody enemyRB;
    


    // Start is called before the first frame update
    void Start()
    {
        playerGameobject = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followDirection = (playerGameobject.transform.position - transform.position).normalized;
        enemyRB.AddForce(followDirection * followSpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
