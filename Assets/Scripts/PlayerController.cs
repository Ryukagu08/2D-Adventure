using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  // Variables related to player character movement
  public InputAction MoveAction;
  Rigidbody2D rigidbody2d;
  Vector2 move;
  public float speed = 3.0f;


  // Variables related to the health system
  public int maxHealth = 5;
  int currentHealth = 1;


  // Start is called before the first frame update
  void Start() {
     MoveAction.Enable();
     rigidbody2d = GetComponent<Rigidbody2D>();
     //currentHealth = maxHealth;
  }
 
  // Update is called once per frame
  void Update() {
     move = MoveAction.ReadValue<Vector2>();
  }


  // FixedUpdate has the same call rate as the physics system
  void FixedUpdate() {
     Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
     rigidbody2d.MovePosition(position);
  }


  public void ChangeHealth (int amount) {
     currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
     Debug.Log(currentHealth + "/" + maxHealth);
  }


}
