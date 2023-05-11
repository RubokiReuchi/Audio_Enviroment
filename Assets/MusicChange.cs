using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    float fade_in = 0.5f;
    float fade_out = 0.0f;

    bool to_base;

    public AudioSource base_music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fade_out >0.0f)
        {
            fade_out = fade_out - Time.deltaTime;

            GetComponent<AudioSource>().volume = fade_out*2f;
            base_music.volume = fade_out*2f;

            if (fade_out <= 0.0f)
            {
               
                fade_in = 0.0f;

                if(to_base)
                {
                    GetComponent<AudioSource>().Stop();
                    base_music.Play();
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    base_music.Stop();
                }
            }
        }

        if (fade_in < 0.5f)
        {
            fade_in = fade_in + Time.deltaTime;

            if(fade_in >0.5f)
            {
                fade_in = 0.5f;
            }

            GetComponent<AudioSource>().volume = fade_in * 2f;
            base_music.volume = fade_in * 2f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            fade_out = 0.5f;
            to_base = false;
        }
       

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            fade_out = 0.5f;
            to_base = true;
        }


    }
}
