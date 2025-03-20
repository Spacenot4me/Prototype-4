using UnityEngine;

public class RotateCameraScript : MonoBehaviour
{
    public float rotateSpeed = 1f;
    private float inputHorizontal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.down, inputHorizontal * rotateSpeed * Time.deltaTime);


    }
}
