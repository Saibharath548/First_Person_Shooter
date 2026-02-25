using UnityEngine;

public class ActiveRagdollDriver : MonoBehaviour
{
    [System.Serializable]
    public class BoneMuscle
    {
        public Transform animatedBone;
        public ConfigurableJoint joint;
    }

    public BoneMuscle[] muscles;

    public Transform animatedRigRoot;   // Animated rig root
    public Rigidbody hips;              // Physics hips RB
    public float uprightTorque = 500f;

    private void Start()
    {
        MatchRagdollToAnimation();
    }

    void FixedUpdate()
    {
        foreach (var m in muscles)
        {
            Quaternion jointSpace =
                Quaternion.Inverse(m.joint.connectedBody.rotation) * m.joint.transform.rotation;

            Quaternion target =
                Quaternion.Inverse(jointSpace) *
                Quaternion.Inverse(m.joint.connectedBody.rotation) *
                m.animatedBone.rotation;

            m.joint.targetRotation = target;
        }

        ApplyUprightTorque();
    }

    void ApplyUprightTorque()
    {
        Vector3 torque = Vector3.Cross(hips.transform.up, Vector3.up);
        hips.AddTorque(torque * uprightTorque);
    }

    void LateUpdate()
    {
        animatedRigRoot.position = hips.position;
        animatedRigRoot.rotation = hips.rotation;
    }

    void MatchRagdollToAnimation()
    {
        foreach (var m in muscles)
        {
            m.joint.transform.position = m.animatedBone.position;
            m.joint.transform.rotation = m.animatedBone.rotation;

            Rigidbody rb = m.joint.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        hips.position = animatedRigRoot.position;
        hips.rotation = animatedRigRoot.rotation;
        hips.linearVelocity = Vector3.zero;
        hips.angularVelocity = Vector3.zero;
    }

}