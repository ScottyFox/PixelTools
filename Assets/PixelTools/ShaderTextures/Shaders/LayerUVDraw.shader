Shader "Unlit/LayerUVDraw"
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
			Tags { "RenderType" = "Transparent" }
			// No culling or depth
			Cull Off ZWrite Off ZTest Always
			Blend SrcAlpha OneMinusSrcAlpha

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

				fixed4 frag(v2f i) : SV_Target
				{
				fixed4 base = tex2D(_BaseMap, i.uv);
				fixed4 mask = tex2D(_MaskMap, i.uv);
				fixed4 blend = tex2D(_BlendMap, mask) * _Color;
				fixed alpha = blend.a * mask.a * (1 - mask.b);
				return lerp(base, blend, alpha);
				}
				ENDCG
			}
		}
}
