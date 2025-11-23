using Unity.VisualScripting;
using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
public class PohaDeGitHubDoKRL : MonoBehaviour
{
    private CinemachineConfiner2D confiner;
    private CinemachinePositionComposer _transposer;
    public CinemachineCamera cineM;
    [SerializeField] GameObject BossCu;
    [SerializeField] GameObject ParedeCu;
    [SerializeField] GameObject PohinhaCu1;
    [SerializeField] GameObject PohinhaCu2;
    [SerializeField] GameObject PohinhaCu3;
    public PolygonCollider2D shape2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transposer = cineM.GetComponent<CinemachinePositionComposer>();
        confiner = cineM.GetComponent<CinemachineConfiner2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BossCu)
        {
            
        }
        else
        {
                        _transposer.enabled = true;
            confiner.Damping = 0.65f;
            confiner.BoundingShape2D = shape2;

            StartCoroutine(filhadapudadocaralho());
            confiner.InvalidateBoundingShapeCache();
            Destroy(ParedeCu);
            Destroy(PohinhaCu1);
            Destroy(PohinhaCu2);
            Destroy(PohinhaCu3);


        }
    }

    IEnumerator filhadapudadocaralho()
    {
        yield return new WaitForSeconds(0.3f);
        confiner.Damping = 0f;
    }
}
