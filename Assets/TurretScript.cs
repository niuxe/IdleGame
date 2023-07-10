using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEditor;

public class TurretScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField]
    private float targetRange = 1f;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }
        


    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)
            transform.position, 0f, enemyMask);

        if(hits.Length > 0 )
        {
            target = hits[0].transform;
        }
    }

    private void RotateTorwardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x)
            * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        turretRotationPoint.rotation = targetRotation;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
