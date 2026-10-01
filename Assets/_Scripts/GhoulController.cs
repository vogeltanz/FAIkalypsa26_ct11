using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class GhoulController : MonoBehaviour
{
    Animator _animator;
    InputAction _moveAction;

    [SerializeField]
    [Range(0.1f, 10.0f)]
    float _speed = 2.0f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = _moveAction.ReadValue<Vector2>();

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            var vx = moveInput.x * Vector3.right;
            var vz = moveInput.y * Vector3.forward;

            transform.Translate((vx + vz) * Time.deltaTime * _speed);

            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }

    }
}
