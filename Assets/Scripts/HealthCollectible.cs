using UnityEngine;

public class HealthCollectible : MonoBehaviour {
    
    public int healthIncrease = 1;

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.TryGetComponent<PlayerController>(out var controller) && controller.readOnlyHealth < controller.maxHealth) {
            controller.ChangeHealth(healthIncrease);
            Destroy(gameObject);
        }
    }

}
