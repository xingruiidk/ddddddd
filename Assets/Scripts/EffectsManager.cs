using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleFlash;

    private void PlayParticle(ParticleSystem effect, Vector3 position)
    {
        var particleEffect = Instantiate(effect);
        particleEffect.transform.position = position;
        particleEffect.Play();

        StartCoroutine(WaitBeforeDisabling());

        IEnumerator WaitBeforeDisabling()
        {
            yield return new WaitForSeconds(particleEffect.main.duration + particleEffect.main.startLifetime.constant);
            particleEffect.gameObject.SetActive(false);
        }
    }
}
