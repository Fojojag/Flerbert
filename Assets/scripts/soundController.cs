using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioClip sombra;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void sombraSFX()
    {
        AudioSource.PlayClipAtPoint(sombra, transform.position, 0.5f);
    }

}
