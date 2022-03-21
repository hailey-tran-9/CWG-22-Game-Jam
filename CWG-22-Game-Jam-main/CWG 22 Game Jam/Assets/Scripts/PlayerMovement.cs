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
    float swingspeed = 0;
  float swingTimer;
  bool isSwinging;
  #endregion

  #region SFX
  public AudioSource netSoundSource;
  public AudioSource footstepsSource;
  public AudioClip netSound;
  public AudioClip footstepSounds;
  public AudioClip music;
  public AudioSource musicSource;
  #endregion

    private void Awake() {

        PlayerRB = GetComponent<Rigidbody2D>();

        netSoundSource = gameObject.AddComponent<AudioSource>();
        netSoundSource.clip = netSound;
        netSoundSource.volume = 0.4f;

        footstepsSource = gameObject.AddComponent<AudioSource>();
        footstepsSource.clip = footstepSounds;
        footstepsSource.volume = 0.1f;
  
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.volume = 0.1f;
        musicSource.Play();
        musicSource.loop = true; 
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            netSoundSource.Play();
            Debug.DrawLine(PlayerRB.position, PlayerRB.position + currDirection);
            RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position, new Vector2(2f, 2f), 0f, Vector2.zero, 0f);
            //Debug.DrawLine(PlayerRB.position, PlayerRB.position + currDirection);
            //Debug.Log(PlayerRB.position + " " + PlayerRB.position + currDirection);
            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log(hit.transform.tag);
                if(hit.transform.CompareTag("Enemy")) {
                  Debug.Log("identifying Enemy");
                    Destroy(hit.collider.gameObject);
                }

            }

        } 

    }

      private void Move()
  {
    if(x_input > 0){
      if (!footstepsSource.isPlaying) {
          footstepsSource.Play();
        }
      PlayerRB.velocity = Vector2.right * movespeed;
      currDirection = Vector2.right;
    } else if (x_input < 0) {
        if (!footstepsSource.isPlaying) {
          footstepsSource.Play();
        }
      PlayerRB.velocity = Vector2.left * movespeed;
      currDirection = Vector2.left;
    } else if (y_input > 0){
        if (!footstepsSource.isPlaying) {
          footstepsSource.Play();
        }
      PlayerRB.velocity = Vector2.up * movespeed;
      currDirection = Vector2.up;

    } else if (y_input < 0) {
        if (!footstepsSource.isPlaying) {
          footstepsSource.Play();
        }
      PlayerRB.velocity = Vector2.down * movespeed;
      currDirection = Vector2.down;
    } else {
      footstepsSource.Stop();
      PlayerRB.velocity = Vector2.zero;

    }

  }

  // private void Swing() {
  //       swingTimer = swingspeed;  
  //       SwingHelper();
  // }

  //   private void SwingHelper() {
  //     Debug.Log("Running SwingRoutine " + currDirection);
  //   isSwinging = true;
  //   PlayerRB.velocity = Vector2.zero;
  //   //inputs ( origin , size , angle , direction, distance)
  //   RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + currDirection, new Vector2(1f, 40), 0f, Vector2.zero, 0f);
  //   Debug.DrawLine(PlayerRB.position, PlayerRB.position + new Vector2(1f, 40));
  //    //Debug.Log(PlayerRB.position + " " + PlayerRB.position + currDirection);
  //   foreach (RaycastHit2D hit in hits)
  //   {
  //       Debug.Log(hit.transform.tag);
  //       if(hit.transform.CompareTag("Enemy")) {
  //         Debug.Log("identifying Enemy");
  //           Destroy(hit.collider.gameObject);
  //           //the inside works, but it's not raycasting and hitting an enemy
  //       //score goes up??
  //       //just destroy enemy?
  //       //run poof animation?

  //       }
  //       else
  //       {
  //           //the case when you capture a good dream
  //       }
  //   }
  //   isSwinging = false;
  //   return;
  //   }

  void OnTriggerEnter2D(Collider2D other) {
        // Applies the buff/debuff onto the player for 5 seconds
        // and removes the object from the game screen
        Object obj = other.GetComponent<Object>();
        if (obj != null) {
          Debug.Log("Picked up an object!");
          string type = obj.type;

          // Apply buff/debuff
          if (type == "buff") {
              Debug.Log("prev speed: " + movespeed);
              StartCoroutine(SpeedUp());
              Debug.Log("curr speed: " + movespeed);
          } else {
              Debug.Log("prev speed: " + movespeed);
              StartCoroutine(Slow());
              Debug.Log("curr speed: " + movespeed);
          }

          // Remove object
          Destroy(other.gameObject);
        }
    }

    private IEnumerator Slow() {
        // Decreases the player speed
        movespeed *= (float) .75;
        yield return new WaitForSeconds(5f);
        movespeed *= (float) 1.25;
        Debug.Log("effects wore off!");
    }

    private IEnumerator SpeedUp() {
        // Increases the player speed
        movespeed *= (float) 1.25;
        yield return new WaitForSeconds(5f);
        movespeed *= (float) .75;
        Debug.Log("effects wore off!");
    }
}
