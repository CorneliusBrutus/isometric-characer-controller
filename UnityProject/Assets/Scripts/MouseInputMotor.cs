using IsometricCharacterController.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace IsometricCharacterController
{
  public class MouseInputMotor : MonoBehaviour, ICharacterMotor
  {
    [SerializeField]
    private ClickableInputPlane inputPlane;
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    public void CombinedAxisInput(Vector2 input)
    {
      //no-op?
    }

    public void MouseClick(Vector2 cameraPosition)
    {
      if (inputPlane.TryClickPlane(cameraPosition, out Vector3 pointOnNavmesh))
      {
        navMeshAgent.SetDestination(pointOnNavmesh);
      }
    }

    public void SetActive(bool state)
    {
      navMeshAgent.ResetPath();

      if (state)
      {
        navMeshAgent.updateRotation = true;       
      }
    }
  }
}