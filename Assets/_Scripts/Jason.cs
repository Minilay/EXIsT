using UnityEngine;

namespace _Scripts
{
    public class Jason : MonoBehaviour
    {
        [Header("Inspector")] 
        [SerializeField] private float speed;
        [SerializeField] private float dashForce;
        [SerializeField] private float startDashTime;

        [Header("Dynamic")] 
        public Rigidbody2D rigid;
        public Vector2 dir; 
        public bool active;
        public bool platformMode;
        public bool isShifting;
        private float _currentDashTime;

        private SpriteRenderer _spr;


        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            active = false;

            _spr = GetComponentInChildren<SpriteRenderer>();
            isShifting = false;
        }

        private void Movement()
        {
            dir = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            ) * speed;

            if (dir.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }


            if (dir.x < 0)
            {
                transform.localScale = Vector3.one;
            }

            rigid.velocity = dir;
        }

        private void Update()
        {
            Control();
        }


        private void Control()
        {
            if (!platformMode && !isShifting)
            {
                Movement();
            }
            else
            {
                rigid.velocity = Vector3.zero;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                isShifting = true;
                _currentDashTime = startDashTime;
                rigid.velocity = Vector2.zero;
            }

            if (Input.GetButtonDown("Jump"))
            {
                active = true;
            }

            if (Input.GetButtonUp("Jump"))
            {
                active = false;
            }

            if (isShifting)
            {
                rigid.velocity = dir.normalized * dashForce;
                _currentDashTime -= Time.deltaTime;

                if (_currentDashTime < 0)
                {
                    isShifting = false;
                }
            }

            _spr.enabled = !platformMode;
        }
    }
}