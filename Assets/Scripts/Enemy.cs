using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyState
{
    None,
    Chase,
    Attack,
    Dead
}

public class Enemy : MonoBehaviour
{
    public float Health = 50;
    public float Armor = 0;
    public float Damage = 10;
    public float Speed = 5;

    public EnemyState state = EnemyState.Chase;

    public float AttackDistance = 2f;
    public float LastAttackTime;
    public float AttackReloadDuration = 1;

    public AttackEvent OnAttacked = new AttackEvent();
    public UnityEvent OnKilled = new UnityEvent();

    private void Start()
    {
        OnAttacked.AddListener(AttackedHandeler);
        OnKilled.AddListener(KilledHandler);
    }

    private void AttackedHandeler(AttackEventArgs e)
    {
        GetDamage(e.Damage);
    }

    public void GetDamage(float damage)
    {
        if (Health <= 0)
            return;
        Health -= damage * (1 - Armor);
        if (Health <= 0)
        {
            Health = 0;
            Kill();
            OnKilled?.Invoke();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void KilledHandler()
    {
        GameData.Instance.OnEnemyKilled?.Invoke();
    }

    private void Update()
    {
        Vector3 toPlayer = GameData.Instance.player.Tank.transform.position - transform.position;
        if (toPlayer.magnitude <= AttackDistance)
            state = EnemyState.Attack;
        else
            state = EnemyState.Chase;

        switch (state)
        {
            case EnemyState.Chase:
                Vector3 moveOffset = toPlayer.normalized * Time.deltaTime * Speed;
                transform.Translate(moveOffset);
                break;
            case EnemyState.Attack:
                if (Time.time > LastAttackTime + AttackReloadDuration)
                {
                    LastAttackTime = Time.time;
                    GameData.Instance.player.OnAttacked?.Invoke(new AttackEventArgs { Damage = this.Damage });
                }
                break;
        }
    }
}
