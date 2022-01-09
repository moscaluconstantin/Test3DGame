using UnityEngine;

public class TestIKController : MonoBehaviour
{
     [Header("Head")]
     [SerializeField] [Range(0f, 1f)] private float lookAtWeight = 0f;
     [SerializeField] private Transform lookAtObjectTransform;

     [Header("Left Hand")]
     [SerializeField] [Range(0f, 1f)] private float leftHandPositionWeight = 0f;
     [SerializeField] [Range(0f, 1f)] private float leftHandRotationWeight = 0f;
     [SerializeField] private Transform leftHandObjectTransform;

     [Header("Right Hand")]
     [SerializeField] [Range(0f, 1f)] private float rightHandPositionWeight = 0f;
     [SerializeField] [Range(0f, 1f)] private float rightHandRotationWeight = 0f;
     [SerializeField] private Transform rightHandObjectTransform;

     private bool HeadIK => lookAtObjectTransform != null;
     private bool LeftHandIK => lookAtObjectTransform != null;
     private bool RightHandIK => lookAtObjectTransform != null;

     private Animator animator;

     private void Awake()
     {
          animator = GetComponent<Animator>();
     }
     private void OnAnimatorIK()
     {
          if (animator == null)
               return;

          if (HeadIK)
          {
               animator.SetLookAtPosition(lookAtObjectTransform.position);
               animator.SetLookAtWeight(lookAtWeight);
          }

          if (LeftHandIK)
          {
               animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObjectTransform.position);
               animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandPositionWeight);

               animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObjectTransform.rotation);
               animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandRotationWeight);
          }

          if (RightHandIK)
          {
               animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObjectTransform.position);
               animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandPositionWeight);

               animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObjectTransform.rotation);
               animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandRotationWeight);
          }
     }
}
