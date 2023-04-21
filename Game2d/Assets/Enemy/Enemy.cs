using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Declare protected abstract properties
    protected float contactDamage;
    protected float knockbackForce;
    protected float current_hp;
    protected float max_hp;
    protected Animator animator;
    protected int exp_value;

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
            animator.SetBool("Die", true);
            //Destroy(gameObject);   Maybe jsut leave it there but somehow clean it after?
            Destroy(GetComponent<Collider2D>());
            if(exp_value > 0) {
                Player.ReceiveExperience(exp_value);
            }
        }
    }
}
