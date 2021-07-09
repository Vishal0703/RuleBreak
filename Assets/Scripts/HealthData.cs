using UnityEngine;

[CreateAssetMenu(fileName = "Health Data", menuName = "New Health Data")]
public class HealthData : ScriptableObject
{
    public float maxHealth;
    public float damageAmount;
}
