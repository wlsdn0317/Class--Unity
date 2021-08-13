Shader "MinJinWoo/01" //셰이더 소속과 명칭
{
    //01프로퍼티 영역  
    //셰이더에서 사용할 메인 항목들 선언
    Properties 
    {
        //프로퍼티명, (인스펙터에 노출될 이름, 타입/범위),초기값
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        //색상관련 프로퍼티 추가
        _Red("Red", Range(0,1)) = 0
        _Green("Green", Range(0,1)) = 0
        _Blue("Blue", Range(0,1)) = 0
    }
    //02서브셰이더 영역
    //프로퍼티를 활용하여 실제 셰이더가 수행될 역활에 대한 정의
    //내부적으로 CGPROGRAM 영역을 지니고 있음
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        //3. CGPROGRAM 영역 - ENDCG까지
        //CG언어를 활용하여 직접 쉐이더를 작성하는 부분
        //1,2번은 유니티의 자체 언어로 작성되어 있으며
        //3번은 CG(쉐이더 전용 언어)로 작성되어 있음
        CGPROGRAM

        //3-1설정부분
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        
        sampler2D _MainTex;

        //3-2 구조체 부분 - 엔진으로부터 받아와야할 데이터
        struct Input
        {
            float2 uv_MainTex;
        };

       
        fixed4 _Color;
        float _Red;
        float _Green;
        float _Blue;

        //3-3 함수영역
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color

                        //텍스처 설정(모양/질감/패턴) * 컬러 설정
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            //스위즐링에 의해서 RGB(1,0,0) > GBR (0,0,1)
            //빨간색이 파란색으로 변경되더라...
            //Albedo 는 명암에 영향을 받는다고 했음
            //Emission 은 명암 영향 없이 원색 그대로
            o.Albedo = float3(_Red,_Green,_Blue);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
