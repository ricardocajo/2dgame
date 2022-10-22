using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100f;
    private float knockback_force = 10f;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onEnemyContactTriggerEnter += EnemyContact;
    }

    private void EnemyContact()
    {
        DoDamageToPlayer();
        DoKnockback();
        //Debug.Log("Current hp: " + hp);
    }

    private void DoDamageToPlayer()
     {
        hp -= 20;
     }

     private void DoKnockback()
     {
        Vector2 difference = GameEvents.GetEnemyInContactPosition() - transform.position;
        difference = difference.normalized * knockback_force;
        Debug.Log("difference: " + difference);
        gameObject.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
     }

}
