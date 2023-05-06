using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Player and Camera controller - Unity Task Sefa Kabataş
    /// </summary>
    #region Definitions
    [Header("Settings")]
    [SerializeField] private Transform mainCamera; //camera
    [SerializeField] private Rigidbody rigidBody; //rigidbody
    [SerializeField] private float sensitivity; //sensi camera right left
    [SerializeField] private float moveForce; //player move
    [SerializeField] private float maxMoveSpeed;//player speed
    [Space(3)]
    [Header("Elements")]
    private float pitch;
    private float yaw;
    #endregion
    #region Start
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
    #region Update
    private void Update()
    {
        #region Camera Controller
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        mainCamera.localRotation = Quaternion.Euler(pitch, 0, 0);
        #endregion
    }
    #endregion
    #region FixedUpdate
    private void FixedUpdate()
    {
        #region Player Controller
        rigidBody.AddRelativeForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveForce);

        Vector3 vel = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z);
        rigidBody.AddForce(-vel * (moveForce / maxMoveSpeed), ForceMode.Acceleration);
        #endregion
    }
    #endregion
}
