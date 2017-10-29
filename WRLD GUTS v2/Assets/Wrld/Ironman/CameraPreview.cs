using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld;
using Wrld.Resources.Buildings;
using Wrld.Space;


public class CameraPreview : MonoBehaviour {

    private LatLong buildingLocation = LatLong.FromDegrees(37.795189, -122.402777);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Api.Instance.CameraApi.MoveTo(buildingLocation, distanceFromInterest: 1000, headingDegrees: 0, tiltDegrees: 45);

    }

}
