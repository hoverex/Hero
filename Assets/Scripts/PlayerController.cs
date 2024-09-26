using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
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
                _animator.SetBool("isWalking", true); // Устанавливаем булевый параметр
            }
        }

        // Проверка, достиг ли персонаж целевой точки
        if (_navMesh.remainingDistance <= _navMesh.stoppingDistance)
        {
            _animator.SetBool("isWalking", false); // Отключаем ходьбу
        }
    }
}