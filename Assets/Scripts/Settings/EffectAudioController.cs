using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioController : MonoBehaviour
{
    public static AudioClip click, backClick, playerDeath, enemyDeath, highScore;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        click = Resources.Load<AudioClip>("click");
        backClick = Resources.Load<AudioClip>("backclick");
        playerDeath = Resources.Load<AudioClip>("playerdeath");
        enemyDeath = Resources.Load<AudioClip>("enemydeath");
        highScore = Resources.Load<AudioClip>("highscore");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "EnemyDeath":
                audioSrc.PlayOneShot(enemyDeath);
                break;
            case "HighScore":
                audioSrc.PlayOneShot(highScore);
                break;
        }
    }

    public void OnClickSound() => audioSrc.PlayOneShot(click);
    public void OnClickBackSound() => audioSrc.PlayOneShot(backClick);

}
