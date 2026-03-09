using UnityEngine;
using System.Collections.Generic;

public class QueueManager : MonoBehaviour
{   private float spacing =0.6f;
    private float TotalChecktime=2f;    
    private float Timer=0f;
    private List<Student> queue = new List<Student>();
    public CounterManagement cManager;
    [SerializeField] private Transform Entrance;
    void Start()
    {
        
    }

    
    void Update()
    {    
    
        if (queue.Count == 0) return;
        Timer+=Time.deltaTime;
        if (Timer >= TotalChecktime)
        {   
            Student first =queue[0];
            queue.RemoveAt(0);
            first.tokenTarget=Entrance.position;
            first.CManager=cManager;
            Timer=0;
            for (int i = 0; i < queue.Count; i++)
            {
                
                Vector3 slotPosition = transform.position - new Vector3(0, i * spacing, 0);
                queue[i].tokenTarget = slotPosition;
                }
            
        }
    }
    public void JoinQueue(Student student)
    {
        queue.Add(student);
        Debug.Log(student.studentType + " student joined queue! Total: " + queue.Count);
        int index = queue.Count-1;
        Vector3 slotPosition = transform.position - new Vector3(0,index*spacing,0);
        student.tokenTarget=slotPosition;
    }
}
