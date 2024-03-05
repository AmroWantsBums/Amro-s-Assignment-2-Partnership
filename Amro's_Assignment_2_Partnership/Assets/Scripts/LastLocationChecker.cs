using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLocationChecker : MonoBehaviour
{
    public MapPoints mapPointsScript;
    public GameObject Parent;
    public GameObject[] Locations;
    public GameObject StartPos;
    public List<GameObject> Locations = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mapPointsScript = StartPos.GetComponent<MapPoints>();
        GameObject[] PossibleLocations = mapPointsScript.PossibleMoves;

        // Check if there's only one remaining option
        if (PossibleLocations.Length == 1)
        {
            GameObject lastLocation = PossibleLocations[0];
            foreach (GameObject obj in Locations)
            {
                var MapScript = obj.GetComponent<MapPoints>();
                MapScript.CurrentLocation = lastLocation;
            }
        }
    }
}
