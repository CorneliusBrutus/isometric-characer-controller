using IsometricCharacterController.Interfaces;
using UnityEngine;

namespace IsometricCharacterController
{
  public class MouseClickInputProcessor : IInputDriver
  {
    public Vector3 Position { get; set; }

    public void Update()
    {
      if (Input.GetMouseButtonDown(0))
      { 
      }
    }
  }
}