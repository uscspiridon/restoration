using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {
    public static ToolManager Instance;
    
    public enum Tool {
        Sponge,
        Paint
    }
    public Tool currentTool;
    public float paintMaxSpeed;
    public float spongeMinSpeed;

    private Vector3 lastMousePosition;
    private float mouseSpeed;

    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // float newMouseSpeed = (Input.mousePosition - lastMousePosition).magnitude / Time.deltaTime;
        // mouseSpeed = (newMouseSpeed == 0) ? mouseSpeed : newMouseSpeed; // ternary
        // lastMousePosition = Input.mousePosition;
        float newMouseSpeed = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).magnitude;
        mouseSpeed = (newMouseSpeed == 0) ? mouseSpeed : newMouseSpeed; // ternary

        if (currentTool == Tool.Sponge) {
            if (mouseSpeed < spongeMinSpeed) {
                // drip
                Debug.Log("drip drop " + mouseSpeed + " < " + spongeMinSpeed);
            }
            else Debug.Log("not dripping");
        }
        else if (currentTool == Tool.Paint) {
            if (mouseSpeed > paintMaxSpeed) {
                // splatter
                Debug.Log("splatter " + mouseSpeed + " > " + paintMaxSpeed);
            }
            else Debug.Log("not splattering");
        }
        
    }

    public void SwitchTool(string newTool) {
        if (newTool.Equals("Sponge")) currentTool = Tool.Sponge;
        else if (newTool.Equals("Paint")) currentTool = Tool.Paint;
    }

    public float GetMouseSpeed() {
        return mouseSpeed;
    }
}
