using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : CharacterController
{
    [SerializeField]
    ProjectileMovementComponent projectile;

    public float walkSpeed = 5f;
    private Vector2 moveInput;

    private Vector2 attackRotation = new Vector2(1,0);
    [SerializeField]
    private bool _isMoving = false;

    [SerializeField]
    private bool _isRunning = false;

    [SerializeField]
    private ActionComponent ActionComp;
    private AttributeComponent attributeComponent;
    private Rigidbody2D rb;
    Animator animator;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.IsRunning, value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attributeComponent = GetComponent<AttributeComponent>();
        ActionComp = GetComponent<ActionComponent>();
        ActionComp.Owner = this;

        ActionComp.OwnerInfo = rb;
        //capsuleCollider = GetComponent<CapsuleCollider2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log(capsuleCollider.name);
        //Debug.Log(rb.name);
        InvokeRepeating("PrimaryAttack", 1f, 1f);
        Debug.Log(ActionComp.ActionList.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity =new Vector2(moveInput.x * walkSpeed * Time.fixedDeltaTime,
            moveInput.y * walkSpeed * Time.fixedDeltaTime);
        if (moveInput.x!=0 || moveInput.y !=0 ) 
            attackRotation = moveInput;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (moveInput.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        //Debug.Log(moveInput.x + " " + moveInput.y);

    }

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.IsMoving, value);
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            IsRunning = true;
            walkSpeed += 200;
        }
        else if (context.canceled)
        {
            IsRunning = false;
            walkSpeed -= 200;

        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            //animator.Play("Player_Attack_1",0);
            animator.SetTrigger(AnimationStrings.AttackTrigger);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        AttributeComponent attributeComp = collision.gameObject.GetComponent<AttributeComponent>(); ;

        if (attributeComp != null)
        {
            attributeComp.ApplyHealthChanged(this, attributeComp, 50);
        }
    }

    void PrimaryAttack()
    {
        
    }
}
