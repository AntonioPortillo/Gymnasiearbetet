using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign1
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    private bool isMoving;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTIme;
    private float waitTimeSeconds;
    
    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTIme);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    
    void Update()
    {
        
        if(isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds<=0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime); 
                isMoving = false;
             
            }
            if (!playerInRange)
            {
                Move();
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <=0)
            {
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTIme);
            }
        }
    }

    private void ChooseDifferentDirection() // metod för att sätta ihop switchen, move() och UpdateAnimation().
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move() //rörelsescriptet
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {

            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }  
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4); //switchen används för att skapa de 4 olika alternativ som npc kan röra sig
        switch(direction)
        {
            case 0:
                
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }
    void UpdateAnimation() //animation för respektive rörelse
    {
        anim.SetFloat("Horizontal", directionVector.x);
        anim.SetFloat("Vertical", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    ChooseDifferentDirection();
    }
}
