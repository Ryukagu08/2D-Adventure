using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

   public InputAction MoveAction; // Player Movements
   Rigidbody2D rigidbody2d;
   Vector2 move;
   public float speed = 3.0f;

   public int maxHealth = 5; // Health System
   int currentHealth;
   public int readOnlyHealth { get { return currentHealth; }} // Read Only Current Health

   public float timeInvincible = 1.0f; // Damage Cooldown For Hazards
   bool isInvincible;
   float damageCooldown;


   void Start() { // Rb Assigned Movement
      MoveAction.Enable();
      rigidbody2d = GetComponent<Rigidbody2D>();
      currentHealth = maxHealth;
   }
 
   void Update() {
      move = MoveAction.ReadValue<Vector2>(); // Movement Input

      if (isInvincible) { // Invincibility Timer
         damageCooldown -= Time.deltaTime;
         if (damageCooldown < 0) {
            isInvincible = false;
         }
      }
   }

   void FixedUpdate() {
      Vector2 position = rigidbody2d.position + move * speed * Time.deltaTime; // Movement Speed
      rigidbody2d.MovePosition(position);
   }


   public void ChangeHealth (int amount) {   // Health Updating
      if (amount < 0) {
         if (isInvincible) {
            return;
         }
         isInvincible = true;
         damageCooldown = timeInvincible;
      }

      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
      Debug.Log(currentHealth);
   }


}
