using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
[SerializeField] GameObject pauseMenu = null;

bool isPaused;

GeneralSoundController soundController;

public AudioClip menuClickSound;
public AudioSource source;

public GameObject TutorialText;

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        TutorialText.SetActive(false);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
		pauseMenu.SetActive(true);
        source.PlayOneShot(menuClickSound);
    }
}

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        source.PlayOneShot(menuClickSound);

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        source.PlayOneShot(menuClickSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        source.PlayOneShot(menuClickSound);

    }
}
