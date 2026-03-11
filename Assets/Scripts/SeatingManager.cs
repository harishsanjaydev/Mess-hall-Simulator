using UnityEngine;
using System.Collections.Generic;

public class SeatingManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public seat GetRandomSeat(string tag)
    {
        seat[] allseats=FindObjectsByType<seat>(FindObjectsSortMode.None);
        List<seat> freeSeats =new List<seat>();
        foreach(seat s in allseats)
        {
            if(!s.isOccupied && s.gameObject.CompareTag(tag))
            {
                freeSeats.Add(s);
                if (s.isUnderFan)
                {
                freeSeats.Add(s);
                freeSeats.Add(s);
                }
        }
        }
        if (freeSeats.Count==0) return null;
        int randomIndex=Random.Range(0,freeSeats.Count);
        return freeSeats[randomIndex]; 
    }
}
