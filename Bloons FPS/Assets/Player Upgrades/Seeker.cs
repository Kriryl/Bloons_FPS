using UnityEngine;

public class Seeker : MonoBehaviour
{
    public float seekSpeed = 1f;

    private ParticleSystem _particleSystem;
    public Transform target;
    private BloonType[] bloonTypes;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void LateUpdate()
    {
        bloonTypes = FindObjectsOfType<BloonType>();

        ParticleSystem.Particle[] emittedParticles = new ParticleSystem.Particle[_particleSystem.particleCount];
        _particleSystem.GetParticles(emittedParticles);
        int aliveParticles = emittedParticles.Length;

        for (int i = 0; i < aliveParticles; i++)
        {
            ParticleSystem.Particle particle = emittedParticles[i];
            FindNearestBloon(particle);
            if (target)
            {
                Vector3 directionTotarget = (target.position - particle.position).normalized;
                Vector3 seekForce = directionTotarget * seekSpeed * Time.deltaTime;
                particle.velocity += seekForce;
            }
            emittedParticles[i] = particle;
        }

        _particleSystem.SetParticles(emittedParticles, aliveParticles);
    }

    private void FindNearestBloon(ParticleSystem.Particle particle)
    {
        if (!target)
        {
            float distance = float.MaxValue;

            foreach (BloonType bloon in bloonTypes)
            {
                if (Vector3.Distance(bloon.transform.position, particle.position) < distance)
                {
                    distance = Vector3.Distance(bloon.transform.position, particle.position);
                    target = bloon.transform;
                }
            }
        }
    }
}
