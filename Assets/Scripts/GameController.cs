using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }

    public UIManager ui;
    public GameData gameData;

    private void Start()
    {
        gameData.player.Tank = FindObjectOfType<Tank>();

        ui.playerInfoPanel.UpdateView();
        gameData.player.OnTankChanged.AddListener(ui.playerInfoPanel.UpdateView);
    }
}