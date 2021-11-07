using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMap : MonoBehaviour
{
    public GameObject MarkerPrefab;
    public Vector2 Ratio;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pivotOffset = new Vector3(0.5f, -0.5f, 0.55f);

        GameObject[] axes = GameObject.FindGameObjectsWithTag("Axe");
        for (int i = 0; i < axes.Length; ++i)
        {
            Vector3 axePosition = axes[i].transform.position;
            Vector3 markerAxePosition = new Vector3(axePosition.x, axePosition.z, 0f);
            GameObject markerAxe = Instantiate(MarkerPrefab, transform.position, transform.rotation);
            markerAxe.transform.Rotate(new Vector3(90f, 0, 0));
            markerAxe.transform.SetParent(transform);

            markerAxe.transform.localPosition += pivotOffset;

            Vector3 translationAxe = new Vector3(-markerAxePosition.x * Ratio.x, markerAxePosition.y * Ratio.y, 0f);
            markerAxe.transform.localPosition += translationAxe;
        }

        Vector3 ourPosition = transform.position;
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
