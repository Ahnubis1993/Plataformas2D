﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLenght;
    private float invincibleCounter;
    private SpriteRenderer theSR;
    public GameObject deathEffect;

    public void Awake()
    {
        instance = this;

        theSR = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter<=0){
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {

        if (invincibleCounter <= 0)
        {
            currentHealth--;
            PlayerController.instance.anim.SetTrigger("hurt");

            AudioManager.instance.PlaySFX(9);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                AudioManager.instance.PlaySFX(8);
                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

                
                LevelManager.instance.RespawnPlayer();

            }else{

                invincibleCounter=invincibleLenght; 

                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerController.instance.KnockBack();   
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer(){
        currentHealth++;
        if(currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Platforms"){
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Platforms"){
            transform.parent = null;
        }
    }

}
