Shader "MinJinWoo/Basic" //셰이더 소속과 명칭
{
    //01프로퍼티 영역  
    //셰이더에서 사용할 메인 항목들 선언
    Properties 
    {
        //프로퍼티명, (인스펙터에 노출될 이름, 타입/범위),초기값
        _MainTex ("Albedo (RGB) Base", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)2", 2D) = "white" {}
        _MainTex3 ("Albedo (RGB)3", 2D) = "white" {}
        _MainTex4 ("Albedo (RGB)4", 2D) = "white" {}
        _MainTex5 ("Albedo (RGB)5", 2D) = "white" {}
        //색상관련 프로퍼티 추가
       
    }
    //02서브셰이더 영역
    //프로퍼티를 활용하여 실제 셰이더가 수행될 역활에 대한 정의
    //내부적으로 CGPROGRAM 영역을 지니고 있음
    SubShader
    {
        //알파 채널을 작동시키기 위해서 아래 영역을 수정
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        
        //3. CGPROGRAM 영역 - ENDCG까지
        //CG언어를 활용하여 직접 쉐이더를 작성하는 부분
        //1,2번은 유니티의 자체 언어로 작성되어 있으며
        //3번은 CG(쉐이더 전용 언어)로 작성되어 있음
        CGPROGRAM

        //3-1설정부분
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MainTex4;
        sampler2D _MainTex5;

        //3-2 구조체 부분 - 엔진으로부터 받아와야할 데이터
        struct Input
        {
            float2 uv_MainTex;
            //float2 uv_MainTex2;
        };

       
        fixed4 _Color;
        

        //3-3 함수영역
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //텍스처 설정(모양/질감/패턴) * 컬러 설정
            
            //d를 먼저 수행하는 이유는 베이스가 되는 C에서
            //d의 UV를 활용하기 위함
            //fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y));
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex + d.r);

            //스위즐링에 의해서 RGB(1,0,0) > GBR (0,0,1)
            //빨간색이 파란색으로 변경되더라...
            //Albedo 는 명암에 영향을 받는다고 했음
            //Emission 은 명암 영향 없이 원색 그대로
            //lerp 함수는 2가지 텍스처를 합칠 때 사용
            //lerp(이미지 1, 이미지 2,합성 강도)
            //합성 강도 0~1, 
            //0에 가까울 수록 이미지 1 표현
            //1에 가까울 수록 이미지 2 표현
            //o.Emission = c.rgb;
            //그레이 스케일(흑백전환)
            //o.Albedo = (c.r+c.g+c.b)/3;

            fixed4 maskC = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 baseC = tex2D(_MainTex2, IN.uv_MainTex);
            fixed4 c3 = tex2D(_MainTex3, IN.uv_MainTex);
            fixed4 c4 = tex2D(_MainTex4, IN.uv_MainTex);
            fixed4 c5 = tex2D(_MainTex5, IN.uv_MainTex);

            //R채널 영역
            //G채널 영역
            //B채널 영역
            //RGB 채널을 제외한 나머지(검은영역)
            o.Albedo = c3.rgb * MaskC.r + 
                c4.rgb * MaskC.g + 
                c5.rgb * MaskC.b + 
                baseC(1 - (maskC.r + maskC.g + maskC.b));
            //o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
