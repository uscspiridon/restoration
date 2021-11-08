using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour {
    public static PaintingManager Instance;
    
    private List<GameObject> objectsOnCurrentPainting = new List<GameObject>();

    public List<GameObject> paintings;
    private int currentPainting;

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

    public void NewPainting() {
        // destroy old painting
        while (objectsOnCurrentPainting.Count > 0) {
            Destroy(objectsOnCurrentPainting[0]);
            objectsOnCurrentPainting.RemoveAt(0);
        }
        objectsOnCurrentPainting.Clear();
        
        // spawn new painting
        var newPainting = Instantiate(paintings[currentPainting]);
        objectsOnCurrentPainting.Add(newPainting);
        currentPainting++;
    }
    
    public void AddToPainting(GameObject thing) {
        objectsOnCurrentPainting.Add(thing);
    }
}
