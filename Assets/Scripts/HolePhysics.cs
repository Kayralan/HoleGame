using UnityEngine;

public class HolePhysics : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip eatSound;      
    private Vector3 targetScale; 
    private SwallowableObject mySwallowable; 
    private int fallingLayer; 

    void Start()
    {
        targetScale = transform.localScale; 
        mySwallowable = GetComponent<SwallowableObject>();
        fallingLayer = LayerMask.NameToLayer("DusenObje");
        
        if (fallingLayer == -1)
        {
            Debug.LogError("DİKKAT: 'DusenObje' adında bir katman bulunamadı!");
        }
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 5f);

        if (mySwallowable != null)
        {
            // Kendi yutulma eşiğimizi güncel tutuyoruz
            mySwallowable.requiredHoleSize = transform.localScale.x * 1.1f;
            mySwallowable.growthReward = transform.localScale.x * 0.5f;
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
    
            if (transform.localScale.x > other.transform.localScale.x * 1.1f)
            {
                UIManager ui = FindObjectOfType<UIManager>();
                if (ui != null) 
                {
                    ui.GameOver("YUTULDUN!");
                }
            }
            return;
        }

        SwallowableObject swallowable = other.GetComponentInParent<SwallowableObject>();

        if (swallowable != null && transform.localScale.x >= swallowable.requiredHoleSize)
        {
            Rigidbody rb = swallowable.GetComponent<Rigidbody>();
            
            if (audioSource != null && eatSound != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            if (rb != null) 
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                swallowable.transform.position += Vector3.down * 0.1f;
                rb.linearVelocity = new Vector3(0, -25f, 0);
            }

            if (swallowable.GetComponent<HolePhysics>() != null)
            {
                targetScale += new Vector3(swallowable.growthReward, 0f, swallowable.growthReward); 
                Destroy(swallowable.gameObject);
                return; 
            }

            ChangeLayersRecursively(swallowable.transform, fallingLayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SwallowableObject swallowable = other.GetComponentInParent<SwallowableObject>();

        if (swallowable != null)
        {
            if (swallowable.transform.position.y < transform.position.y)
            {
                targetScale += new Vector3(swallowable.growthReward, 0f, swallowable.growthReward); 
                Destroy(swallowable.gameObject);
            }
        }
    }

    private void ChangeLayersRecursively(Transform trans, int layer)
    {
        trans.gameObject.layer = layer;
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, layer);
        }
    }
}