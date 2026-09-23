using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotationSpeed = 440f;
    protected void RotateToward(Vector3 target)
    {
        float targetAngle = AngleBetweenTwoPoints(transform.position, target) + 90f; //calculate final target angle

        float currentAngle = transform.eulerAngles.z; // get current Z rotation

        float step = rotationSpeed * Time.deltaTime;
        float nextAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, step); //smoothly move current angle to target angle

        transform.eulerAngles = new Vector3(0, 0, nextAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
