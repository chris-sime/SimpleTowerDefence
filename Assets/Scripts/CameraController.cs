using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool lockCursor = true;

    public float panSpeed = 5f;
    public float panBorderThickness = 20f;
    public float scrollSpeed = 5f;
    public float scrollMin = 10f;
    public float scrollMax = 80f;

    // Update is called once per frame
    void Update () {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
            lockCursor = !lockCursor;

        if (!lockCursor)
            return;
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, scrollMin, scrollMax);
        transform.position = position;

    }
}
