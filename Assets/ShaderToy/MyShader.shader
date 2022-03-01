
    Shader "ShaderMan/MyShader"
	{
	Properties{
	
	}
	SubShader
	{
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
	Pass
	{
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"
			
    

    float4 float4(float x,float y,float z,float w){return float4(x,y,z,w);}
    float4 float4(float x){return float4(x,x,x,x);}
    float4 float4(float2 x,float2 y){return float4(float2(x.x,x.y),float2(y.x,y.y));}
    float4 float4(float3 x,float y){return float4(float3(x.x,x.y,x.z),y);}


    float3 float3(float x,float y,float z){return float3(x,y,z);}
    float3 float3(float x){return float3(x,x,x);}
    float3 float3(float2 x,float y){return float3(float2(x.x,x.y),y);}

    float2 float2(float x,float y){return float2(x,y);}
    float2 float2(float x){return float2(x,x);}

    float float(float x){return float(x);}
    
    

	struct VertexInput {
    float4 vertex : POSITION;
	float2 uv:TEXCOORD0;
    float4 tangent : TANGENT;
    float3 normal : NORMAL;
	//VertexInput
	};
	struct VertexOutput {
	float4 pos : SV_POSITION;
	float2 uv:TEXCOORD0;
	//VertexOutput
	};
	
	
	VertexOutput vert (VertexInput v)
	{
	VertexOutput o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.uv;
	//VertexFactory
	return o;
	}
    
    float hash(float n) {
	return frac(sin(n)*43578.4545);
}

float noise(float3 x) {
	float3 p = floor(x);
	float3 f = frac(x);
	
	f = f*f*(3.0 - 2.0*f);
	
	float n = p.x + p.y*57.0 + p.z*113.0;
	
	return lerp(
		lerp(
			lerp(hash(n + 000.0), hash(n + 001.0), f.x),
			lerp(hash(n + 057.0), hash(n + 058.0), f.x),
			f.y),
		lerp(
			lerp(hash(n + 113.0), hash(n + 114.0), f.x),
			lerp(hash(n + 170.0), hash(n + 171.0), f.x),
			f.y),
		f.z);
}

float fbm(float3 p) {
	float f = 0.0;
	
	f += 0.500*noise(p); p *= 2.01;
	f += 0.250*noise(p); p *= 2.04;
	f += 0.125*noise(p);
	
	f /= 0.875;
	return f;
}

float2 path(float z) {
	return float2(sin(0.5*z), 2.0*cos(0.12*z));
}

float3 camPath() {
	float3 ro = float3(0, 0, 2.0*_Time.y);
	ro.xy = path(ro.z);
	
	return ro;
}

float3 lookat(float3 ro) {
	float3 la = ro + float3(0, 0, 1);
	la.xy = path(la.z);
	
	return la;
}

float3 lightPath(float3 la) {
	float3 lp = la;
	lp.xy += 0.2*float2(sin(_Time.y), cos(_Time.y));
	
	
	return lp;
}

float map(float3 p) {
	float r = 0.6*smoothstep(0.3, 1.0, noise(1.5*p));
	float f = 0.1*smoothstep(0.0, 1.0, fbm(6.0*p + 3.0*float3(0, _Time.y, 0)));
	
	float l = length(p - lightPath(lookat(camPath()))) - 0.01;
	float2 tun = abs(p.xy - path(p.z))*float2(.6, 3);
	float t = 1.0 - max(tun.x, tun.y);
	return min(l, t - (r + f));
}

float march(float3 ro, float3 rd) {
	float t = 0.0;
	
	[unroll(100)]
for(int i = 0; i < 150; i++) {
		float h = map(ro + rd*t);
		if(abs(h) < 0.0001 || t >= 30.0) break;
		t += h*0.5;
	}
	
	return t;
}

float3 normal(float3 p) {
	float2 h = float2(0.01, 0.0);
	
	float3 n = float3(
		map(p + h.xyy) - map(p - h.xyy),
		map(p + h.yxy) - map(p - h.yxy),
		map(p + h.yyx) - map(p - h.yyx)
	);
	
	return normalize(n);
}


float3x3 camera(float3 e, float3 l) {
	float3 f = normalize(l - e);
	float3 r = normalize(cross(float3(0, 1, 0), f));
	float3 u = normalize(cross(f, r));
	
	return float3x3(r, u, f);
}


    
    
	fixed4 frag(VertexOutput vertex_output) : SV_Target
	{
	
	float2 uv = (-1.0 + 2.0*(vertex_output.uv/1))*float2(1/1, 1.0);
	
	float3 ro = camPath();
	
	float3 la = lookat(ro);
	
	float3 rd = camera(ro, la)*normalize(float3(uv, 1.97));
	
	float3 col = float3(0);
	
	float i = march(ro, rd);
	
	if(i < 30.0) {
		float3 pos = ro + rd*i;
		float3 nor = normal(pos);
		
		float3 rig = lightPath(la);
		float3 lig = normalize(rig - pos);
		float3 ref = reflect(rd, nor);
		
		float dis = max(length(pos - rig), 0.001);
		if(dis <= 0.015) {
			col = float3(1);
		} else {
			float att = 1.0/(1.0 + 1.5*dis + 2.0*dis*dis);
			
			float dif = clamp(dot(lig, nor), 0.0, 1.0);
			float spe = pow(clamp(dot(lig, ref), 0.0, 1.0), 32.0);
			
			col =  0.7*dif*float3(1);
			col *= float3(0.8, 0.6, 0.2);
			col += spe*float3(1)*dif;
			
			col *= att;
		}
	}
	
	col = pow(col, float3(.4545));
	
	return float4(col, 1);

	}
	ENDCG
	}
  }
  }
