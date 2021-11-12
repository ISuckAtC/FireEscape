using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMap : MonoBehaviour
{
    public GameObject MarkerPrefab;
    public GameObject AxeMarkerPrefab;
    public GameObject ExitMarkerPrefab;
    public GameObject OurSpritePrefab;
    public GameObject AxeSpritePrefab;
    public GameObject ExitSpritePrefab;
    public bool IsSprite;
    public float PlayerMarkerUpdateInterval;
    private Vector2 Ratio;
    private GameObject markerOur;
    private Vector3 pivotOffset;
    private Vector2 planeOffset;
    // Start is called before the first frame update
    void Start()
    {
        Transform groundPlane = GameObject.FindWithTag("Ground").transform;
        pivotOffset = new Vector3(0.5f, -0.5f, 0.55f);
        planeOffset = new Vector2(groundPlane.position.x, groundPlane.position.z) - new Vector2(groundPlane.localScale.x * 10 / 2, groundPlane.localScale.z * 10 / 2);

        Ratio = new Vector2(1f / (groundPlane.localScale.x * 10), 1f / (groundPlane.localScale.z * 10));

        if (IsSprite)
        {
            SpriteRenderer mapSprite = GetComponent<SpriteRenderer>();
            pivotOffset = new Vector3(-mapSprite.sprite.bounds.size.x / 2f, -mapSprite.sprite.bounds.size.y / 2f, 0f);
            Ratio = new Vector2(mapSprite.sprite.bounds.size.x / (groundPlane.localScale.x * 10), mapSprite.sprite.bounds.size.y / (groundPlane.localScale.z * 10));
        }

        GameObject[] axes = GameObject.FindGameObjectsWithTag("Axe");
        for (int i = 0; i < axes.Length; ++i)
        {
            Vector3 axePosition = axes[i].transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
            Vector3 markerAxePosition = new Vector3(axePosition.x, axePosition.z, 0f);
            GameObject markerAxe = Instantiate(IsSprite ? AxeSpritePrefab : AxeMarkerPrefab, transform.position, transform.rotation);
            if (!IsSprite) markerAxe.transform.Rotate(new Vector3(90f, 0, 0));
            markerAxe.transform.SetParent(transform);

            markerAxe.transform.localPosition += pivotOffset;

            Vector3 translationAxe = new Vector3((IsSprite ? markerAxePosition.x : -markerAxePosition.x) * Ratio.x, markerAxePosition.y * Ratio.y, 0f);
            markerAxe.transform.localPosition += translationAxe;
        }

        GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < exits.Length; ++i)
        {
            Vector3 exitPosition = exits[i].transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
            Vector3 markerExitPosition = new Vector3(exitPosition.x, exitPosition.z, 0f);
            GameObject markerExit = Instantiate(IsSprite ? ExitSpritePrefab : ExitMarkerPrefab, transform.position, transform.rotation);
            if (!IsSprite) markerExit.transform.Rotate(new Vector3(90f, 0, 0));
            markerExit.transform.SetParent(transform);

            markerExit.transform.localPosition += pivotOffset;

            Vector3 translationExit = new Vector3((IsSprite ? markerExitPosition.x : -markerExitPosition.x) * Ratio.x, markerExitPosition.y * Ratio.y, 0f);
            markerExit.transform.localPosition += translationExit;
            //markerExit.GetComponent<Renderer>().material.color = new Color(0,1f,0,1f);
        }

        Vector3 ourPosition = GameController.Player.transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
        Vector3 markerOurPosition = new Vector3(ourPosition.x, ourPosition.z, 0f);
        markerOur = Instantiate(IsSprite ? OurSpritePrefab : MarkerPrefab, transform.position, transform.rotation);
        if (!IsSprite) markerOur.transform.Rotate(new Vector3(90f, 0, 0));
        markerOur.transform.SetParent(transform);

        markerOur.transform.localPosition += pivotOffset;

        Vector3 translationOur = new Vector3((IsSprite ? markerOurPosition.x : -markerOurPosition.x) * Ratio.x, markerOurPosition.y * Ratio.y, 0f);

        //Debug.Log(translationOur + " | " + Ratio + " | " + markerOurPosition);

        markerOur.transform.localPosition += translationOur;
        //Renderer rndr = markerOur.GetComponent<Renderer>();
        //rndr.material.color = new Color(0,0,1f,1f);

        InvokeRepeating(nameof(UpdateOurMarker), PlayerMarkerUpdateInterval, PlayerMarkerUpdateInterval);
    }


    void UpdateOurMarker()
    {
        Vector3 ourPosition = GameController.Player.transform.position - new Vector3(planeOffset.x, 0, planeOffset.y);
        Vector3 markerOurPosition = new Vector3(ourPosition.x, ourPosition.z, 0f);

        markerOur.transform.localPosition = pivotOffset;

        Vector3 translationOur = new Vector3((IsSprite ? markerOurPosition.x : -markerOurPosition.x) * Ratio.x, markerOurPosition.y * Ratio.y, 0f);

        markerOur.transform.localPosition += translationOur;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
