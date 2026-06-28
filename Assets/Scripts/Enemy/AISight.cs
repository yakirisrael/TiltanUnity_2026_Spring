using UnityEngine;

public class AISight : MonoBehaviour
{
    public Color lineColor = Color.red;
    
    public float lineDistance = 100.0f;
    
    public LayerMask layerMask;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 origin = transform.position;
        
        ContactFilter2D filter = new ContactFilter2D();
        filter.useLayerMask = true;
        filter.layerMask = layerMask;

        RaycastHit2D[] hitResult = new RaycastHit2D[10];
        
        Physics2D.Raycast(origin, -transform.right, filter, hitResult, lineDistance);
        Debug.DrawRay(origin, -transform.right * lineDistance, lineColor);
        
        for (int i = 0; i < hitResult.Length; i++)
        {
            if (hitResult[i].collider != null && hitResult[i].collider.CompareTag("Player"))
                Debug.Log("hit = " + hitResult[i].collider.name);
        }
    }
}
