using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

      #region Movement_variables
    public float movespeed;
    float x_input;
    float y_input;
    #endregion
  Vector2 currDirection;
    
  #region Physics_components
  Rigidbody2D PlayerRB;
  #endregion

  #region Attack_variables
    float swingspeed = 1;
  float swingTimer;
  bool isSwinging;
  #endregion

    private void Awake() {

        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSwinging) {
        return;
        }
        
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();
        if (Input.GetKeyDown(KeyCode.J) && swingTimer<=0)
        {
        Swing();
        } else {
        swingTimer -= Time.deltaTime;
        }

    }

      private void Move()
  {
    
    if(x_input > 0){
      PlayerRB.velocity = Vector2.right * movespeed;
      currDirection = Vector2.right;
    } else if (x_input < 0) {
      PlayerRB.velocity = Vector2.left * movespeed;
      currDirection = Vector2.left;
    } else if (y_input > 0){
      PlayerRB.velocity = Vector2.up * movespeed;
      currDirection = Vector2.up;

    } else if (y_input < 0) {
      PlayerRB.velocity = Vector2.down * movespeed;
      currDirection = Vector2.down;
    } else {
      PlayerRB.velocity = Vector2.zero;

    }



  }

  private void Swing() {
        swingTimer = swingspeed;  
        SwingHelper();
  }

    private void SwingHelper() {
      Debug.Log("Running SwingRoutine " + currDirection);
    isSwinging = true;
    PlayerRB.velocity = Vector2.zero;
    RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + currDirection, new Vector2(0.5f, 0.5f), 0f, Vector2.zero, 0f);
     //Debug.Log(PlayerRB.position + " " + PlayerRB.position + currDirection);
    foreach (RaycastHit2D hit in hits)
    {
        Debug.Log(hit.transform.tag);
        if(hit.transform.CompareTag("Enemy")) {
          Debug.Log("identifying Enemy");
            Destroy(hit.collider.gameObject);
            //the inside works, but it's not raycasting and hitting an enemy
        //score goes up??
        //just destroy enemy?
        //run poof animation?

        }
        else
        {
            //the case when you capture a good dream
        }
    }
    isSwinging = false;
    return;
    }
}
