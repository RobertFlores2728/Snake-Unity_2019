using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instanceGA; // instance for GameAssets class used to reference at runtime

    /*PREFABS*/
    public GameObject snakePrefab;
    public GameObject snakeTailPrefab;
    public GameObject applePrefab;


    //Awake is called when the script instance is being loaded.
    private void Awake()
    {
        instanceGA = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
