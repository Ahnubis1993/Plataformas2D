using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource[] soundsEffetcs;
    
    public AudioSource bgm, levelEndMusic, bossMusic;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay){

        soundsEffetcs[soundToPlay].Stop();

        soundsEffetcs[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundsEffetcs[soundToPlay].Play();

    }


    public void PlayBossMusic()
    {
        bgm.Stop();
        bossMusic.Play();
    }

     public void StopBossMusic()
    {
        bossMusic.Stop();
        bgm.Play();
    }
}
