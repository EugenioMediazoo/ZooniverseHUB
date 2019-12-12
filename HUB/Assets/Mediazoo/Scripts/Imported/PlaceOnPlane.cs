using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    public GameObject m_PlacedPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    ARRaycastManager m_RaycastManager;
    ARPlaneManager m_ARPlaneManager;
    
    [HideInInspector]
    public bool UI_Off;

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_PlacedPrefab.SetActive(false);

        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        SetAllPlanesActive(true);

        UI_Off = true;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    public bool debug = false;
    void Update()
    {

        if (debug)
        {
            Test();
            debug = !debug;
        }

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (UI_Off == false) 
        {
            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    //spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    
                    m_PlacedPrefab.SetActive(true);
                    spawnedObject = m_PlacedPrefab;
                    m_PlacedPrefab.transform.position = hitPose.position;
                    m_PlacedPrefab.transform.rotation = hitPose.rotation;

                    Debug.Log(m_PlacedPrefab.name);
                    Debug.Log(m_PlacedPrefab.transform.position);
                    Debug.Log(m_PlacedPrefab.transform.rotation);
                    //SetAllPlanesActive(false);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }

    public void Test()
    {
        if (spawnedObject == null)
        {
            m_PlacedPrefab.SetActive(true);
            Debug.Log(m_PlacedPrefab.name);
        }
    }
    

static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }
}
