Shader "Custom/culloff"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200
        Cull Front
        // Render the parts of the object facing us.
        // If the object is convex, these will be closer than the
        // back-faces.
 
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert alpha:blend
 
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
 
        sampler2D _MainTex;
 
        struct Input
        {
            float2 uv_MainTex;
            float3 direction;
        };
 
        void vert(inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.direction = v.normal;
            v.normal = -v.normal; // flip normal for backfaces
        }
 
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            const float PI = 3.14159265359;
            // Puff out the direction to compensate for interpolation.
            float3 direction = normalize(IN.direction);
 
            // Get a longitude wrapping eastward from x-, in the range 0-1.
            float longitude = 0.5 - atan2(direction.z, direction.x) / (2.0f * PI);
            // Get a latitude wrapping northward from y-, in the range 0-1.
            float latitude = 0.5 + asin(direction.y) / PI;
 
            // Combine these into our own sampling coordinate pair.
            float2 customUV = float2(longitude, latitude);
 
            // Use them to sample our texture(s), instead of the defaults.
            fixed4 c = tex2D (_MainTex, customUV) * _Color;
 
            // Albedo comes from a texture tinted by color
            o.Albedo = c.rgba;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
 
        Cull Back
        // Render the parts of the object facing us.
        // If the object is convex, these will be closer than the
        // back-faces.
 
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert alpha:blend
 
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
 
        sampler2D _MainTex;
 
        struct Input
        {
            float2 uv_MainTex;
            float3 direction;
        };
 
        void vert(inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.direction = v.normal;
        }
 
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            const float PI = 3.14159265359;
            // Puff out the direction to compensate for interpolation.
            float3 direction = normalize(IN.direction);
 
            // Get a longitude wrapping eastward from x-, in the range 0-1.
            float longitude = 0.5 - atan2(direction.z, direction.x) / (2.0f * PI);
            // Get a latitude wrapping northward from y-, in the range 0-1.
            float latitude = 0.5 + asin(direction.y) / PI;
 
            // Combine these into our own sampling coordinate pair.
            float2 customUV = float2(longitude, latitude);
 
            // Use them to sample our texture(s), instead of the defaults.
            fixed4 c = tex2D (_MainTex, customUV) * _Color;
 
            // Albedo comes from a texture tinted by color
            o.Albedo = c.rgba;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}