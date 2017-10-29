using System.Collections;
using Wrld;
using Wrld.Resources.Buildings;
using Wrld.Space;
using UnityEngine;

public class Highlights : MonoBehaviour
{
    [SerializeField]
    private Material material;

    private LatLong buildingLocation = LatLong.FromDegrees(37.795189, -122.402777);


    void Update()
    {

       // if (Input.GetKeyDown(KeyCode.M))
        //{

        //    Debug.Log("Press M");
       //     StartCoroutine(Example());

       // }

    }
    IEnumerator Example()
    {

        while (true)
        {

            yield return new WaitForSeconds(0.0f);

            Api.Instance.BuildingsApi.HighlightBuildingAtLocation(buildingLocation, material, OnBuildingHighlighted);

        }
    }

    void OnBuildingHighlighted(bool success, Highlight highlight)
    {
        if (success && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ClearHighlight(highlight));
        }
    }

    IEnumerator ClearHighlight(Highlight highlight)
    {
        yield return new WaitForSeconds(0.0f);
        Api.Instance.BuildingsApi.ClearHighlight(highlight);
        StopAllCoroutines();
    }

    public void BeginHighlighting()
    {
        StartCoroutine(Example());
    }

    //void EndHighlighting(Highlight highlight)
    //{

    //  StartCoroutine(ClearHighlight(highlight));

    //}

}