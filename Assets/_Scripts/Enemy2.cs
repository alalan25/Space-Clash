using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 12f; //speed of the enemy

    public float health = 10; // health of the enemy
    public int score = 100; // points eaarned for destroying this enemy
    public int randNum; // initiating an integer type varibale
    private BoundsCheck bndCheck;

   void Start()
    {
        randNum = Random.Range(1, 3); // randNum will randomly stroe either 1 or 2 based on which enenmy2 will 
        //diagonally move either from left or right
    }





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

        if ((bndCheck != null && bndCheck.offDown)||(bndCheck.offLeft)) //checks if the enemy is offScreen from either left, right or down then destroy it
        {
            //To check if it is on the screen or no
            // The enemy is off the screen, so destroy it
            Destroy(gameObject);

        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;  // allows the enemy move down smoothly


        // this additional scripting component will make it move diagonally

     

        if (randNum == 1)
        {
            tempPos.x += speed * Time.deltaTime; // move at 45 degree to the right
        }
        else
            tempPos.x -= speed * Time.deltaTime; // this will make it move to the left


        pos = tempPos;




























    }


}
