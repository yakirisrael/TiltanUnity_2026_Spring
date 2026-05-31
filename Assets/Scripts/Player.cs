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

    void MoveCharacter(int horizonal, int vertical)
    {
        if (horizonal == 0 && vertical == 0) return;

        if (horizonal > 0)
            transform.Translate(Vector3.right * xStep * speed * Time.deltaTime);

        if (horizonal < 0)
            transform.Translate(Vector3.left * xStep * speed * Time.deltaTime);
        
        if (vertical > 0)
            transform.Translate(Vector3.up * xStep * speed * Time.deltaTime);

        if (vertical < 0)
            transform.Translate(Vector3.down * xStep * speed * Time.deltaTime);
    }


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
        
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;

        // sr.color = Color.blueViolet;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
      //  Debug.Log(Mouse.current.position.ReadValue());

        Debug.Log( Mouse.current.scroll.ReadValue())
            ;
       /* if (Mouse.current.scroll.ReadValue().y > 0)
            Debug.Log("Scroll up");
        
        if (Mouse.current.scroll.ReadValue().y < 0)
            Debug.Log("Scroll down");
        */
       
       //transform.eulerAngles = new Vector3(0,0, 90);
       
        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("D");
            MoveCharacter(1, 0);
            FlipCharacter(false);
            
            animator.Play("PlayerWalk");
          //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("A");
          //  transform.Translate(-xStep * speed * Time.deltaTime, 0,0);
            MoveCharacter(-1, 0);
            FlipCharacter(true);

            
            animator.Play("PlayerWalk");
        }
        
        if (Keyboard.current.wKey.isPressed)
        {
            
            Debug.Log("W");

            MoveCharacter(0, 1);
            animator.Play("PlayerWalk");
            //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            
            Debug.Log("S");

            MoveCharacter(0, -1);
            animator.Play("PlayerWalk");
            //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }

       // transform.Rotate(new Vector3(0, 0, 1), rotateAngle);
        
       
    }
}
