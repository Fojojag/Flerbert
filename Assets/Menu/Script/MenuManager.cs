using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject firstSelectedButton; 

    private void OnEnable()
    {
       
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }
}
