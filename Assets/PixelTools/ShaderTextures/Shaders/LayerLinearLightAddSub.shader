Shader "Unlit/LayerLinearLightAddSub"
{
    Properties
    {
        _BaseMap("Texture", 2D) = "white" {}
        _BlendMap("Blend", 2D) = "white" {}
        _MaskMap("Mask", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            // No culling or depth
            Cull Off ZWrite Off ZTest Always

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _BaseMap;
                sampler2D _BlendMap;
                sampler2D _MaskMap;
                float4 _Color;

                float4 Unity_Blend_LinearLightAddSub_float4(float4 Base, float4 Blend, float Opacity)
                {
                    float4 output = Blend + 2.0 * Base - 1.0;
                    output = lerp(Base, output, Opacity);
                    return output;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                fixed4 base = tex2D(_BaseMap, i.uv);
                fixed4 blend = tex2D(_BlendMap, i.uv) * _Color;
                fixed mask = tex2D(_MaskMap, i.uv).r * blend.a;
                return Unity_Blend_LinearLightAddSub_float4(base, blend, mask);
                }
                ENDCG
            }
        }
}
