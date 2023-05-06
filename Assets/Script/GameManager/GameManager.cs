using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Finis game and Total Score
    /// </summary>
    #region Definitions
    [Header(" Elements ")]
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Collider clickObject;
    public bool finishGame = false;
    [Space(3)]
    [Header(" Settings ")]
    private Ray _ray;
    private RaycastHit _hit;
    #endregion
    #region Update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Click();
        }
    }
    #endregion
    #region Click
    private void Click()
    {
        if (!clickObject) return;

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider == clickObject)
            {
                finishPanel.SetActive(true);
               
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                finishGame = true;
            }
        }
    }
    #endregion
    #region RestartButton
    public void RestartButton()
    {
        finishPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    #endregion

}
