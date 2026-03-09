using UnityEngine;

public class SwallowableObject : MonoBehaviour
{
    [Header("Yutulma Şartları")]
    [Tooltip("Deliğin bu objeyi yutabilmesi için ulaşması gereken minimum boyut (Scale X)")]
    public float requiredHoleSize = 1f; 

    [Tooltip("Bu obje yutulduğunda delik ne kadar büyüyecek? (Büyük objeler daha çok büyütür)")]
    public float growthReward = 0.1f;
}