
Shader "ShaderMan/newShader"
	{

	Properties{
	//Properties
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

	struct VertexInput {
    fixed4 vertex : POSITION;
	fixed2 uv:TEXCOORD0;
    fixed4 tangent : TANGENT;
    fixed3 normal : NORMAL;
	//VertexInput
	};


	struct VertexOutput {
	fixed4 pos : SV_POSITION;
	fixed2 uv:TEXCOORD0;
	//VertexOutput
	};

	//Variables

	fixed hash(fixed n) {
	return frac(sin(n)*43578.4545);
}

fixed noise(fixed3 x) {
	fixed3 p = floor(x);
	fixed3 f = frac(x);
	
	f = f*f*(3.0 - 2.0*f);
	
	fixed n = p.x + p.y*57.0 + p.z*113.0;
	
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

fixed fbm(fixed3 p) {
	fixed f = 0.0;
	
	f += 0.500*noise(p); p *= 2.01;
	f += 0.250*noise(p); p *= 2.04;
	f += 0.125*noise(p);
	
	f /= 0.875;
	return f;
}

fixed2 path(fixed z) {
	return fixed2(sin(0.5*z), 2.0*cos(0.12*z));
}

fixed3 camPath() {
	fixed3 ro = fixed3(0, 0, 2.0*_Time.y);
	ro.xy = path(ro.z);
	
	return ro;
}

fixed3 lookat(fixed3 ro) {
	fixed3 la = ro + fixed3(0, 0, 1);
	la.xy = path(la.z);
	
	return la;
}

fixed3 lightPath(fixed3 la) {
	fixed3 lp = la;
	lp.xy += 0.2*fixed2(sin(_Time.y), cos(_Time.y));
	
	
	return lp;
}

fixed map(fixed3 p) {
	fixed r = 0.6*smoothstep(0.3, 1.0, noise(1.5*p));
	fixed f = 0.1*smoothstep(0.0, 1.0, fbm(6.0*p + 3.0*fixed3(0, _Time.y, 0)));
	
	fixed l = length(p - lightPath(lookat(camPath()))) - 0.01;
	fixed2 tun = abs(p.xy - path(p.z))*fixed2(.6, 3);
	fixed t = 1.0 - max(tun.x, tun.y);
	return min(l, t - (r + f));
}

fixed march(fixed3 ro, fixed3 rd) {
	fixed t = 0.0;
	
	[unroll(100)]
for(int i = 0; i < 150; i++) {
		fixed h = map(ro + rd*t);
		if(abs(h) < 0.0001 || t >= 30.0) break;
		t += h*0.5;
	}
	
	return t;
}

fixed3 normal(fixed3 p) {
	fixed2 h = fixed2(0.01, 0.0);
	
	fixed3 n = fixed3(
		map(p + h.xyy) - map(p - h.xyy,
		map(p + h.xyy) - map(p - h.xyy,
		map(p + h.xyy) - map(p - h.xyy),
		map(p + h.yxy) - map(p - h.yxy),
		map(p + h.yyx) - map(p - h.yyx)
	);
	
	return normalize(n);
}


fixed3x3 camera(fixed3 e, fixed3 l) {
	fixed3 f = normalize(l - e);
	fixed3 r = normalize(cross(fixed3(0, 1, 0), f));
	fixed3 u = normalize(cross(f, r));
	
	return fixed3x3(r, u, f);
}





	VertexOutput vert (VertexInput v)
	{
	VertexOutput o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.uv;
	//VertexFactory
	return o;
	}
	fixed4 frag(VertexOutput i) : SV_Target
	{
	
	fixed2 uv = (-1.0 + 2.0*(i.uv/1))*fixed2(1/1, 1.0);
	
	fixed3 ro = camPath();
	
	fixed3 la = lookat(ro);
	
	fixed3 rd = camera(ro, la)*normalize(fixed3(uv, 1.97));
	
	fixed3 col = fixed3(0,0,0);
	
	fixed i = march(ro, rd);
	
	if(i < 30.0) {
		fixed3 pos = ro + rd*i;
		fixed3 nor = normal(pos);
		
		fixed3 rig = lightPath(la);
		fixed3 lig = normalize(rig - pos);
		fixed3 ref = reflect(rd, nor);
		
		fixed dis = max(length(pos - rig), 0.001);
		if(dis <= 0.015) {
			col = fixed3(1,1,1);
		
	}
	ENDCG
	}
  }
}

