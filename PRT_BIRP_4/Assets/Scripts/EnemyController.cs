using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(GetForceVector() * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetForceVector()
    {
        return (player.transform.position - transform.position).normalized;
    }
}