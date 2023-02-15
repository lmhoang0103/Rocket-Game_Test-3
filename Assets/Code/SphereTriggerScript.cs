using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTriggerScript : MonoBehaviour
{
    public logicScript logic;
    public SnakeController snake;
    public GameObject redSpherePrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeController>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void changeMat()
    {
        snake.changeMaterial();
    }

    private void OnTriggerEnter(Collider other)

    {
        Material material = GetComponent<Renderer>().material;
        Material otherMaterial = other.GetComponent<Renderer>().material;
        if (other.gameObject.layer == 3 && material.color == otherMaterial.color
            )
        {
            logic.addScore();
            Destroy(gameObject);
            SpawnSphere(redSpherePrefab);
            changeMat();
        }
        else if (other.gameObject.layer == 3)
        {
            snake.stopMoving();
            logic.gameOver();
        }
    }

    private void SpawnSphere(GameObject prefab)
    {
        // Get the position of the spawner
        Vector3 spawnerPos = transform.position;

        float radius = 0.2f;

        // Spawn the object with the same Y position as the spawner, but at a random XZ position
        Vector3 spawnPos = new Vector3(Random.Range(-8.5f, 8.5f), spawnerPos.y, Random.Range(-8.5f, 8.5f));

        // Check for any overlapping colliders within the radius around the spawn position
        Collider[] colliders = Physics.OverlapSphere(spawnPos, radius);
        while (colliders.Length > 0)
        {
            // Adjust the spawn position and check again if there are any overlapping colliders
            spawnPos = new Vector3(Random.Range(-8.5f, 8.5f), spawnerPos.y, Random.Range(-8.5f, 8.5f));
            colliders = Physics.OverlapSphere(spawnPos, radius);
        }

        GameObject newSphere = Instantiate(prefab, spawnPos, Quaternion.identity);
        newSphere.GetComponent<SphereTriggerScript>().redSpherePrefab = prefab;
    }

    private IEnumerator SpawnSphereAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnSphere(redSpherePrefab);
    }
}