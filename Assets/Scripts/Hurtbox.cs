﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject deathEffect;
    [Range(0 ,100)]public float chanceDrop;
    public GameObject collectible;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Enemy"){
            other.transform.parent.gameObject.SetActive(false);
           
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect<=chanceDrop){ 
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }

            AudioManager.instance.PlaySFX(3);

        }
    }


}
