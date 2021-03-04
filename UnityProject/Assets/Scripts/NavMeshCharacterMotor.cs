using IsometricCharacterController.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace IsometricCharacterController
{
  public class NavMeshCharacterMotor : MonoBehaviour
  {
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    // expose speed (readonly)
    private IInputDriver inputDriver;

    [Inject]
    public void Construct(IInputDriver inputProcessor)
    {
      this.inputDriver = inputProcessor;
    }

    void Update()
    {
      inputDriver.Update();
      //navMeshAgent.Move(inputDriver.Position);
      navMeshAgent.SetDestination(inputDriver.Position);
      //input goes into m
    }
  }
}