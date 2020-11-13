using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings instance;
    public static GameSettings Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameSettings>();
            return instance;
        }
    }

    public Vector3 WorldSize;
}
