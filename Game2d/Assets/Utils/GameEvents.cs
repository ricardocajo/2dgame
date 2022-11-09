using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    private static GameEvents _instance;

    public static GameEvents Instance { get { return _instance; } }


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

    private Vector3 enemy_in_contact_position;
    public event Action onEnemyContactTriggerEnter;
    public void EnemyContactTriggerEnter()
    {
        if(onEnemyContactTriggerEnter != null)
        {
            onEnemyContactTriggerEnter();
        }
    }

    public Vector3 GetEnemyInContactPosition()
    {
        return enemy_in_contact_position;
    }

    public void SetEnemyInContactPosition(Vector3 enemy_position)
    {
        enemy_in_contact_position = enemy_position;
    }


    //lock mechanism for this?
    private float player_damage_value;
    public event Action onPlayerHpLost;
    public void PlayerHpLost()
    {
        if(onPlayerHpLost != null)
        {
            onPlayerHpLost();
        }
    }

    public float GetPlayerIncDamageValue()
    {
        return player_damage_value;
    }

    public void SetPlayerIncDamageValue(float damage)
    {
        player_damage_value = damage;
    }


    private float enemy_damage_value;
    public event Action onEnemyHpLost;
    public void EnemyHpLost()
    {
        if(onEnemyHpLost != null)
        {
            onEnemyHpLost();
        }
    }

    public float GetEnemyIncDamageValue()
    {
        return enemy_damage_value;
    }

    public void SetEnemyIncDamageValue(float damage)
    {
        enemy_damage_value = damage;
    }


    private float mana_value;
    public event Action onPlayerManaLost;
    public void PlayerManaLost()
    {
        if(onPlayerManaLost != null)
        {
            onPlayerManaLost();
        }
    }

    public float GetManaValue()
    {
        return mana_value;
    }

    public void SetManaValue(float mana)
    {
        mana_value = mana;
    }
}
