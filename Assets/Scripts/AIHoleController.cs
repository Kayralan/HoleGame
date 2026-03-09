using UnityEngine;

public class AIHoleController : MonoBehaviour
{
    [Header("Yapay Zeka Ayarları")]
    [Tooltip("Düşmanın hareket hızı")]
    public float moveSpeed = 4f;
    
    [Tooltip("Düşmanın yiyecek arama yarıçapı")]
    public float searchRadius = 15f; 
    
    private Transform currentTarget;
    private float nextSearchTime = 0f;

    void Update()
    {

        if (Time.time >= nextSearchTime)
        {
            FindClosestFood();
            nextSearchTime = Time.time + 0.5f; 
        }

        MoveTowardsTarget();
    }

    void FindClosestFood()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius);
        float closestDistance = Mathf.Infinity;
        Transform bestTarget = null;
        float mySize = transform.localScale.x;

        foreach (Collider hitCollider in hitColliders)
        {
            SwallowableObject food = hitCollider.GetComponent<SwallowableObject>();

            if (food != null && food.gameObject != this.gameObject && mySize >= food.requiredHoleSize)
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    bestTarget = hitCollider.transform;
                }
            }
        }
        currentTarget = bestTarget;
    }

    void MoveTowardsTarget()
    {
     
        if (currentTarget != null)
        {
     
            Vector3 targetPosition = new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z);
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}