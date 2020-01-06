//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Vuforia;


//public class Anim_Trigger : MonoBehaviour, ITrackableEventHandler
//{

//    private TrackableBehaviour mTrackableBehaviour;
//    public GameObject animal_islands;

//    void Start()
//    {
//        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
//        if (mTrackableBehaviour)
//        {
//            mTrackableBehaviour.RegisterTrackableEventHandler(this);
//        }
//    }

//    public void OnTrackableStateChanged(
//                                    TrackableBehaviour.Status previousStatus,
//                                    TrackableBehaviour.Status newStatus)
//    {
//        if (newStatus == TrackableBehaviour.Status.DETECTED ||
//            newStatus == TrackableBehaviour.Status.TRACKED ||
//            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
//        {

//            animal_islands.SetActive(true);

//        }
//        else
//        {
//            animal_islands.SetActive(false);

//        }
//    }
//}
