using UnityEngine;
using System.Collections.Generic;

public class SeatingManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetRandomSeat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public seat GetRandomSeat()
    {
        seat[] allseats=FindObjectsByType<seat>(FindObjectsSortMode.None);
        List<seat> freeSeats =new List<seat>();
        foreach(seat s in allseats)
        {
            if(!s.isOccupied)
                freeSeats.Add(s);
        }
        if (freeSeats.Count==0) return null;
        int randomIndex=Random.Range(0,freeSeats.Count);
        return freeSeats[randomIndex]; 
    }
}
