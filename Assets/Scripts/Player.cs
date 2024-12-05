using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private Rigidbody2D rig;


    private float initialSpeed;
    private Vector2 _direction;
    private bool _isRunning;




    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
  

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;

    }

    private void Update()
    {
        onInput();
        OnRun();
    }
    private void FixedUpdate()
    {
       OnMove();
    }



    #region Moviment

    void onInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    #endregion
}