using System;
using UnityEngine;

public class GhoulAI : MonoBehaviour
{
    Animator _animator;
    bool playerIsVisible = false;

    [SerializeField]
    GameObject player;

    void Awake()
    {
        _animator = GetComponent<Animator>();

        _animator.GetBehaviour<GhoulRunStateMachine>().Player = player;
    }

    public void CheckPlayerVisibility(GameObject player)
    {
        if (player != null)
        {
            Vector3 position = transform.position + Vector3.up * 1.5f;
            Vector3 playerPosition = player.transform.position + Vector3.up * 1.5f;
            Vector3 direction = (playerPosition - position).normalized;
            Ray ray = new Ray(position, direction);

            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, 10, ~LayerMask.GetMask("Ignore Raycast"));
            Debug.DrawRay(position, direction * 10, Color.red);

            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
            {
                playerIsVisible = true;
                _animator?.SetBool("PlayerIsVisible", playerIsVisible);
            }
            else
            {
                playerIsVisible = false;
                _animator?.SetBool("PlayerIsVisible", playerIsVisible);
            }
        }
        else
        {
            playerIsVisible = false;
            _animator?.SetBool("PlayerIsVisible", playerIsVisible);
        }
    }
}
