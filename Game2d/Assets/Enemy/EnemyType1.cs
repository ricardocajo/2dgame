using UnityEngine;
public class EnemyType1 : Enemy
{
    // Implement the protected abstract properties
    protected override float ContactDamage => 5f;
    protected override float KnockbackForce => 200f;
}