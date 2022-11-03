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
}