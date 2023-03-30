using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    private float hp = 100f;
    private float mana = 100f;
    private Rigidbody2D rb;
    List<string> player_skills = new List<string>()
                    {
                        "skill1",
                        "skill2",
                        "skill3",
                        "skill4",
                        "skill5"                    
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

    public void UseSkill_1()
    {
        UseSkill(skills[player_skills[0]]);
    }

    public void UseSkill_2()
    {
        UseSkill(skills[player_skills[1]]);
    }

    public void UseSkill_3()
    {
        UseSkill(skills[player_skills[2]]);
    }

    public void UseSkill_4()
    {
        UseSkill(skills[player_skills[3]]);
    }

    public void UseSkill_5()
    {
        UseSkill(skills[player_skills[4]]);
    }

    public void UseSkill(Dictionary<string,float> skill_properties)
    { 
        skill_properties.TryGetValue("mana", out float mana_cost);
        GameEvents.Instance.SetManaValue(mana_cost);
        GameEvents.Instance.PlayerManaLost();
    }

    //Skill name -> Skill properties
    private static Dictionary<string, Dictionary<string,float>> skills = new Dictionary<string, Dictionary<string,float>>
    {
    {"skill1", new Dictionary<string, float>{
        {"damage", 10f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill2", new Dictionary<string, float>{
        {"damage", 20f},
        {"mana", 20f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill3", new Dictionary<string, float>{
        {"damage", 30f},
        {"mana", 30f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill4", new Dictionary<string, float>{
        {"damage", 40f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill5", new Dictionary<string, float>{
        {"damage", 0f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }},
    {"skill6", new Dictionary<string, float>{
        {"damage", 50f},
        {"mana", 10f},
        {"movement", 10f},
        {"selfdamage", 10f},
        {"buff", 10f}
    }}
    };
}
