using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObjects : MonoBehaviour
{
    /// <summary>
    /// all object add 
    /// </summary>
    #region Definitions

    [Header(" Settings ")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private int dragCount;
    public bool isBeingHeld = false;
    private Vector3 mousePos;
    [Space(3)]
    [Header(" Elements ")]
    [SerializeField] private Collider draggableObject;
    [SerializeField] private Transform dragParent;
    [SerializeField] private Transform firstLocation;
    


    #endregion

    #region OnMouse
    void OnMouseDown()
    {
        isBeingHeld = true;
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        isBeingHeld = false;

    }
    #endregion

    #region Update
    void Update()
    {
        dragCount = dragParent.transform.childCount;
        if (dragCount <= 4)
        {
            if (isBeingHeld)
            {
                // Get the current mouse position in screen space
                mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;

                // Convert the mouse position to world space and move the object to that position
                transform.position = Camera.main.ScreenToWorldPoint(mousePos) - offset;
            }
        }
        else
        {
            isBeingHeld = false;

        }
    }
    #endregion

    #region Disable
    //object collider
    public void Disable()
    {
        draggableObject.enabled = false;
    }
    #endregion
    #region Enable
    public void Enable()
    {
        draggableObject.enabled = true;
    }
    #endregion

}
