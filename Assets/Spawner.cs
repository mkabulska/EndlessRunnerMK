using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //create a public array of objects to spawn, fill it up with unity editor
    public GameObject[] objectsToSpawn;

    float timeToNextSpwan;                      //Tracks how long we should wait before spawning new object
    float timeSinceLastSpwan = 0.0f;           //Tracks the time since we last spawned something

    public float minSpawnTime = 0.2f;     //Minimum amount of time between spawninng objects
    public float maxSpawntime = 3.0f;     //Maximum amount of time between spawning objects


    void Start()
    {
        //Random.Range generates random float between the values
        timeToNextSpwan = Random.Range(minSpawnTime, maxSpawntime);
    }

    
    void Update()
    {
        //Add Time.DeltaTime returns the amount of time passed since last frame
        //This will creat float that counts up in seconds
        timeSinceLastSpwan = timeSinceLastSpwan + Time.deltaTime;

        //If we've comonted past the amount of time we need to wait...
        if (timeSinceLastSpwan > timeToNextSpwan)
        {
            //use Random.Range to pick num between 0 and amount of objects in list
            int selection = Random.Range(0, objectsToSpawn.Length);

            //Instanciate spawns Game.Object - in case we tell it to spawn a Game.Object from our objectsToSpwan list
            //Second parameter in the brackets tells it where to spawn, so we've entered the position of the spawner
            //Third parameter is for rotation, and Quaternion.identity means no rotation
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            //After spawning, we select a new random time for the next spawn and set our timer back to zero
            timeToNextSpwan = Random.Range(minSpawnTime, maxSpawntime);
            timeSinceLastSpwan = 0.0f;
        }
    }
}
