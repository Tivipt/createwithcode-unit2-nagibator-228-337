using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound){
            Destroy(gameObject); 
        }
        else if (transform.position.z < lowerBound){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("IgnoreDestroy")) return;
        Destroy(gameObject);
    }
}
