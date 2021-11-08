using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Clump : MonoBehaviour {
    public float clicksNeeded;
    
    private float clicksLeft;

    private SpriteRenderer sprite;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start() {
        PaintingManager.Instance.AddToPainting(gameObject);
        clicksLeft = clicksNeeded;
    }

    // Update is called once per frame
    void Update() {
        float a = clicksLeft / clicksNeeded;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && ToolManager.Instance.currentTool == ToolManager.Tool.Chisel) {
            clicksLeft--;
            if(clicksLeft <= 0) Destroy(gameObject);
        }
    }
}
