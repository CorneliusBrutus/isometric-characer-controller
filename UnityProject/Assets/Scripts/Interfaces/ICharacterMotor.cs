using UnityEngine;

namespace IsometricCharacterController.Interfaces
{
  public interface ICharacterMotor
  {
    void SetActive(bool state);
    void MouseClick(Vector2 cameraPosition);
    void CombinedAxisInput(Vector2 input);
  }
}