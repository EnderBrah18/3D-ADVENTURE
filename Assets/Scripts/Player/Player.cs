using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public CharacterController characterController;
    public Animator animator;
    private Vector3 velocity;
    private bool isGrounded;



    public float speed = 1f;
    public float gravity = 9.8f;
    public float turnSpeed = 1f;
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;
    [Header("Jump Setup")]
    public float jumpSpeed = 15f;
    public KeyCode keyJump = KeyCode.Space;



    public float vSpeed = 0f;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    #region LIFE
    public void Damage(float damage)
    {
        flashColors.ForEach(i => i.Flash());
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    #endregion
}












