using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FuelLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] GameObject deerPrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] public float minX = -3.8f;          // Minimum X position
    [SerializeField] public float maxX = 3.8f;           // Maximum X position
    [SerializeField] public float minSeparation = 0.5f; // Minimum separation between the objects on the X-axis
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float despawnTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnProjectile(){
        // Generate a random X position between minX and maxX
        float randomX1 = Random.Range(minX, maxX);

        // Define the spawn position using the random X and fixed Y and Z
        UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(randomX1, 5f, 0f);
        GameObject fuelProjectile = Instantiate(fuelPrefab, spawnPosition, UnityEngine.Quaternion.identity);
        fuelProjectile.GetComponent<Rigidbody2D>().velocity = -transform.up * projectileSpeed;


        // Spawn the second object, ensuring it doesn't overlap with the first object's X position
        float randomX2;
        do
        {
            randomX2 = Random.Range(minX, maxX);
        } while (Mathf.Abs(randomX2 - randomX1) < minSeparation); // Keep randomizing if they are too close

        UnityEngine.Vector3 spawnPosition2 = new UnityEngine.Vector3(randomX2, 4f, 0f);
        GameObject deerProjectile = Instantiate(deerPrefab, spawnPosition2, UnityEngine.Quaternion.identity);
        deerProjectile.GetComponent<Rigidbody2D>().velocity = -transform.up * projectileSpeed;

        Destroy(fuelProjectile,despawnTime);
        Destroy(deerProjectile,despawnTime);
    }

    public void Launch(){
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            while(true){
                // Wait for 2 seconds
                yield return new WaitForSeconds(spawnTime);

                // Spawn Game Object
                SpawnProjectile();
            }
        }
    }

    
}
