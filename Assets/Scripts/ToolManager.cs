using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToolManager : MonoBehaviour {
    public static ToolManager Instance;
    
    public enum Tool {
        Sponge,
        Paint,
        Chisel,
    }
    public Tool currentTool;
    public float paintMaxSpeed;
    public float spongeMinSpeed;
    public float dripTime;
    public GameObject fadePrefab;
    public GameObject clumpPrefab;
    public float clumpSpawnRadius;
    // public float splatterTime;

    private Vector3 lastMousePosition;
    private float mouseSpeed;
    private float dripTimer;
    private bool splattered;
    // private float splatterTimer;

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
                // drip, create a fade
                dripTimer -= Time.deltaTime;
                if (dripTimer <= 0) {
                    dripTimer = dripTime;
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
                    Instantiate(fadePrefab, spawnPosition, Quaternion.identity);
                }
                Debug.Log("drip drop " + mouseSpeed + " < " + spongeMinSpeed);
            }
            else {
                Debug.Log("reset drip timer");
                dripTimer = 0;
            }
        }
        else if (currentTool == Tool.Paint) {
            if (mouseSpeed > paintMaxSpeed) {
                // splatter
                if (!splattered) {
                    splattered = true;
                    // determine random position
                    Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                    randomDirection.Normalize();
                    randomDirection *= clumpSpawnRadius;
                    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + randomDirection;
                    spawnPos.z = 0;
                    Clump newClump = Instantiate(clumpPrefab, spawnPos, Quaternion.identity).GetComponent<Clump>();
                    newClump.clicksNeeded = Random.Range(2, 5); // 2, 3, or 4
                }
                // Debug.Log("splatter " + mouseSpeed + " > " + paintMaxSpeed);
            }
            else {
                splattered = false;
            }
            // else Debug.Log("not splattering");
        }
        else if (currentTool == Tool.Chisel) {
            // fade the paint when u chisel on empty space
            
        }
        
    }

    public void SwitchTool(string newTool) {
        if (newTool.Equals("Sponge")) currentTool = Tool.Sponge;
        else if (newTool.Equals("Paint")) currentTool = Tool.Paint;
        else if (newTool.Equals("Chisel")) currentTool = Tool.Chisel;
    }

    public float GetMouseSpeed() {
        return mouseSpeed;
    }
}
