using UnityEngine;

namespace IsometricCharacterController
{
  [ExecuteInEditMode]
  public class FollowCameraBehavior : MonoBehaviour
  {
    //we want to follow this transform target
    [SerializeField]
    private Transform target;
    //positional offset from the target for the camera to follow and look at
    [SerializeField]
    private Vector3 targetViewOffset;
    [SerializeField]
    private float distanceToTargetView;    
    [SerializeField, Range(0f, 1f)]
    private float smoothingFactor = 0.5f;

    private Transform cachedTransform;
    private Vector3 desiredCameraPosition;
    private Vector3 projectedTargetViewPosition;

    private void Awake()
    {
      cachedTransform = transform;
    }  

    private void Update()
    {
      //we are looking at a positional offset from our target locked transform
      projectedTargetViewPosition = target.position + targetViewOffset;
      //move camera to be the desired distance away from this projected position
      desiredCameraPosition = projectedTargetViewPosition - cachedTransform.forward * distanceToTargetView;
    }

    private void LateUpdate()
    {
      if (!Application.isPlaying)
      {
        //update instantly in editor mode for easier use
        cachedTransform.position = desiredCameraPosition;
        cachedTransform.LookAt(projectedTargetViewPosition);
      }
      else
      {
        //due to possible smoothing can't use LookAt on the transform, need to figure out what the rotation would be for the points
        var lookAt = Quaternion.LookRotation(projectedTargetViewPosition - desiredCameraPosition, Vector3.up);
        cachedTransform.position = Vector3.Lerp(cachedTransform.position, desiredCameraPosition, smoothingFactor);
        cachedTransform.rotation = lookAt;
      }
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawSphere(projectedTargetViewPosition, 1f);
      Gizmos.DrawLine(projectedTargetViewPosition, desiredCameraPosition);
    }
  }
}