using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelector : MonoBehaviour
{
    public GameObject firstButton;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
