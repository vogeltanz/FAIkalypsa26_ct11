using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhoulAICalculations : MonoBehaviour
{
    Animator _animator;

    GameObject player;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        _animator.SetFloat("PlayerDistance", distanceToPlayer);
    }
}
