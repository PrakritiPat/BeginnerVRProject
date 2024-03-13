using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;


    public GameObject[] fruitPrefabs; // an array of the fruits 

    //the timing it range to spawn a new fruit
    public float minSpawnDelay = 5f;
    public float maxSpawnDelay = 7f;


    //the angle of how the fruits spawn
    public float minAngle = -7f;
    public float maxAngle = 7f;



    //how forcefully the fruits spawn into the scene
    public float minForce = 1f;
    public float maxForce = 3f;

    //how long the fruit stays up
    public float maxLifetime = 10f;


    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }


    private void OnEnable()
    {
       StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }


    
    private IEnumerator Spawn()
    {

        yield return new WaitForSeconds(3f); // pauses for before starting 



        while (enabled)
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]; // grabs a random fruit from our fruit prefab array!

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x); //this is giving the fruit a new spot to spawn at, a collider comes with boundaryes, we are considering the entireity of the boundary cuz of the parameters
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            //to rotate we use this, and we use euler rotation because the ones on unity position are euler rotation, we want to base it on the z axis 
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit =  Instantiate(prefab, position, rotation); // this is like a constructor and creates a new fruit to offically spawn 

            Destroy(fruit, maxLifetime); //destory this game object after a spefic  amount of time i nthe second parameter 


            //we need a reference to the fruits rigid body so we can add a force to it
            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse); //(that will point based on the roation, the direction we are going to add our force * our force value, apply as an impulse

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); 

        }
    }

   
}
