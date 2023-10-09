using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    public GameObject Player;
    //public Transform respawnPoint;
    public GameObject GameOverScreen;
    public GameObject TutorialText;

    GeneralSoundController soundController;

    public AudioClip slimeDeathSound;
    public AudioSource source;

    private void Start()
    {
        soundController = GetComponent<GeneralSoundController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            GameOverScreen.SetActive(true); // activates the game over screen
            Time.timeScale = 0;
            TutorialText.SetActive(false);


            source.PlayOneShot(slimeDeathSound);

            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(currentScene.name); // resets the entire level after death
            //Player.transform.position = respawnPoint.position; //respawns player to a specific point
        }
    }
}
