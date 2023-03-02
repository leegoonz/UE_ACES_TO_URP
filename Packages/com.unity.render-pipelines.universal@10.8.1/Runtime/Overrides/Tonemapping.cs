using System;

namespace UnityEngine.Rendering.Universal
{
    public enum TonemappingMode
    {
        None,
        Neutral, // Neutral tonemapper
        ACES,    // ACES Filmic reference tonemapper (custom approximation)
        /////////////////UE4_ACES_BEGIN///////////////
        UE4_ACES,
        /////////////////UE4_ACES_END/////////////////
    }
    [Serializable, VolumeComponentMenu("Post-processing/Tonemapping")]
    public sealed class Tonemapping : VolumeComponent, IPostProcessComponent
    {
        [Tooltip("Select a tonemapping algorithm to use for the color grading process.")]
        public TonemappingModeParameter mode = new TonemappingModeParameter(TonemappingMode.None);
        
        /////////////////UE4_ACES_BEGIN/////////////////
        //create floatParameter
        /// This is only used when <see cref="Tonemapper.UE4_ACES"/> is active.
        [Tooltip("Film_Slope")]
        public ClampedFloatParameter slope = new ClampedFloatParameter(0.88f, 0f, 1f);
        /// This is only used when <see cref="Tonemapper.UE4_ACES"/> is active.
        [Tooltip("Film_Toe")]
        public ClampedFloatParameter toe = new ClampedFloatParameter(0.55f, 0.0f, 1.0f);
        /// This is only used when <see cref="Tonemapper.UE4_ACES"/> is active.
        [Tooltip("Film_Shoulder")]
        public ClampedFloatParameter shoulder = new ClampedFloatParameter(0.26f, 0.0f, 1.0f);
        /// This is only used when <see cref="Tonemapper.UE4_ACES"/> is active.
        [Tooltip("Film_BlackClip")]
        public ClampedFloatParameter blackClip = new ClampedFloatParameter(0.0f, 0.0f, 1.0f);
        /// This is only used when <see cref="Tonemapper.UE4_ACES"/> is active.
        [Tooltip("Film_WhiteClip")]
        public ClampedFloatParameter whiteClip = new ClampedFloatParameter(0.04f, 0.0f, 1.0f);
        /////////////////UE4_ACES_END/////////////////        

        public bool IsActive() => mode.value != TonemappingMode.None;

        public bool IsTileCompatible() => true;
    }
    [Serializable]
    public sealed class TonemappingModeParameter : VolumeParameter<TonemappingMode> { public TonemappingModeParameter(TonemappingMode value, bool overrideState = false) : base(value, overrideState) { } }
}
