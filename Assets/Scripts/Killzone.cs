﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player")
        {   
            AudioManager.instance.PlaySFX(8);
            LevelManager.instance.RespawnPlayer();
        }
    }
}
