using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMap : MonoBehaviour
{
    public GameObject MarkerPrefab;
    public GameObject AxeMarkerPrefab;
    public GameObject ExitMarkerPrefab;
    private Vector2 Ratio;
    // Start is called before the first frame update
    void Start()
    {
        Transform groundPlane = GameObject.FindWithTag("Ground").transform;
        Vector3 pivotOffset = new Vector3(0.5f, -0.5f, 0.55f);
        Vector2 planeOffset = new Vector2(groundPlane.position.x, groundPlane.position.z) - new Vector2(groundPlane.localScale.x * 10 / 2, groundPlane.localScale.z * 10 / 2);

        Ratio = new Vector2(1f / (groundPlane.localScale.x * 10), 1f / (groundPlane.localScale.z * 10));

        GameObject[] axes = GameObject.FindGameObjectsWithTag("Axe");
        for (int i = 0; i < axes.Length; ++i)
        {
            Vector3 axePosition = axes[i].transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
            Vector3 markerAxePosition = new Vector3(axePosition.x, axePosition.z, 0f);
            GameObject markerAxe = Instantiate(AxeMarkerPrefab, transform.position, transform.rotation);
            markerAxe.transform.Rotate(new Vector3(90f, 0, 0));
            markerAxe.transform.SetParent(transform);

            markerAxe.transform.localPosition += pivotOffset;

            Vector3 translationAxe = new Vector3(-markerAxePosition.x * Ratio.x, markerAxePosition.y * Ratio.y, 0f);
            markerAxe.transform.localPosition += translationAxe;
        }

        GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < exits.Length; ++i)
        {
            Vector3 exitPosition = exits[i].transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
            Vector3 markerExitPosition = new Vector3(exitPosition.x, exitPosition.z, 0f);
            GameObject markerExit = Instantiate(ExitMarkerPrefab, transform.position, transform.rotation);
            markerExit.transform.Rotate(new Vector3(90f, 0, 0));
            markerExit.transform.SetParent(transform);

            markerExit.transform.localPosition += pivotOffset;

            Vector3 translationExit = new Vector3(-markerExitPosition.x * Ratio.x, markerExitPosition.y * Ratio.y, 0f);
            markerExit.transform.localPosition += translationExit;
            markerExit.GetComponent<Renderer>().material.color = new Color(0,1f,0,1f);
        }

        Vector3 ourPosition = transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
        Vector3 markerOurPosition = new Vector3(ourPosition.x, ourPosition.z, 0f);
        GameObject markerOur = Instantiate(MarkerPrefab, transform.position, transform.rotation);
        markerOur.transform.Rotate(new Vector3(90f, 0, 0));
        markerOur.transform.SetParent(transform);

        markerOur.transform.localPosition += pivotOffset;

        Vector3 translationOur = new Vector3(-markerOurPosition.x * Ratio.x, markerOurPosition.y * Ratio.y, 0f);
        markerOur.transform.localPosition += translationOur;
        Renderer rndr = markerOur.GetComponent<Renderer>();
        rndr.material.color = new Color(0,0,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
