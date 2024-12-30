using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private Rigidbody2D rig;


    private float initialSpeed;
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isRoling;
    private bool _isCuting;
    private bool _isDiging;
    private bool _isWatering;
    private int handlingobj;



    public bool isRoling
    {
        get { return _isRoling; }
        set { _isRoling = value; }
    }

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
    public bool isCuting
    {
        get { return _isCuting; }
        set { _isCuting = value; }
    }
    public bool isDiging
    {
        get { return _isDiging; }
        set { _isDiging = value; }
    }
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingobj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            handlingobj = 2;

        }
        if (Input.GetKeyDown (KeyCode.Alpha0))
        {
            handlingobj = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingobj = 3;
        }

        switch (handlingobj)
        {

            case 1:
                OnCut(); 
                break;
            case 2:
                onDig();
                break;
            case 3:
                onWatering();
                break;

            default:
                
                break;
        }

        onInput();
        OnRun();
        OnRoll();  
       
        
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

    void OnRoll()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _isRoling = true;
           
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRoling = false;
           
        }
    }
    void OnCut()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCuting = true;
            speed = 0;


        }
        if (Input.GetMouseButtonUp(0))
        {
            _isCuting = false;
            speed = initialSpeed;

        }
    }
    void onDig()
    {
        if(Input.GetMouseButtonDown (0))
        {
            _isDiging = true;
            speed = 0;
        }
        if (Input.GetMouseButtonUp (0))
        {
            _isDiging = false;
            speed = initialSpeed;
        }
    }
    void onWatering()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWatering = true;
            speed = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isWatering = false;
            speed = initialSpeed;
        }
    }

    #endregion
}