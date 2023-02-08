using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioController : MonoBehaviour
{
    public static AudioClip click, backClick;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        click = Resources.Load<AudioClip>("click");
        backClick = Resources.Load<AudioClip>("backclick");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSound() => audioSrc.PlayOneShot(click);
    public void OnClickBackSound() => audioSrc.PlayOneShot(backClick);

}
