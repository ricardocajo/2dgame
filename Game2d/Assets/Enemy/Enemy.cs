using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float damage_value = 20f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameEvents.Instance.SetEnemyInContactPosition(transform.position);
        GameEvents.Instance.SetDamageValue(damage_value);
        GameEvents.Instance.EnemyContactTriggerEnter();
    }

}
