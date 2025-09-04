using UnityEngine;

public class teste1 : MonoBehaviour
{
public float itemUp = 0.1f;
public float itemMove = 0.7f;


public float x;
float y;
float z;
Vector3 pos;

void Update () {

    //transform.position = Vector2(Random.Range (1,4),Random.Range (1,4),10);

    transform.position -= Vector3.right * itemMove * Time.deltaTime;

    x = 0;
    y = Random.Range(-100, 100);
    z = 0;
    pos = new Vector3(-x, y, z);
    transform.position = pos * itemUp * Time.deltaTime;
}
} 
    
