    using UnityEngine;

    public class Student : MonoBehaviour
    {
        private Animator animator;
        public enum StudentType { Veg, NonVeg }
        public StudentType studentType;
        [SerializeField] private float speed;
        [SerializeField] public Vector3 tokenTarget;
        public QueueManager qManager;
        
        public CounterManagement CManager;
        private bool hasJoinedQueue = false;
        private bool hasJoinedCounter =false;
        public bool isCutter = false;
        public bool isSeated = false;
        private SpriteRenderer sr;
        public string idleDirection = "IdleUp";
        public bool headingToSeat = false;
        void Start()
        {
            animator=GetComponent<Animator>();
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
            if (headingToSeat && Vector3.Distance(transform.position, tokenTarget) < 0.1f)
            {
            isSeated = true;
            headingToSeat = false;
            }
            UpdateAnimation();

        }
        void UpdateAnimation()
        {
         Vector3 direction = tokenTarget - transform.position;
    
        if (isSeated) 
        {
            animator.Play(idleDirection);
            return;
        }
        if (direction.magnitude < 0.1f)
        {
            animator.Play("IdleUp");
            return;
        }
    
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            animator.Play("WalkRight");
        else
            animator.Play("WalkLeft");
        }
        else
        {
            if (direction.y > 0)
            animator.Play("WalkUp");
        else
            animator.Play("WalkDown");
        }
        }
    }
