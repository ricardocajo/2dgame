using UnityEngine;
public class EnemyType1 : Enemy
{
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        current_hp = 100f;
        max_hp = 100f;
        knockbackForce = 200f;
        contactDamage = 5f;
    }
}
