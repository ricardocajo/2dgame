using UnityEngine;
public class EnemyPlatform : Enemy
{
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        current_hp = 100f;
        max_hp = 100f;
        knockbackForce = 450f;
        contactDamage = 20f;
    }
}
