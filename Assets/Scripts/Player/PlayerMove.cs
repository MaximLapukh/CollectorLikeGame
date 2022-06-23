using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    private const string IDLE_STATE = "Idle";
    private const string RUN_STATE = "Run";
    private string _currentState;


    [Header("Options")]
    [SerializeField] float _speed;
    [SerializeField] float _rotateSpeed;

    [Header("Links")]
    [SerializeField] MonoBehaviour _getDirectionMB;
    private IGetDirecction _getDirection;
    private CharacterController _controller;
    private Animator _animator;

    void Start()
    {
        _getDirection = _getDirectionMB.GetComponent<IGetDirecction>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(_getDirection.GetDir() != Vector2.zero)
        {
            var move = new Vector3(_getDirection.GetDir().x, 0, _getDirection.GetDir().y);
            _controller.Move(move * _speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(move), _rotateSpeed);
            SetState(RUN_STATE);
        }
        else
        {
            SetState(IDLE_STATE);
        }
    }
    private void SetState(string state)
    {
        if(_currentState != state)
        {
            _animator.SetTrigger(state);
            _currentState = state;
        }
    }
}
