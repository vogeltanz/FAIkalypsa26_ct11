using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InFrontDetection : MonoBehaviour
{
    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position + Vector3.up * 1.5f;
        Vector3 inFrontPosition = position + Vector3.forward * 1.5f;
        Vector3 direction = (position - inFrontPosition).normalized;
        Ray ray = new Ray(position, direction);

        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 1.5f, ~LayerMask.GetMask("Ignore Raycast"));
        Debug.DrawRay(position, direction * 1.5f, Color.yellow);

        if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
        {
            _animator?.SetBool("InFrontOfPlayer", true);
        }
        else
        {
            _animator?.SetBool("InFrontOfPlayer", false);
        }
    }
}
