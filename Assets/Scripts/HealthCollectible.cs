using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null) {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }

}
