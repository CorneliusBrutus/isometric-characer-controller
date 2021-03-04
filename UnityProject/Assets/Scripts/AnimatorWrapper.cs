using UnityEngine;
using UnityEngine.AI;

namespace IsometricCharacterController
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class AnimatorWrapper : MonoBehaviour
  {
    [SerializeField]
    private Animator animator;

    private NavMeshAgent navMeshAgent;
    private int speedParameter;

    private void Awake()
    {
      navMeshAgent = GetComponent<NavMeshAgent>();
      speedParameter = Animator.StringToHash("Speed_f");
    }

    private void Update()
    {
      animator.SetFloat(speedParameter, navMeshAgent.velocity.magnitude/navMeshAgent.speed);
    }
  }
}
