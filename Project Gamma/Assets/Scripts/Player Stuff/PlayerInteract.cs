﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    private Health health;

    void Awake () {
        health = GetComponent<Health>();
    }

    void OnCollisionStay (Collision other) {
        if (other.gameObject.CompareTag("Button"))
        {
            if (other.gameObject.GetComponent<ActivateFollowTarget>() && other.gameObject.GetComponent<ActivateFollowTarget>().type == ActivateFollowTarget.Type.floor)
            {
                other.gameObject.GetComponent<ActivateFollowTarget>().Activate(); // Activates the button
            }
            if (other.gameObject.GetComponent<ActivateFallOnActivate>() && other.gameObject.GetComponent<ActivateFallOnActivate>().type == ActivateFallOnActivate.Type.floor)
            {
                other.gameObject.GetComponent<ActivateFallOnActivate>().Activate(); // Activates the button
            }
            if (other.gameObject.GetComponent<ActivateGameObject>() && other.gameObject.GetComponent<ActivateGameObject>().type == ActivateGameObject.Type.floor)
            {
                other.gameObject.GetComponent<ActivateGameObject>().Activate(); // Activates the button
            }
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Hazard")) 
        {
            health.Damage();
        }
    }

    void OnTriggerStay (Collider other) {
        if (other.CompareTag("Hazard")) 
        {
            health.Damage();
        }
        if (other.CompareTag("Weak Point") && !transform.Find("Spin Detection").gameObject.activeSelf) {
            other.GetComponentInParent<Health>().Damage();
        }
    }
}
