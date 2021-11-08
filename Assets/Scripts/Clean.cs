using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        PaintingManager.Instance.AddToPainting(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        if(ToolManager.Instance.currentTool == ToolManager.Tool.Sponge) Destroy(gameObject);
    }
}
