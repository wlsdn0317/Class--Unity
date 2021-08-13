Shader "MinJinWoo/BasicNormal" //셰이더 소속과 명칭
{
    //01프로퍼티 영역  
    //셰이더에서 사용할 메인 항목들 선언
    Properties 
    {
        //프로퍼티명, (인스펙터에 노출될 이름, 타입/범위),초기값
        _MainTex ("Albedo (RGB) Base", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {} //노말맵용
        _Metallic("Metallic", Range(0,1)) = 0
        _Smoothness("Smoothness",Range(0,1)) = 0
        _Occlusion("Occlusion",2D) = "white"{}
        
        //색상관련 프로퍼티 추가
       
    }
    //02서브셰이더 영역
    //프로퍼티를 활용하여 실제 셰이더가 수행될 역활에 대한 정의
    //내부적으로 CGPROGRAM 영역을 지니고 있음
    SubShader
    {
        //알파 채널을 작동시키기 위해서 아래 영역을 수정
        Tags { "RenderType"="Opaque" }
        
        //3. CGPROGRAM 영역 - ENDCG까지
        //CG언어를 활용하여 직접 쉐이더를 작성하는 부분
        //1,2번은 유니티의 자체 언어로 작성되어 있으며
        //3번은 CG(쉐이더 전용 언어)로 작성되어 있음
        CGPROGRAM

        //3-1설정부분
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard 
        sampler2D _MainTex;
        sampler2D _BumpMap;

        sampler2D _Occlusion;
        float _Metallic;
        float _Smoothness;


        

        //3-2 구조체 부분 - 엔진으로부터 받아와야할 데이터
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            //float2 uv_MainTex2;
        };

       
        fixed4 _Color;
        

        //3-3 함수영역
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            //오쿨루전의 경우 독립된 UV를 활용하는 것이 아니라
            //오클루전을 적용하고자 하는 텍스처의 uv를 활용
            o.Occlusion = tex2D(_Occlusion, IN.uv_MainTex);


            //노말맵이지만 일반 텍스처와 차이가 없음
            //노말맵은 일반 텍스처와 포맷이 다름
            //파일의 포맷이 노말맵의 품질을 유지하기 위한 AG형식임(압축)임
            //그래서 노말맵의 처리는 조금 다름
            //노말맵의 강도를 조정하기 위하여 바로 대입하는 것이 아니라
            //n 변수 에다가 저장후에 조작하도록함
            fixed3 n = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            //곱해진 2(상수값)을 조정하면 노말맵의 강도가 변경됨
            o.Normal = float3(n.x * 20, n.y * 20, n.z);


            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
