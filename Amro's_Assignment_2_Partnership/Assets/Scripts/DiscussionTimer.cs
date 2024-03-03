using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscussionTimer : MonoBehaviour
{
    public TextMeshProUGUI TimeTxt;
    public int Timer;
    public float Interval;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interval < 1)
        {
            Interval = Interval + Time.deltaTime;
        }
        else
        {
            Interval = 0;
            Timer--;
            TimeTxt.text = $"Decide on your next destination. You have {Timer} seconds left";
        }
    }
}
