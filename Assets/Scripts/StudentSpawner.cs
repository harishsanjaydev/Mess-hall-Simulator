    using UnityEngine;

    public class StudentSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject studentPrefab;
        [SerializeField] private Transform SpawnPoint; 
        public Student.StudentType studentType;
        [SerializeField]public Transform vegTokenQueue;
        [SerializeField]public Transform nonVegTokenQueue;
        public QueueManager qManager;
        private float timer=0;
       
        
        void Start()
        {     
            
        }

        void Update()

        {
            timer+=Time.deltaTime;
            if (timer > 2)
            {
                GameObject go = Instantiate(studentPrefab,SpawnPoint.position,Quaternion.identity);
                Student student =go.GetComponent<Student>();
                student.studentType = studentType; 
                student.tokenTarget= studentType==Student.StudentType.Veg?vegTokenQueue.position:nonVegTokenQueue.position;
                student.qManager=qManager;
                bool isCutter = Random.value < 0.1f; // 10% chance
                student.isCutter = isCutter;
                timer=0;
            }
            
        }
    }
