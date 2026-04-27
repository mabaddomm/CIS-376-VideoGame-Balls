using UnityEngine;

public class CanonBallController : MonoBehaviour


{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float time = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // Debug.Log("Hit player!");
            // Apply damage here
        }

        Destroy(gameObject);
    }
}
