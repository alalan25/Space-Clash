using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 15f; //speed of the enemy

    public float health = 10;// health of the enemy
    public int score = 100; // points eaarned for destroying this enemy

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>(); // getting component from boundscheck script
    }

    public Vector3 pos // this is a property: A method that acts like a field
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }



    void Update()
    {
        Move(); // this allows the enemy to keep moving after every frame

        if (bndCheck != null && bndCheck.offDown)
        {
            //To check if it is on the screen or no
            // The enemy is off the screen, so destroy it
            Destroy(gameObject);

        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime; // the enemy will simply move down straight
        pos = tempPos;
    }


}
