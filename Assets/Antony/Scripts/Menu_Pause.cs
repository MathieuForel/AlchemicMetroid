using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pause : MonoBehaviour
{
    public string levelToLoad = "Menu_Principal";

    public void Menu()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public static bool gameIsPaused = false;

    public GameObject Menu_Pause_UI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        Menu_Pause_UI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Menu_Pause_UI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
}
