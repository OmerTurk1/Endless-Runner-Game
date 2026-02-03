Shader "UI/RadialFadeToBlack"
{
    Properties
    {
        _Color("Color", Color) = (0,0,0,1)
        _Center("Fade Center (X,Y)", Vector) = (0.5, 0.5, 0, 0)
        _Radius("Fade Radius", Float) = 0.5
        _Smoothness("Fade Smoothness", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="True" "PreviewType"="Plane" "CanUseSpriteAtlas"="False" }
        LOD 100

        Pass
        {
            Cull Off
            Lighting Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float2 _Center;
            float _Radius;
            float _Smoothness;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float dist = distance(uv, _Center);
                
                // Merkez saydam, kenarlar opak olacak þekilde tersle
                float alpha = smoothstep(_Radius - _Smoothness, _Radius, dist);

                return fixed4(_Color.rgb, alpha * _Color.a);
            }
            ENDCG
        }
    }
}
