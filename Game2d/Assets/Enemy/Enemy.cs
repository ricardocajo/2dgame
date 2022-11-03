using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameEvents.SetEnemyInContactPosition(transform.position);
        GameEvents.Instance.EnemyContactTriggerEnter();
    }

}
