using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject panel;

    public void pauseButton()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resumeButton() 
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
