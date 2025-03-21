using UnityEngine;

public class RandomAttackSelector : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int attackType = Random.Range(0, 2); // Random 0 hoặc 1
        animator.SetInteger("attackType", attackType);
    }
}
