using UnityEngine;
using UnityEngine.InputSystem;

public class pauseMenu : MonoBehaviour

{
    public GameObject menu;

    [SerializeField] public static bool paused;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        AudioListener.pause = true;
        
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        AudioListener.pause = false;
    }
}
