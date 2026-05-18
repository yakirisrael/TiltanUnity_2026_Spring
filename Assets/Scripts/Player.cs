using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public float xStep = 1.0f;
    public float yStep = 1.0f;

    public float speed = 5.0f;
    
    public float rotateAngle = 1.0f;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Triangle Start");
        
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.blueViolet;
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
            
          //  transform.Translate(xStep * speed * Time.deltaTime, 0,0);
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("A");
          //  transform.Translate(-xStep * speed * Time.deltaTime, 0,0);
            transform.Translate(Vector3.left * xStep * speed * Time.deltaTime);
        }

       // transform.Rotate(new Vector3(0, 0, 1), rotateAngle);
        
       
    }
}
