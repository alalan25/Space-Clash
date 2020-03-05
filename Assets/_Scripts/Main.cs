using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;
    public float enemySpawnPerSecond = 3f; // enenemies/second that would be spawned
    public float enemyDefaultPadding = 1.5f; // enemies would be atleast 1.5f apart
    public GameObject[] prefabEnenmies; //creating array of enemy prefabs
   
    private BoundsCheck bndCheck; // initaiting a boundscheck typer variable

    private void Awake()
    {
        S = this; 
        bndCheck = GetComponent<BoundsCheck>(); // getting the component from boundscheck by refering to it

        //invoke enemies every  1/3 seconds based on the default values
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void SpawnEnemy()
    {
        //pick a random enemy prefab to instantiate
        int randEnemy = Random.Range(0, prefabEnenmies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnenmies[randEnemy]); //we are creating an array of enemyPrefabs
        // In this case we are populating the array with two enemy prefabs

        //positioning enenmy
        float enemyPadding = enemyDefaultPadding;

        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius); // if boundscheck is not null then store the radius

        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding; // setting the lower bounds of the range
        float xMax = bndCheck.camWidth - enemyPadding;// setting the upper bound of the range

        pos.x = Random.Range(xMin, xMax); // this allows the enemy to spawn randomly on the specific range of x-axis position
        pos.y = bndCheck.camHeight + enemyPadding; // this allows enemies to spawn 
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); // invoking the enemies every 1/3 seconds
    }
    
}
