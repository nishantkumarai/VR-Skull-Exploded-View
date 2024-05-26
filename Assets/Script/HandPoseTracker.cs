using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseTracker : MonoBehaviour
{
    //getting the hand reference 
    [SerializeField] private HandRef leftHandRef;
    [SerializeField] private HandRef rightHandRef;

    //getting the SkinnedMeshRenderer for visualization 
    [SerializeField] private SkinnedMeshRenderer rightHandRenderer;
    [SerializeField] private SkinnedMeshRenderer leftHandRenderer;

    //choosing the colors for hands when detected.
    [SerializeField] private Color defaultHandColor;
    [SerializeField] private Color poseDetectedHandColor;

    //variable to store the bool value of pose detection
    public bool leftHandPose = false;
    public bool rightHandPose = false;

    // variables to store the position and rotation of the index finger 
    private Pose leftIndexPose;
    private Pose rightIndexPose;


    //property to access the index finger pose
    public Pose LeftIndexPose { get => leftIndexPose; }
    public Pose RightIndexPose { get => rightIndexPose; }

    //variables to store the hand material for visualization
    private Material leftHandMaterial;
    private Material rightHandMaterial;


    private void Awake()
    {
        leftHandMaterial = leftHandRenderer.sharedMaterials[0];
        rightHandMaterial = rightHandRenderer.sharedMaterials[0];
    }

    public void IsLeftHandPoseDetected(bool handPose)
    {
        leftHandPose = handPose;
        if (leftHandPose)
            leftHandMaterial.SetColor("_OutlineColor", poseDetectedHandColor);
        else
            leftHandMaterial.SetColor("_OutlineColor", defaultHandColor);
    }

    public void IsRightHandPoseDetected(bool handPose)
    {
        rightHandPose = handPose;
        if (rightHandPose)
            rightHandMaterial.SetColor("_OutlineColor", poseDetectedHandColor);
        else
            rightHandMaterial.SetColor("_OutlineColor", defaultHandColor);
    }

    private void Update()
    {
        if (!leftHandPose || !rightHandPose)
            return;

        leftHandRef.GetJointPose(HandJointId.HandIndexTip, out leftIndexPose);
        rightHandRef.GetJointPose(HandJointId.HandIndexTip, out rightIndexPose);
    }

    private void OnDisable()
    {
        leftHandMaterial.SetColor("_OutlineColor", defaultHandColor);
        rightHandMaterial.SetColor("_OutlineColor", defaultHandColor);
    }
}