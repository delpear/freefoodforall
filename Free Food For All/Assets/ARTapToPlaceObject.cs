using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR

public class ARTapToPlaceObject : MonoBehaviour
{
	public GameObject placementIndicator
	private ARSessionOrigin arOrigin;
    private Pose placementPose;
	private bool placementPoseIsValid = false;
	
    void Start()
    {
		arOrigin = FindObjectOfType<ARSessionOrigin>();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
		UpdatePlacementIndicator():
    }
	private void UpdatePlacementPose()
	{
		var screenCenter = Camera.Current.ViewportToScreenPoint(new Vector3(0.5f, 0.5F));
		var hits = new List<ARRaycastHit>();
		arOrigin.Raycast(screenCenter, hits, TrackableType.Planes)
		placementPoseIsValid = hits.Count > 0;
		
		if (placementPoseIsValid)
		{
	 	placementPose = hits[0].pose;
		}
	}
	
	private void UpdatePlacementIndicator()
	{
		if(placementPoseIsValid)
		{
			placementIndicator.setActive(true);
			placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation)
		}
		else
		{
			placementIndicator.SetActive(false);
		}
	}
}
