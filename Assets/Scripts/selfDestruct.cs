﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); //todo allow customisation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
