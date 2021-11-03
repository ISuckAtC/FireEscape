using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float SpreadRate;
    [Range(0, 100)]
    public float SpreadChance;
    public float SpreadVelocity;
    public int MaxFlame;
    public float Lifetime;
    public GameObject FirePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
        InvokeRepeating(nameof(Spread), SpreadRate, SpreadRate);
    }

    void Spread()
    {
        if (Random.Range(0f, 100f) < SpreadChance)
        {
            GameObject newFire = Instantiate(FirePrefab, transform.position, Quaternion.identity);
            Vector3 startingVelocity = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;
            Debug.Log(startingVelocity);
            newFire.GetComponent<Rigidbody>().AddForce(startingVelocity * SpreadVelocity, ForceMode.VelocityChange);

            RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(0.15f, 0.15f, 0.15f), Vector3.forward, Quaternion.identity, 0.01f, 1 << LayerMask.NameToLayer("Fire"), QueryTriggerInteraction.Ignore);
            if (hits.Length > MaxFlame)
            {
                hits = hits.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
                for (int i = 0; i < MaxFlame; ++i) Destroy(hits[i].transform.gameObject);
            }
        }
    }
}
