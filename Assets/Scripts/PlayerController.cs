using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public InputAction MoveAction;
    public InputAction ShootAction;
    public float XRange = 10f;

    public GameObject FoodPrefab;

    private void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        ShootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        var hinput = MoveAction.ReadValue<Vector2>().x;
        transform.Translate(hinput * Speed * Time.deltaTime * Vector3.right);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, 
            -XRange, XRange), transform.position.y, 
            transform.position.z);
        if (ShootAction.triggered)
        {
            Instantiate(FoodPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.white;
        //Gizmos.DrawSphere(transform.position, 1);
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            new Vector3(-XRange, transform.position.y, transform.position.z),
            new Vector3(XRange, transform.position.y, transform.position.z)
            );
    }
}
