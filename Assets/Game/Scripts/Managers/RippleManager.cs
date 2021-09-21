using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RippleTypes
{
    GREY_BURST,
    RED_BURST
}

public class RipplePreset
{
    public AnimationCurve Waveform;
    public float RefractionStrength;
    public Color RefelctionColor;
    public float RefelctionStrength;
    public float WaveSpeed;
    public float DropInterval;
}

[RequireComponent(typeof(RippleEffect))]
public class RippleManager : MonoBehaviour
{
    public static RippleManager instance;
    private RippleEffect _effect;
    private RipplePreset RED_Burst;
    private RipplePreset Grey_Burst;

    private void Start()
    {
        instance = this;
        _effect = GetComponent<RippleEffect>();
        CreatePresets();
    }

    public void Ripple(RippleTypes _type, Vector3 position)
    {
        switch (_type)
        {
            case RippleTypes.GREY_BURST:
                SetValuesToPreset(Grey_Burst);
                break;

            case RippleTypes.RED_BURST:
                SetValuesToPreset(RED_Burst);
                break;
        }
        _effect.Ripple(position);
    }

    private void CreatePresets()
    {
        RED_Burst = new RipplePreset()
        {
            Waveform = new AnimationCurve
            (
                new Keyframe(0.00f, 0.50f, 0, 0),
                new Keyframe(0.05f, .52f, 0, 0),
                new Keyframe(0.15f, 0.10f, 0, 0),
                new Keyframe(0.25f, 0.80f, 0, 0),
                new Keyframe(0.35f, 0.30f, 0, 0),
                new Keyframe(0.45f, 0.60f, 0, 0),
                new Keyframe(0.55f, 0.40f, 0, 0),
                new Keyframe(0.65f, 0.55f, 0, 0),
                new Keyframe(0.75f, 0.46f, 0, 0),
                new Keyframe(0.85f, 1.00f, 0, 0),
                new Keyframe(0.99f, 0.50f, 0, 0)
            ),
            RefelctionStrength = .9f,
            RefelctionColor = Color.red,
            RefractionStrength = .9f,
            WaveSpeed = 1.1f,
            DropInterval = .97f,
        };

        Grey_Burst = new RipplePreset()
        {
            Waveform = new AnimationCurve
            (
                new Keyframe(0.00f, 0.50f, 0, 0),
                new Keyframe(0.05f, 1.00f, 0, 0),
                new Keyframe(0.15f, 0.10f, 0, 0),
                new Keyframe(0.25f, 0.80f, 0, 0),
                new Keyframe(0.35f, 0.30f, 0, 0),
                new Keyframe(0.45f, 0.60f, 0, 0),
                new Keyframe(0.55f, 0.40f, 0, 0),
                new Keyframe(0.65f, 0.55f, 0, 0),
                new Keyframe(0.75f, 0.46f, 0, 0),
                new Keyframe(0.85f, 0.52f, 0, 0),
                new Keyframe(0.99f, 0.50f, 0, 0)
            ),
            RefelctionStrength = .75f,
            RefelctionColor = Color.grey,
            RefractionStrength = .9f,
            WaveSpeed = 1.1f,
            DropInterval = .97f,
        };
    }

    private void SetValuesToPreset(RipplePreset _preset)
    {
        _effect.waveform = _preset.Waveform;
        _effect.refractionStrength = _preset.RefractionStrength;
        _effect.reflectionColor = _preset.RefelctionColor;
        _effect.reflectionStrength = _preset.RefelctionStrength;
        _effect.waveSpeed = _preset.WaveSpeed;
        _effect.dropInterval = _preset.DropInterval;
    }
}