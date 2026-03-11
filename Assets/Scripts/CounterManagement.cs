using UnityEngine;
using System.Collections.Generic;

public class CounterManagement : MonoBehaviour
{
    [SerializeField]private Transform NVplate;
    [SerializeField]private Transform NVfood;
    [SerializeField]private Transform NVextras;
    [SerializeField]public Transform queueStartpoint;
    private bool stop1Occupied=false;
    private bool Stop2Occupied=false;
    private bool Stop3Occupied=false;

    private Student StudentatStop1;
    private Student StudentatStop2;
    private Student StudentatStop3;
    
    private List<Student> Waitingq=new List<Student>();
    private float spacing = 0.8f;
    private float stopTimer = 0f;
    private float stopDuration = 2f;
    public string seatTag;
    public SeatingManager seatManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StudentatStop1==null && StudentatStop2==null && StudentatStop3 == null)
        {
            return;
        }
        stopTimer+=Time.deltaTime;
        if (stopTimer >= stopDuration)
        {
            stopTimer=0;
            AdvanceStudents();
        }
        
    }
    public void JoinCounter(Student student)
    {
        Waitingq.Add(student);
        if (!stop1Occupied)
        {
            MovetoStop1(student);
        }
        else{
        int index = Waitingq.Count-1;
        Vector3 slotPosition = queueStartpoint.position - new Vector3(0,index*spacing,0);
        student.tokenTarget=slotPosition;}
    }
    public void MovetoStop1(Student student)
    {
        stop1Occupied=true;
        StudentatStop1=student;
        Waitingq.RemoveAt(0);
        student.tokenTarget=NVplate.position;
    }
    void ShiftQueue()
{
    for (int i = 0; i < Waitingq.Count; i++)
    {
        Vector3 slotPosition = queueStartpoint.position - new Vector3(0, i * spacing, 0);
        Waitingq[i].tokenTarget = slotPosition;
    }
}
    public void AdvanceStudents()
    {
         
        if (StudentatStop3 != null)
        {
            seat Seatv = seatManager.GetRandomSeat(seatTag);
            if (Seatv != null)
            {
                Seatv.isOccupied=true;
                StudentatStop3.tokenTarget=Seatv.transform.position;
            }
            StudentatStop3 = null;
            StudentatStop3=null;
           
        }
        if (StudentatStop2 != null&& StudentatStop3==null)
        {
            StudentatStop3=StudentatStop2;
            StudentatStop2=null;
            StudentatStop3.tokenTarget=NVextras.position;
        }
        if(StudentatStop1!=null && StudentatStop2==null)
        {
            StudentatStop2=StudentatStop1;
            StudentatStop1=null;
            StudentatStop2.tokenTarget=NVfood.position;
        }
        if (StudentatStop1 == null && Waitingq.Count > 0)
        {
        MovetoStop1(Waitingq[0]);
        ShiftQueue();
        }
        Debug.Log($"Stop1:{stop1Occupied} Stop2:{Stop2Occupied} Stop3:{Stop3Occupied}");
    }
    
}
