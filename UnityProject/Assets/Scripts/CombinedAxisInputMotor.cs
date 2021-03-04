using IsometricCharacterController.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace IsometricCharacterController
{
  public class CombinedAxisInputMotor : MonoBehaviour, ICharacterMotor
  {
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    public void CombinedAxisInput(Vector2 input)
    {
      var direction = new Vector3(input.x, 0f, input.y).normalized;
      var movementAmount = direction * navMeshAgent.speed;
      var desiredLookRotation = Quaternion.LookRotation(direction);

      transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredLookRotation, Time.deltaTime * navMeshAgent.angularSpeed);
      navMeshAgent.velocity = movementAmount;
    }

    public void MouseClick(Vector2 cameraPosition)
    {
      //no-op?
    }

    public void SetActive(bool state)
    {
      if (state)
      {
        navMeshAgent.updateRotation = false;
      }
    }
  }
}