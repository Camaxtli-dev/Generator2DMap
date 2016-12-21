Shader "Transparent/Cutout/Diffuse" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_SecondTex("Mask (RGB) Trans (A)", 2D) = "white" {}
		_Cutoff("Alpha", Range(0,1)) = 0.5
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert alphatest:_Cutoff

		sampler2D _MainTex;
	sampler2D _SecondTex;

	float Height;

	struct Input {
		float2 uv_MainTex;
		float2 uv_SecondTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		float4 main = tex2D(_MainTex, IN.uv_MainTex);
		float4 second = tex2D(_SecondTex, IN.uv_SecondTex);
		o.Albedo = second.rgb;
		o.Alpha = main.b;
	}
	ENDCG
	}
		FallBack "Diffuse"
}