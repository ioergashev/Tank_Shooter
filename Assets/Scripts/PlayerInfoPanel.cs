using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanel : MonoBehaviour
{
    public Text HealthText;
    public Text ArmorText;
    public Text SpeedText;

    public void UpdateView()
    {
        HealthText.text = Mathf.CeilToInt(GameData.Instance.player.Health).ToString();
        ArmorText.text = Mathf.CeilToInt(GameData.Instance.player.Armor).ToString();
        SpeedText.text = Mathf.CeilToInt(GameData.Instance.player.Speed).ToString();
    }
}
