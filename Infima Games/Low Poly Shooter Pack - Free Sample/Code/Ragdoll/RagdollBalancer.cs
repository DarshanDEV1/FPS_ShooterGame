using System.Collections;
using UnityEngine;

public class RagdollBalancer : MonoBehaviour
{
    private CharacterJoint[] _joints;
    private void Awake()
    {
        _joints = GetComponentsInChildren<CharacterJoint>();
    }
    private void Start()
    {
        CharacterJoints(true);
    }

    public void CharacterDeath()
    {
        CharacterJoints(false);
    }

    public IEnumerator CharacterHurted()
    {
        CharacterJoints(false);
        yield return new WaitForSeconds(.5f);
        CharacterJoints(true);
    }

    private void CharacterJoints(bool _value)
    {
        foreach (CharacterJoint joint in _joints)
        {
            Rigidbody _rb = joint.GetComponent<Rigidbody>();
            _rb.freezeRotation = _value;
        }
    }
}