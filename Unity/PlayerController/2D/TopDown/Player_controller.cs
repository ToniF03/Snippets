using UnityEngine;

public class Player_controller : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D pRigid;
    Camera MainCamera;

    Vector2 movement;

    float movementSpeed = 5f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        MainCamera = Camera.main;
        pRigid = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        pRigid.MovePosition(pRigid.position + movement * movementSpeed * Time.fixedDeltaTime);
        MainCamera.transform.localPosition = new Vector3(Player.transform.localPosition.x, Player.transform.localPosition.y, -10);
    }
}
