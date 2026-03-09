using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Takip Ayarları")]
    public Transform playerHole; 
    public float smoothSpeed = 5f; 

    [Header("Kamera Uzaklık (Zoom) Ayarları")]
    [Tooltip("Kamera ilk halinin maksimum kaç katı uzaklaşabilir? (Örn: 2.5)")]
    public float maxZoomMultiplier = 2.5f; 

    private Vector3 startOffset;

    void Start()
    {
   
        if (playerHole != null)
        {
            startOffset = transform.position - playerHole.position;
        }
    }

    void LateUpdate() 
    {
        if (playerHole == null) return;
        float sizeFactor = Mathf.Sqrt(playerHole.localScale.x);
        sizeFactor = Mathf.Clamp(sizeFactor, 1f, maxZoomMultiplier);

        Vector3 targetOffset = startOffset * sizeFactor;
        Vector3 targetPosition = playerHole.position + targetOffset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
    }
}