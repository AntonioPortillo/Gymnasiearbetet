using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    //varje public inom klassen är det man sedan kan se i Unity. T.ex public float runSpeed syns i Unity och i unity kan man då redigera hastigheten spelaren ska ha.

    public Rigidbody2D rb;
    public Animator animator;  // public är för att man ska kunna se den på unity. På så sätt kan man t.ex connecta scripts som CharacterController2D med Playermovement
    public float runSpeed ;
    public VectorValue startingPosition;
    public bool canMove;

    Vector2 movement; // vector2 är 2d medan vector3 är 3d. Matematisk model för både direction and magnitude.

    private void Start()
    {
        transform.position = startingPosition.initialValue;
        canMove = true;
    }
    void Update()
    {
        if (canMove) { 
       movement.x = Input.GetAxisRaw("Horizontal"); // A och D Rörelsen
       movement.y = Input.GetAxisRaw("Vertical");   // W och S Rörelsen

       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y); //allt detta är till senare när vi ska fixa animeringen
       animator.SetFloat("Speed", movement.sqrMagnitude);
        }

}

    void FixedUpdate(){
       rb.MovePosition(rb.position + movement *runSpeed * Time.fixedDeltaTime); // För att kunna röra gubben. rb.moveposition är för att röra den tills den krockar på något.  
    }
    
}
