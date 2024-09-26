using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private NavMeshAgent _navMesh;
    private Animator _animator;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                _navMesh.destination = hit.point;
               
            }
        }
        var isWalking = _navMesh.enabled && _navMesh.velocity.sqrMagnitude > 0;
        _animator.SetBool(IsWalking, isWalking);
        
    }
}