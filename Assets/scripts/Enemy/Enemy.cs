using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _maxVelocity;
    [Range(0f, 1f)]
    [SerializeField] protected float _maxForce;
    protected Vector3 _velocity;
    public Vector3 Velocity { get { return _velocity; } }
    [SerializeField] private float life = 3f;
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private float dissolveSpeed = 1f;
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Renderer enemyRenderer;
    [SerializeField] private ParticleSystem explotionPS;
    [SerializeField] private ParticleSystem sparksPS;
    private bool isDying = false;

   
    protected virtual void Awake()
    {
        if (explotionPS != null)
        {
            explotionPS.Stop(); 
            sparksPS.Stop(); 
        }
    }

    protected virtual void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        originalMaterial = enemyRenderer.material;

        _velocity = Vector3.zero;
    }

    protected virtual void Update()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            StartCoroutine(DissolveAndDestroy());
        }
    }

    private IEnumerator DissolveAndDestroy()
    {
        isDying = true;
        enemyRenderer.material = Instantiate(dissolveMaterial);
        Material currentDissolveMaterial = enemyRenderer.material;

        float dissolveValue = 0f;
        currentDissolveMaterial.SetFloat("_DissolveAmount", dissolveValue);

        
        if (explotionPS != null)
        {
            explotionPS.Play(); 
            sparksPS.Play(); 
        }

        while (dissolveValue < 1f)
        {
            dissolveValue += Time.deltaTime * dissolveSpeed;
            currentDissolveMaterial.SetFloat("_DissolveAmount", dissolveValue);
            yield return null;
        }

        Destroy(gameObject);
    }

    public void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }
}