using UnityEngine.Rendering.Universal;

namespace UnityEditor.Rendering.Universal
{
    [VolumeComponentEditor(typeof(Tonemapping))]
    sealed class TonemappingEditor : VolumeComponentEditor
    {
        SerializedDataParameter m_Mode;
        
        /////////////////UE4_ACES_BEGIN/////////////////
        SerializedDataParameter m_Slope;
        SerializedDataParameter m_Toe;
        SerializedDataParameter m_Shoulder;
        SerializedDataParameter m_BlackClip;
        SerializedDataParameter m_WhiteClip;
        /////////////////UE4_ACES_END/////////////////

        public override void OnEnable()
        {
            var o = new PropertyFetcher<Tonemapping>(serializedObject);

            m_Mode = Unpack(o.Find(x => x.mode));
            /////////////////UE4_ACES_BEGIN/////////////////
            m_Slope = Unpack(o.Find(x => x.slope));
            m_Toe = Unpack(o.Find(x => x.toe));
            m_Shoulder = Unpack(o.Find(x => x.shoulder));
            m_BlackClip = Unpack(o.Find(x => x.blackClip));
            m_WhiteClip = Unpack(o.Find(x => x.whiteClip));
            /////////////////UE4_ACES_END///////////////////

        }

        public override void OnInspectorGUI()
        {
            PropertyField(m_Mode);
            /////////////////UE4_ACES_BEGIN/////////////////
            if ( m_Mode.value.intValue == (int)TonemappingMode.UE4_ACES)
            {
                UnityEngine.GUILayout.BeginVertical("box");
                UnityEngine.GUILayout.BeginHorizontal();

                PropertyField(m_Slope);
                if (UnityEngine.GUILayout.Button("Reset"))
                {
                    m_Slope.value.floatValue = 0.88f;
                }
                UnityEngine.GUILayout.EndHorizontal();

                UnityEngine.GUILayout.BeginHorizontal();
                PropertyField(m_Toe);
                if (UnityEngine.GUILayout.Button("Reset"))
                {
                    m_Toe.value.floatValue = 0.55f;
                }
                UnityEngine.GUILayout.EndHorizontal();

                UnityEngine.GUILayout.BeginHorizontal();
                PropertyField(m_Shoulder);
                if (UnityEngine.GUILayout.Button("Reset"))
                {
                    m_Shoulder.value.floatValue = 0.26f;
                }
                UnityEngine.GUILayout.EndHorizontal();

                UnityEngine.GUILayout.BeginHorizontal();
                PropertyField(m_BlackClip);
                if (UnityEngine.GUILayout.Button("Reset"))
                {
                    m_BlackClip.value.floatValue = 0.0f;
                }
                UnityEngine.GUILayout.EndHorizontal();

                UnityEngine.GUILayout.BeginHorizontal();
                PropertyField(m_WhiteClip);
                if (UnityEngine.GUILayout.Button("Reset"))
                {
                    m_WhiteClip.value.floatValue = 0.04f;
                }
                UnityEngine.GUILayout.EndHorizontal();
                UnityEngine.GUILayout.EndVertical();

            }
            /////////////////UE4_ACES_END////////////////////

            // Display a warning if the user is trying to use a tonemap while rendering in LDR
            var asset = UniversalRenderPipeline.asset;
            if (asset != null && !asset.supportsHDR)
            {
                EditorGUILayout.HelpBox("Tonemapping should only be used when working in HDR.", MessageType.Warning);
                return;
            }
        }
    }
}
