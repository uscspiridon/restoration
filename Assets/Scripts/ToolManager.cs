using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {
    public static ToolManager Instance;
    
    public enum Tool {
        Sponge,
        Brush
    }
    public Tool currentTool;

    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTool(string newTool) {
        if (newTool.Equals("Sponge")) currentTool = Tool.Sponge;
        else if (newTool.Equals("Brush")) currentTool = Tool.Brush;
    }
}
