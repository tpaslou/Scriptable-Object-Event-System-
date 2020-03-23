using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // public variables
    public float secondsBetweenSpawning = 1.0f;
    public float xMinRange = -5.0f;
    public float xMaxRange = 0f;
    public float yMinRange = 1f;
    public float yMaxRange = 2;
    public float zMinRange = -4.7f;
    public float zMaxRange = 4.7f;
    public GameObject[] spawnObjects; // what prefabs to spawn

    private float nextSpawnTime;
    public AudioClip spawnSFX;

    // Use this for initialization
    void Start ()
    {
        // determine when to spawn the next object
        nextSpawnTime = Time.time+secondsBetweenSpawning;
    }
	
    // Update is called once per frame
    void Update ()
    {
     

        // if time to spawn a new game object
        if (Time.time  >= nextSpawnTime) {
            // Spawn the game object through function below
            MakeThingToSpawn ();

            // determine the next time to spawn the object
            nextSpawnTime = Time.time+secondsBetweenSpawning;
        }	
    }

    void MakeThingToSpawn ()
    {
        Vector3 spawnPosition;

        // get a random position between the specified ranges
        spawnPosition.x = Random.Range (xMinRange, xMaxRange);
        spawnPosition.y = Random.Range (yMinRange, yMaxRange);
        spawnPosition.z = Random.Range (zMinRange, zMaxRange);

        // determine which object to spawn
        int objectToSpawn = Random.Range (0, spawnObjects.Length);

        // actually spawn the game object
        GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
        
        if (spawnSFX)
        {
            if (spawnedObject.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
                // play the sound clip through the AudioSource component on the gameobject.
                // note: The audio will travel with the gameobject.
                spawnedObject.GetComponent<AudioSource> ().PlayOneShot (spawnSFX);
            } else {
                // dynamically create a new gameObject with an AudioSource
                // this automatically destroys itself once the audio is done
                AudioSource.PlayClipAtPoint (spawnSFX, spawnedObject.transform.position);
            }
        }
        
    }
}