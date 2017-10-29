﻿Shader "CustomShaders/Shader10"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white"
	}

	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

#pragma vertex vert
#pragma fragment frag

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0; // texture coordinate
			};

			struct v2f
			{
				float4 vertex : SV_POSITION; // clip space position
				float2 uv : TEXCOORD0; // texture coordinate
			};

			// vertex shader
			v2f vert(appdata input)
			{
				v2f output;
				output.vertex = UnityObjectToClipPos(input.vertex);
				output.uv = input.uv;

				return output;
			}

			sampler2D _MainTex;
			fixed4 _Color;

			//Pixel shader
			fixed4 frag(v2f input) : SV_Target
			{
				fixed4 tex = tex2D(_MainTex, input.uv) + fixed4(0.0f, 1.0f, 0.0f, 0.0f);

				return tex * _Color;
			}
			ENDCG
		}
	}
}