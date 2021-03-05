using UnityEngine;

namespace IsometricCharacterController
{
  [ExecuteInEditMode]
  public class CameraBehaviour : MonoBehaviour
  {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetViewOffset;
    [SerializeField]
    private float distanceToTargetView;
    [SerializeField]
    private Vector3 rotationRelativeToTargetViewEuler;
    [SerializeField, Range(0f, 1f)]
    private float smoothing = 0.5f;

    private Transform cachedTransform;

    private void Awake()
    {
      cachedTransform = transform;
    }

    //target transform reference
    //target offset - eg rather than looking at the target, look at a game object arbitrary offset away from target
    //distance from target
    //angle from ground/height

    private Vector3 desiredCameraPosition;
    private Vector3 projectedTargetViewPosition;
    private Vector3 test;

    private void Update()
    {
      //calculate desired position
      projectedTargetViewPosition = target.position + targetViewOffset;
      test = projectedTargetViewPosition + new Vector3(distanceToTargetView, 0f, 0f);
      //desiredCameraPosition = Quaternion.Euler(rotationRelativeToTargetViewEuler) * test;
      desiredCameraPosition = projectedTargetViewPosition - cachedTransform.forward * distanceToTargetView;
    }

    private void LateUpdate()
    {
      //smoothing
      //update actual position w/ follow speed?
      cachedTransform.position = desiredCameraPosition;
      //cachedTransform.position = Vector3.Slerp(cachedTransform.position, desiredCameraPosition, smoothing * Time.deltaTime);
      cachedTransform.LookAt(projectedTargetViewPosition);
    }

    private void OnDrawGizmosSelected()
    {
      //draw gizmos of "projected target", line to obj etc.
      Gizmos.DrawSphere(projectedTargetViewPosition, 1f);
      Gizmos.DrawLine(projectedTargetViewPosition, test);
    }
  }
}