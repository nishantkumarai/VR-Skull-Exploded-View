using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedViewController : MonoBehaviour
{
    //getting the animator of the 3D model
    [SerializeField] private Animator _animator;


    //getting the HandPoseTracker to access the index finger pose
    private HandPoseTracker handPoseTracker;

    // to store the distance value between the two index finger 
    private float indexFingerDistance;

    // to store the initial animation clip
    private AnimationClip defaultAnimationClip;

    // to override the existing controller
    private AnimatorOverrideController overrideController;

    private void Start()
    {
        handPoseTracker = FindObjectOfType<HandPoseTracker>();
        defaultAnimationClip = _animator.runtimeAnimatorController.animationClips[0];
        overrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
    }

    private void Update()
    {
        if (!handPoseTracker.leftHandPose || !handPoseTracker.rightHandPose)
        {
            if (_animator.enabled)
                _animator.enabled = false;
            return;
        }

        if (!_animator.enabled)
        {
            _animator.enabled = true;
            ResetAnimation();
        }

        indexFingerDistance = Vector3.Distance(handPoseTracker.LeftIndexPose.position, handPoseTracker.RightIndexPose.position);
        _animator.SetFloat("AnimationPosition", indexFingerDistance);
    }

    private void ResetAnimation()
    {
        var animations = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        animations.Add(new KeyValuePair<AnimationClip, AnimationClip>(overrideController.animationClips[0], defaultAnimationClip));
        overrideController.ApplyOverrides(animations);
        _animator.runtimeAnimatorController = overrideController;
    }
}
