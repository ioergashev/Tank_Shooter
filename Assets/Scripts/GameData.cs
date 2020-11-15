using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct AttackEventArgs
{
    public float Damage;
}
public class AttackEvent : UnityEvent<AttackEventArgs> { }

public class GameData : MonoBehaviour
{
    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameData>();
            return instance;
        }
    }

    public Player player;
    public UnityEvent OnEnemyKilled = new UnityEvent();
}
