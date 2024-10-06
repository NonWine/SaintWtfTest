using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Animations/PickUpTween")]
public class PickUpAnimationTween : ScriptableObject
{
    public float Duration;
    public float JumpStrenght;
    public int JumpCount;
    public Ease Ease;
}