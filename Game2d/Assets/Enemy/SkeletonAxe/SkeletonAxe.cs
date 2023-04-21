using UnityEngine;
public class SkeletonAxe : Enemy
{
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        current_hp = 100f;
        max_hp = 100f;
        knockbackForce = 200f;
        contactDamage = 5f;
        exp_value = 20;
    }
}
