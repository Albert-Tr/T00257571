using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 2.0f;

    private void Update()
    {
        if (target == null)
        {
            
            return;
        }

        
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0;

        
        Quaternion newRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}