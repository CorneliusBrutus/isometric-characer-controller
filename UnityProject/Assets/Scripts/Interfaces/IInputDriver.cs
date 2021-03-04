using UnityEngine;

namespace IsometricCharacterController.Interfaces
{
  public interface IInputDriver
  {
    void Update();
    Vector3 Position { get; set; }    
  }
}