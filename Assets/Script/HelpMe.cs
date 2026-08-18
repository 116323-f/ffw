using UnityEngine;
using UnityEngine.InputSystem;

public class MouseProgress : MonoBehaviour
{
    private SpriteRenderer sr;
    private Material mat;
    private Camera cam;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mat = sr.material;
        cam = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mouseScreen);

        Vector3 localMouse = transform.InverseTransformPoint(mouseWorld);

        float left = sr.localBounds.min.x;
        float right = sr.localBounds.max.x;

        float progress = Mathf.InverseLerp(left, right, localMouse.x);

        mat.SetFloat("_Progress", Mathf.Clamp01(progress));
    }
}