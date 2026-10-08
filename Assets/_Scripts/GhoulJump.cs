using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class GhoulJump : MonoBehaviour
{
    Rigidbody _rigidbody;

    InputAction _jumpAction;

    [SerializeField]
    [Range(0.1f, 10.0f)]
    float jumpVelocity = 5.0f;

    bool isGrounded = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && _jumpAction.WasPressedThisFrame())
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, jumpVelocity, _rigidbody.linearVelocity.z);
        }
    }

    public void SetIsGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
