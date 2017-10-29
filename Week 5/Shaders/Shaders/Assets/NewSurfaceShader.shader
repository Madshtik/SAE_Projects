Shader "Unlit/SimpleUnlitTexturedShader"
{
	Properties
	{
		// we have removed support for texture tiling/offset,
		// so make them not be displayed in material inspector

		_Tex2("Texture", 2D) = "white" {}

		_MainTex("Color (RGB) Alpha (A)", 2D) = "white"

	}
		SubShader{
			// inside SubShader
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }

			// inside Pass
			//Blend SrcAlpha OneMinusSrcAlpha

		Pass
	{
		CGPROGRAM
		// use "vert" function as the vertex shader
#pragma vertex vert
		// use "frag" function as the pixel (fragment) shader
#pragma fragment frag

		// vertex shader inputs
		struct appdata
	{
		float4 vertex : POSITION; // vertex position
		float2 uv : TEXCOORD0; // texture coordinate
		float2 uv2 : TEXCOORD1; // texture coordinate
	};

	// vertex shader outputs ("vertex to fragment")
	struct v2f
	{
		float2 uv : TEXCOORD0; // texture coordinate
		float2 uv2 : TEXCOORD1; // texture coordinate
		float4 vertex : SV_POSITION; // clip space position
	};

	// vertex shader
	v2f vert(appdata v)
	{
		v2f o;
		// transform position to clip space
		// (multiply with model*view*projection matrix)
		o.vertex = UnityObjectToClipPos(float4(v.vertex.x * _SinTime.w, v.vertex.y * _CosTime.w, v.vertex.z * _SinTime.w, v.vertex.w));
		// just pass the texture coordinate
		o.uv = v.uv;
		o.uv2 = v.uv2;
		return o;
	}

	// texture we will sample
	sampler2D _MainTex;
	uniform float4  _MainTex_ST;

	sampler2D _Tex2;


	fixed4 frag(v2f i) : SV_Target
	{
		// sample texture and return it
		fixed4 col = tex2D(_MainTex, i.uv * _MainTex_ST.xy + _MainTex_ST.zw);

		fixed4 col2 = tex2D(_Tex2, float2(i.uv2.x , i.uv2.y ));

	fixed4 finalColor;

	//finalColor = col * (col2 * clamp(_SinTime.w, 0, 1));

	finalColor = col * col2;

	//float4 _FlashColor = float4(0.0f, 1.0f, 0.0f, 1.0f);

	//float r = _Time.w * 3;
	//finalColor.rgb = lerp(finalColor.rgb, _FlashColor.rgb, clamp(_SinTime.x, 0, 1) );

	//finalColor.r *= _SinTime.w;
	//finalColor.g *= _SinTime.w;
	//finalColor.b *= _SinTime.w;
	//finalColor.r = 1;

	return finalColor;
	}
		ENDCG
	}
	}
}