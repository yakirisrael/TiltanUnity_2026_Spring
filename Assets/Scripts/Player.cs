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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Triangle Start");
        
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
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

            transform.Translate(Vector3.right * xStep * speed * Time.deltaTime);
            
            animator.Play("PlayerWalk");
          //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("A");
          //  transform.Translate(-xStep * speed * Time.deltaTime, 0,0);
            transform.Translate(Vector3.left * xStep * speed * Time.deltaTime);
            animator.Play("PlayerWalk");
        }
        
        if (Keyboard.current.wKey.isPressed)
        {
            
            Debug.Log("W");

            transform.Translate(Vector3.up * xStep * speed * Time.deltaTime);
            
            animator.Play("PlayerWalk");
            //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            
            Debug.Log("S");

            transform.Translate(Vector3.down * xStep * speed * Time.deltaTime);
            
            animator.Play("PlayerWalk");
            //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }

       // transform.Rotate(new Vector3(0, 0, 1), rotateAngle);
        
       
    }
}
