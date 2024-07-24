using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer thSR;
    public Sprite cpOn, cpOff;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            CheckpointController.instance.DeactivatedCheckpoints();
            thSR.sprite = cpOn;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoints(){
        thSR.sprite = cpOff;
    }
}
