using IsometricCharacterController.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts
{
  //TODO auto generate based on nav mesh?
  public class ClickableInputPlane : MonoBehaviour
  {
    private Plane plane;
    private IInputDriver inputDriver;

    [Inject]
    public void Construct(IInputDriver inputDriver)
    {
      this.inputDriver = inputDriver;
    }

    void Awake()
    {
      plane = new Plane(Vector3.up, transform.position);
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(1))
      {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float enter))
        {
          //TODO instead we make a NavMeshClicked event or something to hand this off
          //so different motor processors can handle it differently?
          //TODO make injectable navigation prefabs?
          var point = ray.GetPoint(enter);
          inputDriver.Position = point;
        }
      }   
    }
  }
}
