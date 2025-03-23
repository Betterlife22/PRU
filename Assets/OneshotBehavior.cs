using UnityEngine;

public class OneshotBehavior : StateMachineBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 1f;
    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;  // Renamed playerAfterDelay to playAfterDelay
    public float playDelay = 0.25f;

    private float timeSinceEntered = 0;
    private bool hasDelayedSoundPlayed = false;
    private AudioSource audioSource;  // Reference to AudioSource component

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get or add AudioSource component to the GameObject
        audioSource = animator.gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = animator.gameObject.AddComponent<AudioSource>();
        }

        // Configure AudioSource
        audioSource.clip = soundToPlay;
        audioSource.volume = volume;
        audioSource.loop = false;

        if (playOnEnter)
        {
            audioSource.Play();
        }
        timeSinceEntered = 0f;
        hasDelayedSoundPlayed = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelayedSoundPlayed)
        {
            timeSinceEntered += Time.deltaTime;
            if (timeSinceEntered > playDelay)
            {
                audioSource.Play();
                hasDelayedSoundPlayed = true;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the sound when exiting the state
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (playOnExit)
        {
            audioSource.Play();
        }
    }
}