Shader "CustomtShader/Built-In/DerekPBRShader"
{
    Properties
    {
        _MainTex("MainTex",2D) = "white" {}
        _BaseColor("BaseColor",Color) = (1,1,1,1)
        
        [Space][Header(Roughness)][Space]
        _RoughnessTexture("RoughnessTexture",2D) = "white" {}
        _Roughness("Roughness",Range(0,1)) = 0.5
        
        [Space][Header(Metallic)][Space]
        _MetallicTexture("MetallicTexture",2D) = "white" {}
        _Metallic("Metallic",Range(0,1)) = 0.5
        
        [Space][Header(Normal)][Space]
        _NormalTexture("NormalTexture",2D) = "bump" {}
        _Normal("Normal",Float) = 0
    }
    
    SubShader
    {
        Pass
        {
            Tags{"RenderType" = "Opaque" "LightMode" = "ForwardBase"}
            LOD 100
            
            CGPROGRAM
            #pragma multi_compile_fwdbase_fullshadows
            #pragma vertex vert
            #pragma fragment frag;
            
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
            #include "AutoLight.cginc"
            
            struct a2v
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
                float4 worldTangent : TEXCOORD3;
                LIGHTING_COORDS(5,6)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            sampler2D _RoughnessTexture;

            sampler2D _MetallicTexture;

            sampler2D _NormalTexture;

            float4 _BaseColor;
            float _Roughness;
            float _Metallic;
            float _Normal;

            float NDF(float rough,float NdotH)
            {
                float a= rough*rough;
                float a_pow = pow(a,2);
                float NdotH_pow = pow(NdotH,2);
                float dem = UNITY_PI*(NdotH_pow*(a_pow-1)+1);
                return a_pow/dem; 
            }
            float Geometry(float rough,float NdotV,float NdotL)
            {
                float k = pow((rough+1),2)/8;
                float G1 = (NdotV)/((NdotV)*(1-k)+k);
                float G2 = (NdotL)/((NdotL)*(1-k)+k);
                return G1*G2;
            }
            float3 Fresnel(float3 f0,float NdotV)
            {
                return lerp(f0,1,pow((1-NdotV),5));
            }

            float3 PBR(float NdotL,float NdotV,float NdotH,float3 albedo,float metal,float rough,float3 normal,float3 viewDir,float shadow)
            {
                float3 f0 = float3(0.04,0.04,0.04);
                f0 = lerp(f0,albedo,metal);
                
                float3 F = Fresnel(f0,NdotV);
                float G = Geometry(rough,NdotV,NdotL);
                float D = NDF(rough,NdotH);
                D = min(D,100);

                float3 kd = (1-F)*(1-metal);
                float3 diffuse = kd*albedo/UNITY_PI;
                
                float3 specular = F*G*D/(4*NdotL*NdotV+0.00001);
                
                float3 pbrCol = (diffuse+specular)*_LightColor0*NdotL*shadow;
                
                //Environment Color
                float3 irradiance = ShadeSH9(float4(normal,1));
                float3 diffuseEnvCol = irradiance * albedo;
                float4 color_cubemap = UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0,reflect(-viewDir , normal), 6* rough);
                float3 specularEnvCol = DecodeHDR(color_cubemap,unity_SpecCube0_HDR);
                specularEnvCol *= F;
                float3 envCol = (kd * diffuseEnvCol + specularEnvCol);
                
                return (pbrCol + envCol);
            }
            
            v2f vert(a2v i)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(i.position);
                o.worldPosition = mul(unity_ObjectToWorld,i.position);
                o.worldNormal = UnityObjectToWorldNormal(i.normal);
                o.worldTangent = float4(UnityObjectToWorldDir(i.tangent),i.tangent.w);
                o.uv = TRANSFORM_TEX(i.uv,_MainTex);

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float3 binormal = cross(i.worldNormal,i.worldTangent.xyz)*(i.worldTangent.w*unity_WorldTransformParams.w);
                float4 normal = tex2D(_NormalTexture,i.uv);
                normal.xyz = UnpackNormalWithScale(normal,_Normal);
                normal.xyz = normal.xzy;
                float3 worldNormal = normalize(
                    normal.x*i.worldTangent+
                    normal.y*i.worldNormal+
                    normal.z*binormal
                );

                float4 albedo = tex2D(_MainTex,i.uv) * _BaseColor;
                float rough = tex2D(_RoughnessTexture,i.uv) * _Roughness;
                float metal = tex2D(_MetallicTexture,i.uv) * _Metallic;

                float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPosition);
                float3 lightDir = UnityWorldSpaceLightDir(i.worldPosition);
                float3 halfDir = normalize(worldNormal+lightDir);

                float NdotL = saturate(dot(worldNormal,lightDir));
                float NdotH = saturate(dot(worldNormal,halfDir));
                float NdotV = saturate(dot(worldNormal,viewDir));
                
                float shadowAtten = LIGHT_ATTENUATION(i);
                
                float3 pbrCol = PBR(NdotL,NdotV,NdotH,albedo,metal,rough,worldNormal,viewDir,shadowAtten);
                float4 color = tex2D(_MainTex,i.uv);
                color.xyz = pbrCol;
                
                return color;
            }
            
            ENDCG
        }      
    }
    
    FallBack "Diffuse"
}
