using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    private float topZRange = 15;
    private float bottomZRange = -1;
    
    public GameObject projectilePrefab;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        if (transform.position.z < bottomZRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomZRange);
        if (transform.position.z > topZRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, topZRange);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pearPos = transform.position;
            pearPos.y = 1.3f;
            pearPos.z = transform.position.z + 0.7f;
            Instantiate(projectilePrefab, pearPos, projectilePrefab.transform.rotation);
        }
    }
}
