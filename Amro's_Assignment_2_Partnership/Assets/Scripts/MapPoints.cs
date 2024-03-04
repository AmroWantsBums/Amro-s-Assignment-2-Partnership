using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoints : MonoBehaviour
{
    public GameObject Location;
    public GameObject Contraband;
    public float speed;
    public Vector2 Direction;
    public bool On = false;
    public bool Moving = false;
    public VoteController voteController;
    public GameObject[] PossibleMoves;
    public GameObject CurrentLocation;
    public MapPoints mapPointsScript;
    // Start is called before the first frame update
    void Start()
    {
        voteController = GameObject.Find("Canvas").GetComponent<VoteController>();
        Location = gameObject;
        Contraband = GameObject.Find("Contraband");
        CurrentLocation = GameObject.Find("StartPos");
    }

    // Update is called once per frame
    void Update()
    {
        Direction = Location.transform.position - Contraband.transform.position;
        if (!On && Moving)
        {
            if (Direction.magnitude > 0.02f)
            {
                Contraband.transform.position = Vector2.MoveTowards(Contraband.transform.position, Location.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Moving = false;
                On = false;
            }
        }
    }

    public void ClickedOn()
    {
        if (voteController.VoteTime)
        {
            
            if (voteController.PlayerOneTurn == true)
            {
                mapPointsScript = CurrentLocation.GetComponent<MapPoints>();
                GameObject[] PossibleLocations = mapPointsScript.PossibleMoves;
                foreach (GameObject f in PossibleLocations)
                {
                    if (gameObject == f)
                    {
                        Debug.Log("Possible Move");
                        voteController.PlayerOneVote = gameObject;
                        voteController.PlayerOneTurn = false;
                    }
                    else
                    {
                        Debug.Log("Impossible Move");
                    }
                }
            }
            else
            {
                mapPointsScript = CurrentLocation.GetComponent<MapPoints>();
                GameObject[] PossibleLocations = mapPointsScript.PossibleMoves;
                foreach (GameObject f in PossibleLocations)
                {
                    if (gameObject == f)
                    {
                        Debug.Log("Possible Move");
                        voteController.PlayerTwoVote = gameObject;
                        voteController.VoteTime = false;

                        if (voteController.PlayerTwoVote == voteController.PlayerOneVote)
                        {
                            if (!Moving)
                            {
                                Moving = true;
                                CurrentLocation = voteController.PlayerOneVote;
                            }
                        }
                        else
                        {
                            Destroy(voteController.PlayerTwoVote);
                            Destroy(voteController.PlayerOneVote);
                        }
                    }
                    else
                    {
                        Debug.Log("Impossible Move");
                    }
                }                
            }
        }
    }
}
