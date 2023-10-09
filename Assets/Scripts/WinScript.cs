using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    GeneralSoundController soundController;

    public AudioClip winMusic;
    public AudioSource source;
    void Start()
    {
        soundController = GetComponent<GeneralSoundController>();
        source.PlayOneShot(winMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game Close");
        }
    }
}
