using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public Animator anim;

    public float speed = 5f;
    float turnSmoothTime = 0.1f;
    float _turnSmooothVelocity;

    private Vector3 heightOffset = new Vector3(0, 0.9f, 0);

    [SerializeField] GameObject NameSettingCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (!NameSettingCanvas.activeSelf)
        {
            HandleWalkAnimation(inputDirection);
            HandleWalk(inputDirection);
        }

        #region Cursor Locked in Screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        #endregion
    }


    void HandleWalkAnimation(Vector2 input)
    {
        if (!NameSettingCanvas.activeSelf)
        {
            anim.SetBool("isWalking", input.sqrMagnitude > 0.05f);
        }
    }

    void HandleWalk(Vector2 input)
    {
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        
        // If the input is small enough, don't do anything.
        if (direction.magnitude <= 0.05f) return;
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmooothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        Vector3 newPosition = transform.position + moveDir.normalized * speed * Time.deltaTime;

        // Check if the desired next point is on the navmesh.
        bool isValid = NavMesh.SamplePosition(newPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas);
        if (isValid)
        {
            transform.position = hit.position + heightOffset;
        }
    }
}
