using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// <summary>
    /// Score
    /// </summary>
    #region Definitions
    [Header(" Canvas ")]
    [SerializeField] private Transform dragParent;
    [SerializeField] private int totalScore = 0;
    [SerializeField] private Text totalScoreText;
    [Space(3)]
    [Header(" Settings ")]
    private bool oneTimeRun = false;
    #endregion
    #region Update
    private void Update()
    {
        scoreCalculator();
    }
    #endregion
    #region scoreCalculator
    public void scoreCalculator()
    {
        if (oneTimeRun == false)
        {
            if (GameObject.Find("Player").GetComponent<GameManager>().finishGame)
            {
                for (int i = 0; i < dragParent.childCount; i++)
                {
                    #region Addition
                    if (dragParent.transform.GetChild(i).name != null)
                    {
                        if (dragParent.transform.GetChild(i).name == "safetyHelmet")
                        {
                            totalScore += 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "earDefenders")
                        {
                            totalScore += 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "safetyGoggles")
                        {
                            totalScore += 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "workBoots")
                        {
                            totalScore += 5;
                        }
                        #endregion
                    #region Difference
                        else if (dragParent.transform.GetChild(i).name == "baseballCap")
                        {
                            totalScore -= 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "headphones")
                        {
                            totalScore -= 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "sunglasses")
                        {
                            totalScore -= 5;
                        }
                        else if (dragParent.transform.GetChild(i).name == "sportsShoes")
                        {
                            totalScore -= 5;
                        }
                        #endregion
                    }
                }
                totalScoreText.text = "Score: " + totalScore.ToString();
                oneTimeRun = true;

            }
        }
    }
    #endregion
}
