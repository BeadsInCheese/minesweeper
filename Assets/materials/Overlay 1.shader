Shader "Hidden/Overlay"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TextTexture ("Texture", 2D) = "white" {}
        
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
            sampler2D _TextTexture;
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                int _Row=2;
                int _Digit1=(floor(311*(_Time.x/2))*floor(i.uv.x*100)+floor((sin(floor(i.uv.x*100))*_Time.x+i.uv.y)*50))%1000;
                float _Digitsx=16.06;
                float _Digitsy=12;
                col = 0.05*sin((floor(i.uv.x*100))*_Time.x+5*i.uv.y)*sin(sin(floor(i.uv.x*100))*100)*tex2D(_TextTexture, float2((frac(i.uv.x*100.)+(_Digit1+9)%10.0)/_Digitsx,(frac((sin(floor(i.uv.x*100))*_Time.x+i.uv.y)*50.)+12-_Row)/_Digitsy));
                
                //col.rgb =  float3(0,0.01*smoothstep(0.9,1.1,step(frac(i.uv.x*50+_Time.x),0.5)*abs(sin(i.uv.y*10.+_Time.x*10.))),0);
                return col;
            }
            ENDCG
        }
    }
}
