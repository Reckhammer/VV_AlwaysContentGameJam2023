using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public Image EndConditionImage;

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetWinScreen()
    {
        headerField.SetText("Paparazi Popped!!!");
    }

    public void SetLoseScreen()
    {
        headerField.text = "You've been Exposed!!!";
        
    }
}
