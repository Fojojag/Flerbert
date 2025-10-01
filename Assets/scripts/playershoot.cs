using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    public static bool paused;
    private bool _isShooting = false;
    private float _buttonPressTimer = 0f;
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.X))
            {
                _buttonPressTimer = 0.5f;

            }
            _buttonPressTimer = Mathf.Clamp(_buttonPressTimer - 1f * Time.deltaTime, 0, 4f);
            _isShooting = (_buttonPressTimer > 0) ? true : false;
            _anim.SetBool("isShooting", _isShooting);

            if (Input.GetKeyUp(KeyCode.X))
            {
                _buttonPressTimer = 0.2f;

            }
            _buttonPressTimer = Mathf.Clamp(_buttonPressTimer - 1f * Time.deltaTime, 0, 1f);
            _isShooting = (_buttonPressTimer > 0) ? true : false;
            _anim.SetBool("isShooting", _isShooting);
        
    }
}
