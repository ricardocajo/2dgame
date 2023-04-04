using UnityEngine;
public class EnemyPlatform : Enemy
{
    // Implement the protected abstract properties
    protected override float ContactDamage => 20f;
    protected override float KnockbackForce => 450f;
}
