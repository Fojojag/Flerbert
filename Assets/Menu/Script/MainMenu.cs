using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool port;
    public void PlayGame()
    {
        if (port)
        {
                SceneManager.LoadSceneAsync(3);
        }
        else
                SceneManager.LoadSceneAsync(4);

    }
    public void Fase1()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void Boss1()
    {
        SceneManager.LoadSceneAsync(8);
    }
    public void Fase2()
    {
        SceneManager.LoadSceneAsync(10);
    }
    public void Boss2()
    {
        SceneManager.LoadSceneAsync(11);
    }
    public void LastBoss()
    {
        SceneManager.LoadSceneAsync(12);
    }
    public void MenuPortugues()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void MenuIngles()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
