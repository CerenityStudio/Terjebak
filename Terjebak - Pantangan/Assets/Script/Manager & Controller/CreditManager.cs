using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    [SerializeField] private float intervalTime;

    private void Start()
    {
        StartCoroutine(Ending());
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Loading Scene");
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(intervalTime);
        SceneManager.LoadScene("Loading Scene");
    }
}
