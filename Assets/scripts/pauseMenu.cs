using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
public class pauseMenu : MonoBehaviour

{
    private InputSystem_Actions inputSys;
    private PlayerInput playerInput;
    private InputAction pause;
    public GameObject menu;

    [SerializeField] public static bool paused;
    void Awake()
    {
        inputSys = new InputSystem_Actions();       
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        menu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        playerInput.SwitchCurrentActionMap("UI");
        paused = true;
        
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        playerInput.SwitchCurrentActionMap("Player");
        paused = false;
    }

    private void OnEnable()
    {
       pause = inputSys.Player.Pause;
       pause.Enable();

       pause.performed += Pause; 
    }

    private void OnDisable()
    {
       
       pause.Disable(); 
    }


    void Pause(InputAction.CallbackContext context)
    {
        paused = !paused;
        if (paused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }        
    }
}
