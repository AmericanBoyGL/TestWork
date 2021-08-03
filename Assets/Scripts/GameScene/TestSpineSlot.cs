using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using Spine.Unity.Examples;
using UnityEngine;

public class TestSpineSlot : MonoBehaviour
{
    public Sprite sprite;

    [SpineSlot]
    public string slot;
    
    void Start () {
        var skeletonRenderer = GetComponent<SkeletonRenderer>();
        var anadido = skeletonRenderer.skeleton.AttachUnitySprite(slot, sprite);
    }
}
