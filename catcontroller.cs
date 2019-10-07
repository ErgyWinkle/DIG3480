using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catcontroller : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                musicSource.clip = musicClipOne;
                musicSource.Play();
                anim.SetInteger("state", 1);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                musicSource.Stop();
                anim.SetInteger("state", 0);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                musicSource.clip = musicClipTwo;
                musicSource.Play();
                anim.SetInteger("state", 2);
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                musicSource.Stop();
                anim.SetInteger("state", 0);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                musicSource.loop = true;
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                musicSource.loop = false;
            }

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
}
