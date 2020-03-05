using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public float speed = 30; //the fields that will control the movement of the Hero
    public float rollMult = -45; // defining and initianing attributes of this class
    public float pitchMult = 30;

    private GameObject lastTriggerGo = null; //reference to the last triggering object

    static public Hero S; //creating a singleton


    private void Awake()
    {
        if (S == null)
        {
            S = this; // setting it to the singleton
        }
        else
        {
            Debug.LogError("Hero.Awake()-Attempted to assign second Hero.S!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Pulling info from the Input Class
        float xAxis = Input.GetAxis("Horizontal"); // making the player move horizontally
        float yAxis = Input.GetAxis("Vertical"); // making player move vertically

        // Change position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotating the shipt to give it the dynamic effect
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;  //getting the root name of the colliding object
        GameObject go = rootT.gameObject;
        print("Triggered: " + go.name);

        //making sure that the same object is not triggered again
        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy1") // if the enemy with tag Enemy1 collides with gameObject Hero then destroy both
        {
            
         Destroy(go); // we also destroy the enemy on collision
         Destroy(gameObject); // destroy the Hero ship
        }
        else if (go.tag == "Enemy2")// if the enemy with tag Enemy2 collides with gameObject Hero then destroy both
        {
            
            Destroy(go);// destroy the enemy2
            Destroy(gameObject); // destroy the Hero Ship

        }
        else
        {
            print("Triggered by non-Enemy" + go.name);
        }
    }
}
