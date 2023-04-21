using UnityEngine;
public class EnemyPlatform : Enemy
{
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        current_hp = 100f;
        max_hp = 100f;
        knockbackForce = 450f;
        contactDamage = 20f;
        exp_value = 0;
    }
}
