using UnityEngine;

public class tentaculo : MonoBehaviour
{
    public AudioClip tentaSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playsound()
    {
        AudioSource.PlayClipAtPoint(tentaSFX, transform.position, 1);
    }
}
