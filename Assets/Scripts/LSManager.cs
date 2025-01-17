﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void LoadLevel(){
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo(){
        LSUIManager.instance.FadeToBlack();
        yield return new WaitForSeconds((1f/LSUIManager.instance.fadeSpeed) + .25f);
        SceneManager.LoadScene(player.currentPoint.levelToLoad);
    }
}
