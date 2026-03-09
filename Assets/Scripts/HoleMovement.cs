using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [Header("Referanslar")]
    [Tooltip("Canvas içindeki Joystick prefab'ını buraya sürükleyin")]
    public Joystick joystick; 

    [Header("Hareket Ayarları")]
    public float moveSpeed = 5f; 
    

    void Update()
    {

        if (joystick == null) return;

        float moveX = -joystick.Horizontal;
        float moveZ = -joystick.Vertical;
        

        if (moveX != 0 || moveZ != 0)
        {

            Vector3 movement = new Vector3(moveX, 0, moveZ);
            Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}