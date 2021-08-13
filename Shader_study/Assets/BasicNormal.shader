Shader "MinJinWoo/BasicNormal" //���̴� �ҼӰ� ��Ī
{
    //01������Ƽ ����  
    //���̴����� ����� ���� �׸�� ����
    Properties 
    {
        //������Ƽ��, (�ν����Ϳ� ����� �̸�, Ÿ��/����),�ʱⰪ
        _MainTex ("Albedo (RGB) Base", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {} //�븻�ʿ�
        _Metallic("Metallic", Range(0,1)) = 0
        _Smoothness("Smoothness",Range(0,1)) = 0
        _Occlusion("Occlusion",2D) = "white"{}
        
        //������� ������Ƽ �߰�
       
    }
    //02������̴� ����
    //������Ƽ�� Ȱ���Ͽ� ���� ���̴��� ����� ��Ȱ�� ���� ����
    //���������� CGPROGRAM ������ ���ϰ� ����
    SubShader
    {
        //���� ä���� �۵���Ű�� ���ؼ� �Ʒ� ������ ����
        Tags { "RenderType"="Opaque" }
        
        //3. CGPROGRAM ���� - ENDCG����
        //CG�� Ȱ���Ͽ� ���� ���̴��� �ۼ��ϴ� �κ�
        //1,2���� ����Ƽ�� ��ü ���� �ۼ��Ǿ� ������
        //3���� CG(���̴� ���� ���)�� �ۼ��Ǿ� ����
        CGPROGRAM

        //3-1�����κ�
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard 
        sampler2D _MainTex;
        sampler2D _BumpMap;

        sampler2D _Occlusion;
        float _Metallic;
        float _Smoothness;


        

        //3-2 ����ü �κ� - �������κ��� �޾ƿ;��� ������
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            //float2 uv_MainTex2;
        };

       
        fixed4 _Color;
        

        //3-3 �Լ�����
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            //��������� ��� ������ UV�� Ȱ���ϴ� ���� �ƴ϶�
            //��Ŭ������ �����ϰ��� �ϴ� �ؽ�ó�� uv�� Ȱ��
            o.Occlusion = tex2D(_Occlusion, IN.uv_MainTex);


            //�븻�������� �Ϲ� �ؽ�ó�� ���̰� ����
            //�븻���� �Ϲ� �ؽ�ó�� ������ �ٸ�
            //������ ������ �븻���� ǰ���� �����ϱ� ���� AG������(����)��
            //�׷��� �븻���� ó���� ���� �ٸ�
            //�븻���� ������ �����ϱ� ���Ͽ� �ٷ� �����ϴ� ���� �ƴ϶�
            //n ���� ���ٰ� �����Ŀ� �����ϵ�����
            fixed3 n = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            //������ 2(�����)�� �����ϸ� �븻���� ������ �����
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
