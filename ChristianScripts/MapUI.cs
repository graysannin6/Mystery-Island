﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    
    public RectTransform playerInMap;
    public RectTransform map2dEnd;
    public Transform map3dParent;
    public Transform map3dEnd;
    public GameObject map;
    private Vector3 normalized, mapped;
    private GameManager manager;

    private void Start()
    {
        map.SetActive(false);
        manager = GameManager.instance;
    }

    private void Update()
    {
        normalized = Divide(
                map3dParent.InverseTransformPoint(this.transform.position),
                map3dEnd.position - map3dParent.position
            );
        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
        playerInMap.localPosition = mapped;
    }

    private static Vector3 Divide(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            map.SetActive(true);
            manager.canMoveE = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            map.SetActive(false);
            manager.canMoveE = true;
        }
    }
}
