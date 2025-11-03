using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
public class Movement0 : MonoBehaviour
{
    InputActions action;

    [SerializeField] private float speed = 4;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rayDist = 5f;
    [SerializeField] private WeaponBehaviour weapon;
    [SerializeField] private GameObject prefap;
    [SerializeField] private AudioClip clip;
    public Transform cameraTransform;
    bool ishidden = true;
    // Update is called once per frame
    private void Awake()
    {
        action = new InputActions();
        action.Enable();
    }
    
    Boolean isfirepressed()
    {
        return action.Player.fire.IsPressed();
        
    }
    private void OnEnable()
    {
        WeaponBehaviour.OnShoot += WeaponBehaviour_OnShoot;
        
    }
    private void OnDisable()
    {
        WeaponBehaviour.OnShoot -= WeaponBehaviour_OnShoot;
        action.Disable();

    }
    private void WeaponBehaviour_OnShoot(int shots)
    {
        Debug.Log(shots);
    }

    private void Update()
    {
        if (isfirepressed())
        {
            Instantiate(prefap);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(TestTime());
        }
        
    }
    void FixedUpdate()
    {

        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            input += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            input += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            input += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            input += Vector3.right;

        input = input.normalized;

        // 🔸 Convert local input to camera-relative direction
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Remove vertical tilt from camera direction
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Combine input with camera direction
        Vector3 moveDirection = cameraForward * input.z + cameraRight * input.x;

        // Apply velocity (keep Y for gravity)
        Vector3 velocity = moveDirection * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

       
    
       
     

        Debug.DrawRay(transform.position, transform.forward * rayDist, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayDist))
        {
            Debug.Log("hit" + hit.collider.name);
            weapon.attack();
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Hello");
            gameObject.SetActive(false);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("do something");
    }
    public IEnumerator TestTime()
    {
        Debug.Log("Start");

        yield return null; // wait 1 frame
        Debug.Log("After 1 frame");

        yield return new WaitForSeconds(3f); // wait 3 seconds
        Debug.Log("After 3 seconds");
        Instantiate(prefap);
        GameManager.Instance.score += 1;
        Debug.Log("Score" + GameManager.Instance.score);
        GameManager.Instance.StartSfx(clip);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);

        yield return new WaitForFixedUpdate(); // wait until next physics update
        Debug.Log("After FixedUpdate");
    }
    public void Speak()
    {
        Debug.Log("hero");
    }
   
}
