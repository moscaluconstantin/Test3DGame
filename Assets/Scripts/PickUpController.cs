using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
     public Weapon weaponScript;
     public Rigidbody rb;
     public BoxCollider coll;
     public Transform player, weaponContainer;

     public float pickUpRange;
     public float dropForwardForce, dropUpwardForce;

     public bool equipped;
     public static bool slotFull;

     private void Start()
     {
          if (!equipped)
               SetWeaponBasicState(false);
          else
               SetWeaponBasicState(true);
     }
     private void Update()
     {
          Vector3 distanceToPlayer = player.position - transform.position;

          if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
               PickUp();

          if (equipped && Input.GetKeyDown(KeyCode.Q))
               Drop();

     }

     private void PickUp()
     {
          equipped = true;
          slotFull = true;

          transform.SetParent(weaponContainer);
          transform.localPosition = Vector3.zero;
          transform.localRotation = Quaternion.Euler(Vector3.zero);
          transform.localScale = Vector3.one;

          SetWeaponBasicState(true);
     }
     private void Drop()
     {
          equipped = false;
          slotFull = false;

          transform.SetParent(null);

          SetWeaponBasicState(false);

          //rb.velocity = player.GetComponent<Rigidbody>().velocity;
          rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
          rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);

          float random = Random.Range(-1f, 1f);
          rb.AddTorque(new Vector3(random, random, random) * 10);
     }
     private void SetWeaponBasicState(bool state)
     {
          rb.isKinematic = state;
          coll.isTrigger = state;
          weaponScript.enabled = state;
     }
}
