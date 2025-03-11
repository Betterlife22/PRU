using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;
    private Rigidbody2D rb;
    Coroutine knockbackCoroutine;
    AnimationCurve knockbackForceCurve;
    public bool IsGettingKnockback { get; private set; }

    public IEnumerator KnockbackAction (Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsGettingKnockback = true;

        Vector2 _hitForce;
        Vector2 _constanseForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;
        float _time = 0f;

        _constanseForce = constantForceDirection * constForce;

        float _eslapsedTime = 0f;
        while (_eslapsedTime < knockbackTime)
        {
            _hitForce = hitDirection * hitDirectionForce * knockbackForceCurve.Evaluate(_time);

            _eslapsedTime += Time.fixedDeltaTime;
            _time += Time.fixedDeltaTime;
            _knockbackForce = _hitForce + _constanseForce;

            if (inputDirection != 0)
            {
                _combinedForce = _knockbackForce + new Vector2(inputDirection, 0f);
            }
            else
            {
                _combinedForce = _knockbackForce;
            }

            rb.linearVelocity = _combinedForce;
            yield return new WaitForFixedUpdate();
        }
        IsGettingKnockback = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        knockbackCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }
}
