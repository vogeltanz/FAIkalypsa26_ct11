using UnityEngine;
using UnityEngine.Events;

public class GroundDetection : MonoBehaviour
{
    bool isGrounded = false;

    public UnityEvent<bool> IsGrounded;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        IsGrounded?.Invoke(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isGrounded)
        {
            isGrounded = true;
            IsGrounded?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
        IsGrounded?.Invoke(false);
    }
}
