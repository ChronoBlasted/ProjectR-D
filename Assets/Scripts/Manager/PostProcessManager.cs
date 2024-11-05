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

    public void SetToDemon()
    {
        DOVirtual.Color(vignette.color, vignetteColorPriest, .2f, x => vignette.color.value = x);
    }

    public void SetToPriest()
    {
        DOVirtual.Color(vignette.color, vignetteColorDemon, .2f, x => vignette.color.value = x);
    }

    public IEnumerator DoTransformationEffect(float duration)
    {
        SetDoe(1);
        SetDistortion(-50);
        SetBloom(30);
        SetChromaticAberration(.5f);
        SetGrain(.5f);

        yield return new WaitForSeconds(duration);

        SetDoe(100);
        SetDistortion(0);
        SetBloom(0);
        SetChromaticAberration(0);
        SetGrain(0);
    }


    #region Utils
    public void SetDoe(float newDepthOfField) // Around 1 is good // def : 100
    {
        DOVirtual.Float(doe.focusDistance, newDepthOfField, .2f, x => doe.focusDistance.value = x);
    }

    public void SetDistortion(float newDistortion) // Around -50 is good // def :  0
    {
        DOVirtual.Float(lensDistortion.intensity, newDistortion, .2f, x => lensDistortion.intensity.value = x);
    }

    public void SetBloom(float newBloom) // Around 30 is good // def : 0
    {
        DOVirtual.Float(bloom.intensity, newBloom, .2f, x => bloom.intensity.value = x);
    }

    public void SetChromaticAberration(float newChromaticAberation) // Around .5f is good // def : 0
    {
        DOVirtual.Float(chromaticAberration.intensity, newChromaticAberation, .2f, x => chromaticAberration.intensity.value = x);
    }

    public void SetGrain(float newGrain) // Around .5f is good // def : 0
    {
        DOVirtual.Float(grain.intensity, newGrain, .2f, x => grain.intensity.value = x);
    }
    #endregion
}

