using UnityEngine;

public class background : MonoBehaviour
{
    private float startPos, length;
    private float startPosY, height;
    public GameObject cam;
    public float parallaxEffect; // The speed at which the background should move relative to the camera

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosY = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
        // Calculate distance background move based on cam movement
        float distance = cam.transform.position.x * parallaxEffect; // = move with cam || 1 = won't move || 0.5 = half float movement cam.transform.position.x (1 parallaxEffect);
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(startPos + distance, startPosY + cam.transform.position.y , transform.position.z);
        // if background has reached the end of its length adjust its position for infinite scrolling if (movement > startPos + length)
        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }

    }
}