using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fade : MonoBehaviour {
    // public variables
    public float maxMouseSpeed;
    public float paintTime;
    public float minOpacity;
    
    // state variables
    private float paintTimer;
    
    // component stuff
    private SpriteRenderer sprite;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start() {
        PaintingManager.Instance.AddToPainting(gameObject);
        paintTimer = paintTime;
    }

    // Update is called once per frame
    void Update() {
        float a = paintTimer / paintTime;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
        if (a <= minOpacity) {
            Debug.Log("a = " + a + " and minOpacity = " + minOpacity);
            Destroy(gameObject);
        }
    }

    private void OnMouseOver() {
        if (ToolManager.Instance.currentTool == ToolManager.Tool.Paint && ToolManager.Instance.GetMouseSpeed() < maxMouseSpeed) {
            Debug.Log("paint timer = " + paintTimer);
            paintTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Fade")) {
            Destroy(gameObject);
        }
    }
}
