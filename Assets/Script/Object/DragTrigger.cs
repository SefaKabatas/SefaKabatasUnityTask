using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTrigger : MonoBehaviour
{
    #region Definitions
    [Header(" First Location ")]
    [SerializeField] private float circle;
    [SerializeField] private Transform firstLocationCap;
    [SerializeField] private Transform firstLocationEar;
    [SerializeField] private Transform gogglesLocationEar;
    [SerializeField] private Transform shoesLocationEar;
    [Space(3)]
    [Header(" List ")]

    [SerializeField] private List<GameObject> caplist = new List<GameObject>();
    [SerializeField] private List<GameObject> earList = new List<GameObject>();
    [SerializeField] private List<GameObject> goggles = new List<GameObject>();
    [SerializeField] private List<GameObject> shoes = new List<GameObject>();
    #endregion
    #region Start
    private void Start()
    {
        caplist.Clear();
        earList.Clear();
        goggles.Clear();
        shoes.Clear();
    }
    #endregion
    #region Update
    void Update()
    {
        DetectDoors();
    }
    #endregion
    #region DetectObject
    private void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, circle);
        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out DraggableObjects draggable))
            {
                if (detectedColliders[i].GetComponent<DraggableObjects>().isBeingHeld)
                {
                    detectedColliders[i].transform.parent = this.gameObject.transform;
                    GameObject.Find("---SoundManager---").GetComponent<AudioSource>().Play();
                    draggable.Disable();

                    if (detectedColliders[i].tag == "Cap")
                    {
                        caplist.Add(detectedColliders[i].gameObject);
                        if (caplist.Count > 1)
                        {
                            caplist[0].transform.position = firstLocationCap.transform.position;
                            caplist[0].transform.parent = firstLocationCap.transform;
                            caplist[0].gameObject.transform.GetComponent<DraggableObjects>().Enable();
                            caplist[1].transform.position = this.gameObject.transform.position;
                            caplist.RemoveAt(0);

                        }
                    }
                    if (detectedColliders[i].tag == "Ear")
                    {
                        earList.Add(detectedColliders[i].gameObject);
                        if (earList.Count > 1)
                        {
                            earList[0].transform.position = firstLocationEar.transform.position;
                            earList[0].transform.parent = firstLocationEar.transform;
                            earList[0].gameObject.transform.GetComponent<DraggableObjects>().Enable();
                            earList[1].transform.position = this.gameObject.transform.position;
                            earList.RemoveAt(0);

                        }
                    }
                    if (detectedColliders[i].tag == "goggles")
                    {
                        goggles.Add(detectedColliders[i].gameObject);
                        if (goggles.Count > 1)
                        {
                            goggles[0].transform.position = gogglesLocationEar.transform.position;
                            goggles[0].transform.parent = gogglesLocationEar.transform;
                            goggles[0].gameObject.transform.GetComponent<DraggableObjects>().Enable();
                            goggles[1].transform.position = this.gameObject.transform.position;
                            goggles.RemoveAt(0);

                        }
                    }
                    if (detectedColliders[i].tag == "shoes")
                    {
                        shoes.Add(detectedColliders[i].gameObject);
                        if (shoes.Count > 1)
                        {
                            shoes[0].transform.position = shoesLocationEar.transform.position;
                            shoes[0].transform.parent = shoesLocationEar.transform;
                            shoes[0].gameObject.transform.GetComponent<DraggableObjects>().Enable();
                            shoes[1].transform.position = this.gameObject.transform.position;
                            shoes.RemoveAt(0);

                        }
                    }

                }


            }
        }
    }
    #endregion
}

