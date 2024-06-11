using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    [SerializeField] private float openDuration;
    [SerializeField] private float closeDuration;
    

    public virtual void Open()
    {
        StartAnimation(AnimationType.In);
    }

    public virtual BaseScreen Close()
    {
        StartAnimation(AnimationType.Out);
        return this;
    }

    protected void StartAnimation(AnimationType type)
    {

    }
}

public enum AnimationType
{
    In,
    Out
}