    using UnityEngine;

    public class Student : MonoBehaviour
    {
        public enum StudentType { Veg, NonVeg }
        public StudentType studentType;
        [SerializeField] private float speed;
        [SerializeField] public Vector3 tokenTarget;
        public QueueManager qManager;
        
        public CounterManagement CManager;
        private bool hasJoinedQueue = false;
        private bool hasJoinedCounter =false;
        public bool isCutter = false;
        private SpriteRenderer sr;
        void Start()
        {
           sr=GetComponent<SpriteRenderer>();
        if (isCutter)
        {
            sr.color=Color.magenta;
        } 
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(
            transform.position,
            tokenTarget,
            speed * Time.deltaTime);
            if (!hasJoinedQueue && Vector3.Distance(transform.position, tokenTarget) < 0.1f)
            {
                    hasJoinedQueue=true;
                    qManager.JoinQueue(this,isCutter);
                          
            }
            if (hasJoinedQueue && !hasJoinedCounter && CManager!=null&&Vector3.Distance(transform.position, tokenTarget) < 0.1f)
            {
                hasJoinedCounter = true;
                CManager.JoinCounter(this);
            }

        }
    }
