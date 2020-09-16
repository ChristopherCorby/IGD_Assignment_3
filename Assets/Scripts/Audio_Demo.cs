using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Demo : MonoBehaviour
{
    public AudioClip bgm_main;
    public AudioSource audio_src;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        audio_src.Play();
        yield return new WaitForSeconds(audio_src.clip.length);
        audio_src.clip = bgm_main;
        audio_src.Play();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
