using IsometricCharacterController.Interfaces;
using UnityEngine;

namespace IsometricCharacterController
{
  public class InputProcessor : MonoBehaviour
  {
    [SerializeField]
    private MouseInputMotor mouseInputMotor;
    [SerializeField]
    private CombinedAxisInputMotor axisInputMotor;

    private const string AXIS_HORIZONTAL = "Horizontal";
    private const string AXIS_VERTICAL = "Vertical";

    private void Update()
    {
      if (Input.GetMouseButtonDown(1))
      {
        activeMotor = mouseInputMotor;
        activeMotor.MouseClick(Input.mousePosition);        
      }
      else
      {      
        var inputVector = new Vector2(Input.GetAxisRaw(AXIS_HORIZONTAL), Input.GetAxisRaw(AXIS_VERTICAL));
        if (inputVector.magnitude > 0f)
        {
          activeMotor = axisInputMotor;
          activeMotor.CombinedAxisInput(inputVector);
        }      
      }
    }

    private ICharacterMotor _activeMotor;
    private ICharacterMotor activeMotor
    {
      get => _activeMotor;
      set 
      {
        if (_activeMotor == null)
        {
          _activeMotor = value;
          _activeMotor.SetActive(true);
        }

        if (_activeMotor != value)
        {          
          _activeMotor.SetActive(false);          
          _activeMotor = value;
          _activeMotor.SetActive(true);
        }
      }
    }
  }
}
