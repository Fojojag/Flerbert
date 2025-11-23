using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOnStart : MonoBehaviour
{
    public Button firstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }
}
