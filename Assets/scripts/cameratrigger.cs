using UnityEngine;
using Unity.Cinemachine;
public class cameratrigger : MonoBehaviour
{
    private CinemachinePositionComposer _transposer;
    public Vector3 _followOffset; 
    public CinemachineCamera cineM;


    void Start()
    {
        _transposer = cineM.GetComponent<CinemachinePositionComposer>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _transposer.TargetOffset = _followOffset;
        }
    }
}
