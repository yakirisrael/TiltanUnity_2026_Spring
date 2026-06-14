using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public float xStep = 1.0f;
    public float yStep = 1.0f;

    public float speed = 1.0f;
    
    public float rotateAngle = 1.0f;

    private SpriteRenderer sr;
    
    private Animator animator;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int Horizonal;
    private int vertical;
    
    string punchAnimation = "PlayerPunch";

    public int health = 100;
    
    public int score = 0;
    
    public HUD hud;

    void AddScore(int amount)
    {
        score += amount;
        
        if (hud)
            hud.UpdateScore(score);
    }

    bool IsAnimationFinished(string animationName)
    {
        // get the info of the current runnning animation state
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        
        // if it's not the animation we are looking for, count it as finished
        if (!info.IsName(animationName)) return true;
        
        // check if the current animation is finished (almost)
        if (info.normalizedTime >0.95f) return true;
        
        // animation is still running
        return false;
    }

    // move the character according to:
    // -1 - move left, or down
    // 1 - move right, or up
    void MoveCharacter(int horizonal, int vertical)
    {
        if (horizonal == 0 && vertical == 0)
        {
            animator.SetBool("IsWalking", false);
            
            if (health > 20) animator.SetBool("IsDying", false);
            else animator.SetBool("IsDying", true);
            return;
        }
       
        // WASD pressed, play walk animation
        animator.SetBool("IsWalking", true);
        //animator.Play("PlayerWalk");

        if (horizonal > 0)
            transform.Translate(Vector3.right * xStep * speed * Time.deltaTime);

        if (horizonal < 0)
            transform.Translate(Vector3.left * xStep * speed * Time.deltaTime);
        
        if (vertical > 0)
            transform.Translate(Vector3.up * xStep * speed * Time.deltaTime);

        if (vertical < 0)
            transform.Translate(Vector3.down * xStep * speed * Time.deltaTime);
    }


    // if need to flip change x scale to negative
    void FlipCharacter(bool flip)
    {
        if (flip)
        {
            transform.localScale = new Vector3(
                -originalScale.x,
                originalScale.y,
                originalScale.z);
        }
        else
        {
            transform.localScale = new Vector3(
                originalScale.x,
                originalScale.y,
                originalScale.z);
        }
    }

    void Awake()
    {
        Debug.Log("Triangle Start");
        
        // get all components
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        
        
        // save the original scale of the player
        originalScale = transform.localScale;

        // sr.color = Color.blueViolet;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
      //  Debug.Log(Mouse.current.position.ReadValue());

        Debug.Log( Mouse.current.scroll.ReadValue()) ;
       /* if (Mouse.current.scroll.ReadValue().y > 0)
            Debug.Log("Scroll up");
        
        if (Mouse.current.scroll.ReadValue().y < 0)
            Debug.Log("Scroll down");
        */
       
   

       // check if the mouse left button was pressed in this frame
       if (Mouse.current.leftButton.wasPressedThisFrame)
       {
           AddScore(10);
           // play punch animation
           animator.Play(punchAnimation);
           return;
       }

       //if the punch animation is still running don't do anything
       if (!IsAnimationFinished(punchAnimation)) return;

       // check if WASD was pressed
       bool isWASD_Pressed = false;
       if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("D");
            MoveCharacter(1, 0);
            FlipCharacter(false);
            isWASD_Pressed = true;

            //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            MoveCharacter(-1, 0);
            FlipCharacter(true);
            isWASD_Pressed = true;
        }
        
        if (Keyboard.current.wKey.isPressed)
        {
            MoveCharacter(0, 1);
             isWASD_Pressed = true;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            
            MoveCharacter(0, -1);
            isWASD_Pressed = true;
        }

        if  (!isWASD_Pressed)
            MoveCharacter(0, 0);

        // transform.Rotate(new Vector3(0, 0, 1), rotateAngle);


    }
}
