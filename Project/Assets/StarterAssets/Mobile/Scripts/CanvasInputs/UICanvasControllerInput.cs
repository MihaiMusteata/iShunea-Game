using UnityEngine;
//using ThirdPersonController;
using System.Collections;

namespace StarterAssets
{
     public class UICanvasControllerInput : MonoBehaviour
     {

          [Header("Output")]
          public Animator _animator;

          public StarterAssetsInputs starterAssetsInputs;

          public void VirtualMoveInput(Vector2 virtualMoveDirection)
          {
               starterAssetsInputs.MoveInput(virtualMoveDirection);
          }

          public void VirtualLookInput(Vector2 virtualLookDirection)
          {
               starterAssetsInputs.LookInput(virtualLookDirection);
          }

          public void VirtualJumpInput(bool virtualJumpState)
          {
               Debug.Log("Jump!!");
               starterAssetsInputs.JumpInput(virtualJumpState);
          }

          public void VirtualSprintInput(bool virtualSprintState)
          {
               starterAssetsInputs.SprintInput(virtualSprintState);
          }
          public void VirtualAttakInput()
          {
               /* SRC.clip = sfx;
               SRC.Play(); */
               //int AttackMode = Random.Range(1, 2);
               _animator.SetTrigger("Attack01"/*  + AttackMode */);
          }
       
     }

}
