/*
* Author: Liu GuangXuan
* Date: 15/06/2025
* Description: Applies damage to the player when they enter the hazard trigger.
*/

using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 1; // Amount of damage dealt on trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>(); // Try to get PlayerHealth script
            if (hp != null)
            {
                hp.TakeDamage(damage); // Apply damage
            }
        }
    }
}
