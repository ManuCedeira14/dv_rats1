
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpController : Controller, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] bool canJump = false;
    [SerializeField] float _jumpForce;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 1f;
    private bool isInitialized = false;
    void Start()
    {
        if (playerRb == null)
        {
            playerRb = GetComponent<Rigidbody>();
        }
        StartCoroutine(InitializePlayer());
    }

    IEnumerator InitializePlayer()
    {
        
        while (RemoteConfigExample.Instance == null || RemoteConfigExample.Instance.jumpForce == 0)
        {
            yield return null;  
        }

        
        _jumpForce = RemoteConfigExample.Instance.jumpForce;

        isInitialized = true;  
    }

    void Update()
    {
        if (!isInitialized) return;  
        CheckGroundDistance();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public override Vector3 GetJump()
    {
        return Vector3.up * _jumpForce;
    }

    public override Vector3 GetMovement()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        if (canJump)
        {
            playerRb.AddForce(GetJump(), ForceMode.Impulse);
        }
    }

    private void CheckGroundDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(playerRb.position, checkDistance, groundLayer);

        if (colliders.Length > 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
}