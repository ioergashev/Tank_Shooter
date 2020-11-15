using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPanel : MonoBehaviour
{
    public Text HealthText;
    public Text ArmorText;
    public Text SpeedText;
    public Text DamageText;

    public Enemy Enemy;
    public Player Player;

    private void Start()
    {
        ResetView();
    }

    private void Update()
    {
        if (Player != null)
            UpdatePlayerView();
        else if (Enemy != null)
        {
            UpdateEnemyView();
        }
    }

    public void ResetView()
    {
        UpdateView(0, 0, 0);
    }

    public void UpdatePlayerView()
    {
        UpdateView(Player.Health, Player.Armor, Player.Damage, Player.Speed);
    }

    public void UpdateEnemyView()
    {
        UpdateView(Enemy.Health, Enemy.Armor, Enemy.Damage);
    }

    public void UpdateView(float health, float armor, float damage, float speed = 0)
    {
        if (HealthText != null)
            HealthText.text = Mathf.CeilToInt(health).ToString();
        if (ArmorText != null)
            ArmorText.text = Mathf.RoundToInt(armor).ToString();
        if (SpeedText != null)
            SpeedText.text = Mathf.RoundToInt(speed).ToString();
        if (DamageText != null)
            DamageText.text = Mathf.RoundToInt(damage).ToString();
    }
}
