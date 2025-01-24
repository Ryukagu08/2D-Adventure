using UnityEngine;

public class DamageZone : MonoBehaviour {

    public int healthDecrease = -1;

    void OnTriggerStay2D(Collider2D other) {
        
        if (other.TryGetComponent<PlayerController>(out var controller)) {
            controller.ChangeHealth(healthDecrease);
        }
    }
}
