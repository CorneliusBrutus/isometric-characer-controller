using UnityEngine;

namespace IsometricCharacterController
{
  public class CameraBehaviour : MonoBehaviour
  {
    //target transform reference
    //target offset - eg rather than looking at the target, look at a game object arbitrary offset away from target
    //distance from target
    //angle from ground/height

    private void Update()
    {
      //calculate desired position
    }

    private void LateUpdate()
    {
      //update actual position w/ follow speed?
    }

    //draw gizmos of "projected target", line to obj etc.
  }
}