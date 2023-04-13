using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    private Equipment equipment;
    private Experience experience;
    private Stats stats;
    private Inventory inventory;
    private float hp = 100f;
    private static float mana = 100f;
    private Rigidbody2D rb;
    private static List<string> player_skills = new List<string>()
                    {
                        "skill1",
                        "skill2",
                        "skill3",
                        "skill4"                  
                    };

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
        // should inventory/stats be initiated here? does it persist between scenes?
        inventory = new Inventory();
        stats = new Stats();
    }

    private void EnemyContact()
    {
        DoDamageToPlayer();
        PlayerMovement.Instance.DoKnockback();
    }

    private void DoDamageToPlayer()
    {
        hp -= GameEvents.Instance.GetPlayerIncDamageValue();
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

    public static void UseSkill_1()
    {
        UseSkill(Skills_list.skills[player_skills[0]]);
    }

    public static void UseSkill_2()
    {
        UseSkill(Skills_list.skills[player_skills[1]]);
    }

    public static void UseSkill_3()
    {
        UseSkill(Skills_list.skills[player_skills[2]]);
    }

    public static void UseSkill_4()
    {
        UseSkill(Skills_list.skills[player_skills[3]]);
    }

    public static void UseAttack()
    {
        
    }

    private static void UseSkill(Dictionary<string,float> skill_properties)
    { 
        skill_properties.TryGetValue("mana", out float mana_cost);
        if(mana < mana_cost) {
            Debug.Log("Not enough mana: " + mana);
            Debug.Log("mana cost: " + mana_cost);
        }
        else
        {
            mana -= mana_cost;
            GameEvents.Instance.SetManaValue(mana_cost);
            GameEvents.Instance.PlayerManaLost();
        }
    }

}
