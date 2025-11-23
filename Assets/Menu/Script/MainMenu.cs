using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Fase1()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void Boss1()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void Fase2()
    {
        SceneManager.LoadSceneAsync(8);
    }
    public void Boss2()
    {
        SceneManager.LoadSceneAsync(9);
    }
    public void LastBoss()
    {
        SceneManager.LoadSceneAsync(10);
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
