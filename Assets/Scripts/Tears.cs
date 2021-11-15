using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tears : MonoBehaviour
{
    public float TearSpeed = 1f;
    public GameObject WipingHand;
    public GameObject TearsObject;
    public float HandSpeed = 1f;
    public float HandDistance = 1f;
    public float HandFadeTime = 1f;
    public KeyCode WipeKey = KeyCode.Space;
    public Vector2 HandWipeDrag;
    private Vector3 handStartPosition;

    private bool wiping;
    public bool tearing;
    private Image handSprite;
    private Image tearsSprite;
    // Start is called before the first frame update
    void Start()
    {
        handStartPosition = WipingHand.transform.position;
        handSprite = WipingHand.GetComponent<Image>();
        tearsSprite = TearsObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tearing && !wiping)
        {
            Color c = tearsSprite.color;
            c.a += TearSpeed * Time.deltaTime;
            tearsSprite.color = c;
        }
        if (!wiping && Input.GetKeyDown(WipeKey))
        {
            StartCoroutine(Wipe());
        }
    }

    public IEnumerator Wipe()
    {
        wiping = true;
        {
            Color c = handSprite.color;
            c.a = 1f;
            handSprite.color = c;
        }
        Vector3 handTargetPosition = handStartPosition + new Vector3(HandWipeDrag.x, HandWipeDrag.y, 0f);
        while (Vector3.Distance(WipingHand.transform.position, handTargetPosition) > 0)
        {
            WipingHand.transform.position = Vector3.MoveTowards(WipingHand.transform.position, handTargetPosition, HandSpeed * Time.deltaTime);
            if (tearsSprite.color.a > 0)
            {
                Color c = tearsSprite.color;
                c.a -= Time.deltaTime;
                tearsSprite.color = c;
            }
            yield return null;
        }
        while (handSprite.color.a > 0)
        {
            Color c = handSprite.color;
            c.a -= Time.deltaTime / HandFadeTime;
            handSprite.color = c;
            yield return null;
        }
        Color sc = tearsSprite.color;
        sc.a = 0f;
        tearsSprite.color = sc;
        WipingHand.transform.position = handStartPosition;
        wiping = false;
    }
}
