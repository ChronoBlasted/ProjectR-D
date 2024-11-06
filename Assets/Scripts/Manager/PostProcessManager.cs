using BaseTemplate.Behaviours;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : MonoSingleton<PostProcessManager>
{
    [SerializeField] PostProcessVolume volume;
    [SerializeField] Color vignetteColorPriest, vignetteColorDemon;

    Vignette vignette;
    DepthOfField doe;
    LensDistortion lensDistortion;
    Bloom bloom;
    ChromaticAberration chromaticAberration;
    Grain grain;

    public void Init()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out doe);
        volume.profile.TryGetSettings(out lensDistortion);
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out chromaticAberration);
        volume.profile.TryGetSettings(out grain);
    }

    public void SetToDemon(float duration = .2f)
    {
        DOVirtual.Color(vignette.color, vignetteColorDemon, duration, x => vignette.color.value = x);
    }

    public void SetToPriest(float duration = .2f)
    {
        DOVirtual.Color(vignette.color, vignetteColorPriest, duration, x => vignette.color.value = x);
    }

    public IEnumerator DoTransformationEffect(float duration)
    {
        SetDistortion(-40f, duration / 2f);
        SetDoe(1f, duration / 2f);
        SetChromaticAberration(.5f, duration / 2f);
        SetGrain(.5f, duration / 2f);
        SetBloom(30f, duration / 2f);

        yield return new WaitForSeconds(duration / 2f);


        yield return new WaitForSeconds(duration / 4f);

        SetDistortion(-80, duration / 4f);

        yield return new WaitForSeconds(duration / 4f);

        SetDistortion(0);

        SetDoe(100);
        SetBloom(0);
        SetChromaticAberration(0);
        SetGrain(0);
    }


    #region Utils
    public void SetDoe(float newDepthOfField, float duration = .2f) // Around 1 is good // def : 100
    {
        DOVirtual.Float(doe.focusDistance, newDepthOfField, duration, x => doe.focusDistance.value = x);
    }

    public void SetDistortion(float newDistortion, float duration = .2f) // Around -70 is good // def :  0
    {
        DOVirtual.Float(lensDistortion.intensity, newDistortion, duration, x => lensDistortion.intensity.value = x);
    }

    public void SetBloom(float newBloom, float duration = .2f) // Around 30 is good // def : 0
    {
        bloom.enabled.value = true;

        DOVirtual.Float(bloom.intensity, newBloom, duration, x => bloom.intensity.value = x).OnComplete(() =>
        {
            if (bloom.intensity <= 0)
            {
                bloom.enabled.value = false;
            }
        });
    }

    public void SetChromaticAberration(float newChromaticAberation, float duration = .2f) // Around .5f is good // def : 0
    {
        DOVirtual.Float(chromaticAberration.intensity, newChromaticAberation, duration, x => chromaticAberration.intensity.value = x);
    }

    public void SetGrain(float newGrain, float duration = .2f) // Around .5f is good // def : 0
    {
        DOVirtual.Float(grain.intensity, newGrain, duration, x => grain.intensity.value = x);
    }
    #endregion
}

