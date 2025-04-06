Shader "Hidden/SceneTransition"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Treshold ("treshold", FLOAT) = 0.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always Blend SrcAlpha OneMinusSrcAlpha

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Treshold;
            fixed4 frag (v2f i) : SV_Target
            {
                // just invert the colors
                float2 uv=i.uv-0.5;
                if(length(uv)<_Treshold){
                    return  float4(0,0,0,0);
                    
                }else{
                    return float4(0,0,0,1);
                }
                
            }
            ENDCG
        }
    }
}
