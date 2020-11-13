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

    public UnityEvent OnTankChanged = new UnityEvent();
}
