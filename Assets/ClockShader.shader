Shader "Hidden/ClockShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Digit1("digit1", Integer )=1
        _Digitsx("digitsx1", FLOAT )=1
        _Digitsy("digitsy1", FLOAT )=1
        _Row("row", Integer )=1
    }
    SubShader
    {
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            int _Digit1;
            int _Row;
            float _Digitsx;
            float _Digitsy;
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, float2((i.uv.x+(_Digit1+9)%10.0)/_Digitsx,(i.uv.y+12-_Row)/_Digitsy));
                // just invert the colors
                return col;
            }
            ENDCG
        }
    }
}
