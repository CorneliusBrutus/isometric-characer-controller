using UnityEngine;
using Zenject;

namespace IsometricCharacterController
{
  public class TestInstaller : MonoInstaller
  {
    [SerializeField]
    private InputProcessor inputProcessor;

    public override void InstallBindings()
    {
      Container.Bind<InputProcessor>().FromInstance(inputProcessor);
    }
  }
}