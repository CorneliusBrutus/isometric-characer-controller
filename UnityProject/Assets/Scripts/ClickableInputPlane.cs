using UnityEngine;

namespace IsometricCharacterController
{
  public class ClickableInputPlane : MonoBehaviour
  {
    private Camera mainCamera;
    private Plane plane;

    void Awake()
    {
      mainCamera = Camera.main;
      plane = new Plane(Vector3.up, transform.position);
    }

    public bool TryClickPlane(Vector2 positionInCamera, out Vector3 point)
    {
      point = Vector3.zero;
      var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

      if (plane.Raycast(ray, out float enter))
      {
        point = ray.GetPoint(enter);
        return true;
      }

      return false;
    }   
  }
}
