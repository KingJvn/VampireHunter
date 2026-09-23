using UnityEngine;
using UnityEngine.InputSystem;

public class Rotator : MonoBehaviour
{
    protected void LookAt(Vector3 target)
    {
        //calculate angle between transform and target
        float lookAngle = AngleBetweenTwoPoints(transform.position, target) + 90;

        //assign the target rotation on the z axis
        transform.eulerAngles = new Vector3(0, 0, lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        
    }
}
