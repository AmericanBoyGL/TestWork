using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using Spine.Unity.Examples;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSpineController : MonoBehaviour
{
    private SkeletonAnimation _mySkeletonAnimation;
    private int _countWrongAnswear = 0;
    private AudioClip welcomeClip;
    
    [SpineAnimation] 
    public string idleAnimationName;
    [SpineAnimation] 
    public string correctAnimationName;
    [SpineAnimation] 
    public string wrongAnimationName;
    [SpineAnimation] 
    public string sadAnimationName;
    [SpineAnimation] 
    public string tapAnimationName;
    
    private void Start()
    {
        _mySkeletonAnimation = GetComponent<SkeletonAnimation>();
        
        _mySkeletonAnimation.Skeleton.SetAttachment("Tail", null);
        
        AudioManager.PlaySound(welcomeClip);
    }

    public void Init(AudioClip clip, Button animalBtn)
    {
        welcomeClip = clip;
        animalBtn.onClick.AddListener(delegate{ PlayAnimationAnimal(tapAnimationName); });
    }

    public void PlayAnimation(bool isCorrect)
    {
        if (isCorrect)
        {
            _mySkeletonAnimation.AnimationState.SetAnimation(0, correctAnimationName, true);
        }
        else
        {
            _countWrongAnswear++;
            if (_countWrongAnswear > 2)
            {
                _mySkeletonAnimation.AnimationState.SetAnimation(0, sadAnimationName, false);
                _mySkeletonAnimation.AnimationState.AddAnimation(0, idleAnimationName, false, 1f);
            }
            else
            {
                _mySkeletonAnimation.AnimationState.SetAnimation(0, wrongAnimationName, false);
                _mySkeletonAnimation.AnimationState.AddAnimation(0, idleAnimationName, false, 1f);
            }
        }
    }

    public void ActivateSlotChanger(Sprite spr = null)
    {
        ChangeTail(spr);
    }

    private void PlayAnimationAnimal(string animName)
    {
        _mySkeletonAnimation.AnimationState.SetAnimation(0, animName, false);
        _mySkeletonAnimation.AnimationState.AddAnimation(0, idleAnimationName, false, 1f);
    }

    private void ChangeTail(Sprite spr = null)
    {
         var slot = _mySkeletonAnimation.Skeleton.FindSlot("Tail");
         slot.Skeleton.SetToSetupPose();
         var oldAttachment = slot.Attachment; 
         var mat = oldAttachment.GetMaterial();
         var newAttachment = oldAttachment.GetRemappedClone(spr, mat, pivotShiftsMeshUVCoords: false, useOriginalRegionSize: false);
         slot.Attachment = newAttachment;
    }
}
