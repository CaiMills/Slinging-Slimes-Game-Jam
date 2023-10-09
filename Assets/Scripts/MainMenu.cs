using UnityEngine.SceneManagement;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GeneralSoundController soundController;

    public AudioClip menuClick;
    public AudioClip menuMusic;
    public AudioSource source;
    private void Start()
    {
        source.PlayOneShot(menuMusic);
    }

    public void PlayGame()
    {
        source.PlayOneShot(menuClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next level in order
    }

    public void QuitGame()
    {
        source.PlayOneShot(menuClick);
        Application.Quit();
    }
}
