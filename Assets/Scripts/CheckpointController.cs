﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint [] checkpoints;
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    public void DeactivatedCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
    {
        checkpoints[i].ResetCheckpoints();
    }
    }

    public void SetSpawnPoint(Vector3 newspawnPoint){
        spawnPoint = newspawnPoint;
    }

}
