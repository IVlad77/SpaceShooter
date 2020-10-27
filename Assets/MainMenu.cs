﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("GamePlayed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}