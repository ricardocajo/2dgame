using UnityEngine;

public class Player : MonoBehaviour {
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    private float hp = 100f;
    private float mana = 100f;
    private Rigidbody2D rb;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            //Check DontDestroyOnLoad if want to persist across scenes
            //DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        GameEvents.Instance.onEnemyContactTriggerEnter += EnemyContact;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void EnemyContact()
    {
        DoDamageToPlayer();
        PlayerMovement.Instance.DoKnockback();
    }

    private void DoDamageToPlayer()
     {
        hp -= GameEvents.Instance.GetDamageValue();
        GameEvents.Instance.PlayerHpLost();
        CheckIfPlayerDead();
     }

     private void CheckIfPlayerDead()
     {
        if(hp <= 0f)
        {
            Debug.Log("Player Dead");
        }
     }
}
