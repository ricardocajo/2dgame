using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Declare protected abstract properties
    protected float contactDamage;
    protected float knockbackForce;
    protected float current_hp;
    protected float max_hp;
    protected Animator animator;
    protected Rigidbody2D rb;

    public virtual void OnCollisionEnter2D(Collision2D other) {
        GameEvents.Instance.SetEnemyInContactPosition(transform.position);
        GameEvents.Instance.SetPlayerIncDamageValue(contactDamage);
        GameEvents.Instance.SetEnemyKnockBackForce(knockbackForce);
        GameEvents.Instance.EnemyContactTriggerEnter();
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        DoDamageToEnemy(other.name);
    }

    private void DoDamageToEnemy(string move) {
        current_hp -= Player.GetOutputDamage(move);
        CheckIfEnemyDead();
    }

    private void CheckIfEnemyDead() {   
        if(current_hp <= 0f) {
            Debug.Log("Enemy dead");
            //animator.SetBool("Die", true);
            // TODO die process
        }
    }
}
