using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoteController : MonoBehaviour
{
    public DiscussionTimer discussionTimer;
    public TextMeshProUGUI TurnTxt;
    public GameObject VotePnl;
    public GameObject PlayerOneVote;
    public GameObject PlayerTwoVote;
    public bool PlayerOneTurn;
    public bool VoteTime = false;
    public bool PlayerTwoTurn = false;
    public bool PanelShowed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (discussionTimer.Timer == 0 && !PlayerOneTurn && !PlayerTwoTurn)
        {
            VoteTime = true;
            PlayerOneTurn = true;
            VotePnl.SetActive(true);
            PlayerTwoTurn = true;
            TurnTxt.text = $"Player 1, Hide the screen then press ready to make your vote";
        }
        if (VoteTime && !PlayerOneTurn && PlayerTwoTurn && !PanelShowed)
        {
            VotePnl.SetActive(true);
            PanelShowed = true;
            TurnTxt.text = $"Player 2, Hide the screen then press ready to make your vote";
        }
    }

    public void ReadyClick()
    {
        VotePnl.SetActive(false);
    }
}
