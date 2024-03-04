using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLocationChecker : MonoBehaviour
{
    public MapPoints mapPointsScript;
    public GameObject Parent;
    public GameObject[] Locations;
    public GameObject StartPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        mapPointsScript = StartPos.GetComponent<MapPoints>();
        GameObject[] PossibleLocations = mapPointsScript.PossibleMoves;
        Debug.Log(PossibleLocations.Length);
        for (int i = 0; i < PossibleLocations.Length; i++)
        {
            //Debug.Log($"{NoOfItems} available options");
            mapPointsScript.Location = PossibleLocations[i]; 
            foreach (GameObject f in Locations)
            {
                var MapScript = f.GetComponent<MapPoints>();
                MapScript.CurrentLocation = PossibleLocations[i];
            }
        }
    }
}
