using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag==("Player")){
            LevelManager.instance.EndLevel();
        }
    }
}
