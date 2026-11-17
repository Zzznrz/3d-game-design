using UnityEngine;
using UnityEngine.InputSystem;

public class MapExplorer : MonoBehaviour
{
    public Transform body;
    public Camera followCamera;
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float turnSpeed = 120f;

    private CharacterController controller;
    private Transform head;
    private float yaw;
    private float pitch = 8f;
    private float verticalSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        yaw = transform.eulerAngles.y;
        head = body.Find("Head");

        var eyeMaterial = new Material(head.GetComponent<Renderer>().sharedMaterial);
        eyeMaterial.color = Color.black;
        for (var i = 0; i < 2; i++)
        {
            var eye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            eye.name = i == 0 ? "Left Eye" : "Right Eye";
            eye.transform.SetParent(head, false);
            eye.transform.localPosition = new Vector3(i == 0 ? -0.2f : 0.2f, 0.1f, 0.44f);
            eye.transform.localScale = Vector3.one * 0.17f;
            eye.GetComponent<Renderer>().material = eyeMaterial;
            Destroy(eye.GetComponent<Collider>());
        }
    }

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        var mouse = Mouse.current;
        if (mouse != null && mouse.rightButton.isPressed)
        {
            var delta = mouse.delta.ReadValue();
            yaw += delta.x * 0.15f;
            pitch = Mathf.Clamp(pitch - delta.y * 0.15f, -15f, 55f);
        }

        var turn = (keyboard.dKey.isPressed ? 1f : 0f) - (keyboard.aKey.isPressed ? 1f : 0f);
        yaw += turn * turnSpeed * Time.deltaTime;
        var forward = (keyboard.wKey.isPressed ? 1f : 0f) - (keyboard.sKey.isPressed ? 1f : 0f);
        var direction = Quaternion.Euler(0f, yaw, 0f) * Vector3.forward * forward;
        var speed = keyboard.leftShiftKey.isPressed ? runSpeed : walkSpeed;
        if (controller.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -1f;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        controller.Move((direction * speed + Vector3.up * verticalSpeed) * Time.deltaTime);

        body.rotation = Quaternion.Euler(0f, yaw, 0f);
        head.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void LateUpdate()
    {
        if (followCamera == null)
            return;

        var rotation = Quaternion.Euler(pitch, yaw, 0f);
        var target = transform.position + Vector3.up * 1.2f;
        followCamera.transform.position = target - rotation * Vector3.forward * 3.5f + rotation * Vector3.right * 0.6f;
        followCamera.transform.LookAt(target + Quaternion.Euler(0f, yaw, 0f) * Vector3.forward * 2f);
    }
}
