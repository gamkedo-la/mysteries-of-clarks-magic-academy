using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProcgenProps : MonoBehaviour
{
    [Header("Drag prefabs here")]
    public List<GameObject> prefabList;

    [Header("Generation Settings")]
    [Range(0,100)]
    public int fullness = 75;
    [Range(0,100)]
    public int messiness = 25;
    [Range(1,25)]
    public int cols = 10;
    [Range(1,25)]
    public int rows = 4;

    [Header("Prefab Size Randomness")]
    public Vector3 minScale = new Vector3(0.8f,0.8f,0.8f);
    public Vector3 maxScale = new Vector3(1f,1f,1f);
    public Vector3 minSpacing = new Vector3(0.1f,1f,0f);
    public Vector3 maxSpacing = new Vector3(0.2f,1f,0f);
    private bool needToGenerate = false;
    
    // run when a value is changed in the editor inspector
    void OnValidate()
    {
        needToGenerate = true; // unity bug if we generate during this event
    }

    void Update()
    {
        if (needToGenerate) Generate(); // safe to run
        needToGenerate = false;
    }

    void Start()
    {
        Generate(); // safe to run here too
    }

    void removeOldPrefabs() { // unity feels buggy here: not all get removed...

        Debug.Log("removing old books in bookshelf");
        foreach (Transform child in transform) {
            // edit mode requires the use of this... hmmmm
            GameObject.DestroyImmediate(child.gameObject);
            //GameObject.Destroy(child.gameObject);
        }

    }

    void Generate() {
        Debug.Log("generating a "+cols+"x"+rows+" bookshelf that's "+
            fullness + "% full and " + messiness + "% messy.");

        removeOldPrefabs();
        removeOldPrefabs();
        removeOldPrefabs();
        removeOldPrefabs();

        for (int row=0; row<rows; row++) {
            
            float dist = 0f; // running total for varied spacing

            for (int col=0; col<cols; col++) {             
                
                Debug.Log("book "+col+","+row+" dist:"+dist);
                
                if (Random.value*100 < fullness) { // fill this spot?

                    // choose one randomly
                    int prefabIndex = Random.Range(0,prefabList.Count);
                    // create new prefab
                    GameObject clone = Instantiate(prefabList[prefabIndex], new Vector3(0f,0f,0f), Quaternion.identity);
                    
                    // be a child of this object for less runtime mess
                    // unity bug: can't do this anymore! wtf unity
                    clone.transform.SetParent(transform);
                    
                    // varying size
                    clone.transform.localScale = new Vector3(
                        Random.Range(minScale.x,maxScale.x),
                        Random.Range(minScale.y,maxScale.y),
                        Random.Range(minScale.z,maxScale.z));

                    // place it it in the next spot
                    clone.transform.localPosition = new Vector3(
                        dist,
                        row*maxSpacing.y,
                        Random.Range(0f,maxSpacing.z));
                    
                    // example for if we need to rotate the meshes
                    //clone.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

                }

            dist += Random.Range(minSpacing.x,maxSpacing.x);

            } // cols

        } // rows
        
    }

}