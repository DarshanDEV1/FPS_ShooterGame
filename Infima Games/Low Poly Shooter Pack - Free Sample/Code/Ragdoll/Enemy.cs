using UnityEngine;

public class Enemy : MonoBehaviour
{
    public RagdollBalancer _ragdoll;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            _ragdoll.CharacterDeath();
            //Debug.Log("Hurted...");
        }
        //Debug.Log(collision.collider.tag + collision.collider.name);
    }
}
