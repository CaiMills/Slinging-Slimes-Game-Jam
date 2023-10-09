using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(6, tutorialText));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
