using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour
{
    public Tank Tank;

    public float Health = 100;
    public float Armor => Tank?.Armor ?? 0;
    public float Speed => Tank?.moveSpeed * 10 ?? 0;
    public float Damage => Tank?.ProjectilePrefab.Damage ?? 0;

    public bool IsDead => Health <= 0;

    public UnityEvent OnTankChanged = new UnityEvent();
    public AttackEvent OnAttacked = new AttackEvent();
    public UnityEvent OnKilled = new UnityEvent();

    private void Start()
    {
        OnAttacked.AddListener(AttackedHandeler);
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
            OnKilled?.Invoke();
        }
    }
}
