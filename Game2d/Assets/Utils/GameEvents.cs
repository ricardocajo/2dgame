using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;
    private static Vector3 enemy_in_contact_position;


    private void Awake()
    {
        current = this;
    }

    public event Action onEnemyContactTriggerEnter;
    public void EnemyContactTriggerEnter()
    {
        if(onEnemyContactTriggerEnter != null)
        {
            onEnemyContactTriggerEnter();
        }
    }

    public static Vector3 GetEnemyInContactPosition()
    {
        return enemy_in_contact_position;
    }

    public static void SetEnemyInContactPosition(Vector3 enemy_position)
    {
        enemy_in_contact_position = enemy_position;
    }

}
