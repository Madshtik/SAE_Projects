Shader "CustomShaders/Shader9"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white"
		_Tex2("Texture2", 2D) = "white" {}
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
				float2 uv2 : TEXCOORD1; // texture coordinate
			};

			struct v2f
			{
				float4 vertex : SV_POSITION; // clip space position
				float2 uv : TEXCOORD0; // texture coordinate
				float2 uv2 : TEXCOORD1; // texture coordinate
			};

			// vertex shader
			v2f vert(appdata input)
			{
				v2f output;
				output.vertex = UnityObjectToClipPos(input.vertex);
				output.uv = input.uv;
				output.uv2 = input.uv2;

				return output;
			}

			sampler2D _MainTex;
			uniform float4  _MainTex_ST;

			sampler2D _Tex2;
			uniform float4  _Tex2_ST;

			fixed4 _Color;

			//Pixel shader
			fixed4 frag(v2f input) : SV_Target
			{
				fixed4 tex = tex2D(_MainTex, input.uv * (_MainTex_ST.xy * _SinTime.w) + _MainTex_ST.zw);
				fixed4 tex2 = tex2D(_Tex2, input.uv2* _Tex2_ST.xy + _Tex2_ST.zw);
				fixed4 finalColor = tex * tex2;

				return finalColor;
			}
			ENDCG
		}
	}
}