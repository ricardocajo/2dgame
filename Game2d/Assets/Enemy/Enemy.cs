using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Declare protected abstract properties
    protected abstract float ContactDamage { get; }
    protected abstract float KnockbackForce { get; }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        GameEvents.Instance.SetEnemyInContactPosition(transform.position);
        GameEvents.Instance.SetPlayerIncDamageValue(ContactDamage);
        GameEvents.Instance.SetEnemyKnockBackForce(KnockbackForce);
        GameEvents.Instance.EnemyContactTriggerEnter();
    }
}

