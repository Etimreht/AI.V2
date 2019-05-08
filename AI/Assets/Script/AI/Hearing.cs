using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    public GameObject HearingPrefab;
    SphereCollider HearSphere;
    public Transform AItransform;

    public bool PlayerHeard;

    private void Awake()
    {
        Instantiate(HearingPrefab, AItransform.position, AItransform.rotation);
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(AItransform.position, HearingPrefab.GetComponent<SphereCollider>().radius);
        foreach(Collider hit in hits)
        {
            if (hit == GameObject.Find("Player").GetComponent<SphereCollider>())
            {
                PlayerHeard = true;
            }
        }
    }
}
