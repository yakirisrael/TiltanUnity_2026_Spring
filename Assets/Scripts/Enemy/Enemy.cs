using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 10;
    public Vector3 Scale = Vector3.one
        ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        this.transform.localScale = Scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
