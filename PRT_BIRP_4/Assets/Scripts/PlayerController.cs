using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float strenght = 30f;
    private float powerupstrenght = 40f;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody sphereRb;
    private GameObject focalPoint;
    public bool powerIndicator = false;
    public GameObject powerIndicatorObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        powerIndicatorObj.transform.position = transform.position + new Vector3(0, 1.167f, 0);
    }

    private void ControlPlayer()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        sphereRb.AddForce(Vector3.forward * (Time.deltaTime * strenght * verticalInput));
        sphereRb.AddForce(Vector3.right * (Time.deltaTime * strenght * horizontalInput));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerIndicator = true;
            powerIndicatorObj.SetActive(true);
            StartCoroutine(PowerupTimerIndicator());
        }
    }

    IEnumerator PowerupTimerIndicator()
    {
        yield return new WaitForSeconds(5);
        powerIndicator = false;
        powerIndicatorObj.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyTag") && powerIndicator)
        {
            
            Rigidbody EnemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - transform.position;
            EnemyRb.AddForce(awayFromPlayer * powerupstrenght, ForceMode.Impulse);
        }
    }
}   