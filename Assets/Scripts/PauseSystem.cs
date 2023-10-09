using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;

    bool isPaused;
    public GameObject TutorialText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TutorialText.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }

    public bool GetIsPaused() { return isPaused; }
}
