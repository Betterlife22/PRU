using UnityEngine;
using UnityEngine.Events;

public class DamageBoss : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;
    Animator animator;

    /// <summary>
    /// The max health of the object
    /// </summary>
    [SerializeField]
    private int _maxHealth;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            MaxHealth = value;
        }
    }

    /// <summary>
    /// The current health of the object
    /// </summary>
    [SerializeField]
    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    /// <summary>
    /// Is the object alive
    /// </summary>
    [SerializeField]
    private bool _isAlive = true;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            if (!_isAlive)
            {
                animator.SetBool(AnimationStrings.isAlive, false);
            }
        }
    }

    /// <summary>
    /// Is the object invincible
    /// </summary>
    [SerializeField]
    private bool isInvincible = false;

    /// <summary>
    /// Lock the velocity of the object
    /// </summary>
    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private float timeSinceHit = 0;
    public float invincibilityTimer = 0.2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTimer)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockback);
            return true;
        }
        return false;
    }
}
