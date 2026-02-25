using UnityEngine;

public class AimTarget : MonoBehaviour
{
    [SerializeField]private Transform parent;

    [SerializeField] private float lerpTime;
    [SerializeField] private float lerpMultiplier;
    
    public void TargetFalling()
    {
        while (lerpTime < 1)
        {
            lerpTime += Time.deltaTime * lerpMultiplier;
            float fallingAngle = Mathf.Lerp(0, 90, lerpTime);
            parent.rotation = Quaternion.Euler(fallingAngle, 0, 0);
        }
    }
}
