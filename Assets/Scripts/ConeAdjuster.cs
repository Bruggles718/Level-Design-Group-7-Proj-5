using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeAdjuster : MonoBehaviour
{
    [SerializeField] private Light sl;
    [SerializeField] private Transform cone;
    [SerializeField] private GameObject coneFilter;
    // Start is called before the first frame update
    void Start()
    {
        // tan(theta) * h = r
        // 2r = d
        float coneBase = GetBase();
        cone.localScale = new Vector3(coneBase, sl.range, coneBase);
        //Debug.Log(coneBase);

    }

    // Update is called once per frame
    void Update()
    {
        float coneBase = GetBase();
        cone.localScale = new Vector3(coneBase, sl.range, coneBase);
        //Debug.Log(coneBase);
    }

    float GetBase()
    {
        return (Mathf.Tan(Mathf.Deg2Rad * (sl.spotAngle / 2)) * sl.range) * 2;
    }
}
