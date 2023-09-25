using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public GameObject endingScenePanel, endingScene1, endingScene2, endingScene3;

    void Start()
    {
        StartCoroutine(EndingScene());
    }

    internal void Deactive()
    {
        endingScenePanel.SetActive(true);
        endingScene1.SetActive(false);
        endingScene2.SetActive(false);
        endingScene3.SetActive(false);
    }

    IEnumerator EndingScene()
    {
        Deactive();
        yield return new WaitForSeconds(3f);
        endingScene1.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingScene1.SetActive(false);
        endingScene2.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingScene2.SetActive(false);
        endingScene3.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingScene3.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credit Scene");
    }
}
