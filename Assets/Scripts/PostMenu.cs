﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para usar SceneManager

public class PostMenu : MonoBehaviour
{

    public static PostMenu instance;
    public string levelSelect, mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Menu")){
            PauseOnpause();
        }
    }

    public void PauseOnpause(){
        if(isPaused){
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }else{
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect(){
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
