using UnityEngine;
using System.Collections.Generic;

//TODO make this abstract for different characters?
public class Player : MonoBehaviour {
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    private Equipment equipment;
    private static Experience experience;
    private Stats stats;
    private Inventory inventory;
    private float current_hp = 100f;
    private float max_hp = 100f;
    private float hp_regen = 0.05f;
    private static float current_mana = 100f;
    private float max_mana = 100f;
    private float mana_regen = 0.05f;
    private Rigidbody2D rb;
    private static Animator animator;
    private static List<string> player_buttons = new List<string>()
                    {
                        "attack_1",
                        "roll",
                        "skill_1",
                        "skill_2",
                        "skill_3"                 
                    };

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            //Check DontDestroyOnLoad if want to persist across scenes
            //DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable() {
        GameEvents.Instance.SetPlayerMaxHp(max_hp);
        GameEvents.Instance.SetPlayerMaxMana(max_mana);
    }

    void Start() {
        GameEvents.Instance.onEnemyContactTriggerEnter += EnemyContact;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        // should inventory/stats be initiated here? does it persist between scenes?
        inventory = new Inventory();
        stats = new Stats();
        experience = new Experience();
    }

    private void FixedUpdate() {
        if(current_hp < max_hp) {
            current_hp = Mathf.Min(current_hp + hp_regen, max_hp);
            GameEvents.Instance.SetPlayerHpValue(current_hp);
            GameEvents.Instance.PlayerHpChange();
        }
        if(current_mana < max_mana) {
            current_mana = Mathf.Min(current_mana + mana_regen, max_mana);
            GameEvents.Instance.SetManaValue(current_mana);
            GameEvents.Instance.PlayerManaChange();
        }
    }

    private void EnemyContact() {
        DoDamageToPlayer();
        PlayerMovement.Instance.DoKnockback();

    }

    private void DoDamageToPlayer() {
        current_hp -= GameEvents.Instance.GetPlayerIncDamageValue();
        GameEvents.Instance.PlayerHpLost();
        CheckIfPlayerDead();
    }

    private void CheckIfPlayerDead() {   
        if(current_hp <= 0f) {
            animator.SetBool("Die", true);
            // TODO die process
        }
    }

    public static void UseAttack() {
        UseSkill(player_buttons[0]);
    }
    public static void UseSkill_1() {
        UseSkill(player_buttons[1]);
    }

    public static void UseSkill_2() {
        UseSkill(player_buttons[2]);
    }

    public static void UseSkill_3() {
        UseSkill(player_buttons[3]);
    }

    public static void UseSkill_4() {
        UseSkill(player_buttons[4]);
    }

    private static void UseSkill(string move) { 
        Dictionary<string,float> skill_properties = Skills_list.skills[move];
        skill_properties.TryGetValue("mana", out float mana_cost);
        if(current_mana < mana_cost) {
            Debug.Log("Not enough mana: " + current_mana);
            Debug.Log("mana cost: " + mana_cost);
        }
        else {
            current_mana = Mathf.Max(0, current_mana - mana_cost);
            GameEvents.Instance.SetManaValue(current_mana);
            GameEvents.Instance.PlayerManaChange();
            animator.Play(move);
        }
    }

    public static float GetOutputDamage(string move) {
        Skills_list.skills[move].TryGetValue("damage", out float move_damage);
        //Changes to damage depending on stats
        return move_damage;
    }

    public static void ReceiveExperience(int exp_value) {
        experience.GainExp(exp_value);
    }
}
