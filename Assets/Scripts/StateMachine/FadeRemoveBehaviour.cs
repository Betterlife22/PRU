using UnityEngine;

public class FadeRemoveBehaviour : StateMachineBehaviour
{
    public float fadeTime = 0.5f;
    private float timeLapse = 0.0f;
    SpriteRenderer spriteRenderer;
    GameObject gameObject;
    Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeLapse = 0.0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        gameObject = animator.gameObject;


    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeLapse += Time.deltaTime;

        float newAlpha = startColor.a * (1 - (timeLapse / fadeTime));

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
        
        if(timeLapse > fadeTime)
        {
            Destroy(gameObject);
        }
    }
}
