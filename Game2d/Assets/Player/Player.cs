using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100f;
    private float knockback_force = 4000f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Instance.onEnemyContactTriggerEnter += EnemyContact;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void EnemyContact()
    {
        DoDamageToPlayer();
        DoKnockback();
    }

    private void DoDamageToPlayer()
     {
        hp -= 20;
        //Debug.Log("Current hp: " + hp);
     }

     private void DoKnockback()
     {
        Vector2 difference = transform.position - GameEvents.GetEnemyInContactPosition();
        difference = difference.normalized * knockback_force;

        rb.AddForce(difference, ForceMode2D.Force);
     }

}
