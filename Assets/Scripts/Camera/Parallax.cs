using UnityEngine;

public class Parallax : MonoBehaviour
{
    Vector3 prevPos;

    Camera cam;
    public float factor = 1.0f;
    
    Vector3 originalPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;
        prevPos = cam.transform.position;
        
        originalPos  = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaMove = cam.transform.position.x - prevPos.x;
        transform.position += new Vector3(deltaMove * factor, 0 ,0) ;
        prevPos = cam.transform.position;
    }
}
