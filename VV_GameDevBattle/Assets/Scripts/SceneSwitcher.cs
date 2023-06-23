using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadStart(float delay)
    {
        StartCoroutine(_DelayLoadScene(0, delay));
    }

    private IEnumerator _DelayLoadScene(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(index);
        yield return null;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
