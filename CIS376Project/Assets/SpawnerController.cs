using UnityEngine;


public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject chatGPTPrefab;
    [SerializeField] float maxEnemies = 10f;
    [SerializeField] float spawnRate = 2f;
    private float timer = 0f; 
    private float numEnemies = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ( numEnemies < maxEnemies && timer >= spawnRate ) {
            SpawnObject();
            numEnemies++;
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        Instantiate(chatGPTPrefab, transform.position, transform.rotation);
    }
}
