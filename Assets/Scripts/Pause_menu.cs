using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject pauseMenu,cam;

    private void Start()
    {
    }

    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale =1f;
        IsPaused = false;
        cam.GetComponent<Camera_behaviour>().enabled = true;
        Cursor.visible = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        cam.GetComponent<Camera_behaviour>().enabled = false;
        Cursor.visible = true;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Next Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
