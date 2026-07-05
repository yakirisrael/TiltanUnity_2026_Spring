using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;

    public float speed = 10f;

    private float CamZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CamZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, CamZ);
    }
}
