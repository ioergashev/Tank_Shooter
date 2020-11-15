using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIManager ui;
    public GameData gameData;

    private void Start()
    {
        gameData.player.Tank = FindObjectOfType<Tank>();
        gameData.player.OnKilled.AddListener(OnPlayerKilled);
    }

    private void OnPlayerKilled()
    {
        ui.GameOverWindow.SetActive(true);
    }

    public void RestartButtonHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
