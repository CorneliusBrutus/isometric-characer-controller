using IsometricCharacterController.Interfaces;
using Zenject;

namespace IsometricCharacterController
{
  public class TestInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IInputDriver>().To<MouseClickInputProcessor>().AsSingle();
    }
  }
}