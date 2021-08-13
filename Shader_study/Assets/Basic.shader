Shader "MinJinWoo/Basic" //���̴� �ҼӰ� ��Ī
{
    //01������Ƽ ����  
    //���̴����� ����� ���� �׸�� ����
    Properties 
    {
        //������Ƽ��, (�ν����Ϳ� ����� �̸�, Ÿ��/����),�ʱⰪ
        _MainTex ("Albedo (RGB) Base", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)2", 2D) = "white" {}
        _MainTex3 ("Albedo (RGB)3", 2D) = "white" {}
        _MainTex4 ("Albedo (RGB)4", 2D) = "white" {}
        _MainTex5 ("Albedo (RGB)5", 2D) = "white" {}
        //������� ������Ƽ �߰�
       
    }
    //02������̴� ����
    //������Ƽ�� Ȱ���Ͽ� ���� ���̴��� ����� ��Ȱ�� ���� ����
    //���������� CGPROGRAM ������ ���ϰ� ����
    SubShader
    {
        //���� ä���� �۵���Ű�� ���ؼ� �Ʒ� ������ ����
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        
        //3. CGPROGRAM ���� - ENDCG����
        //CG�� Ȱ���Ͽ� ���� ���̴��� �ۼ��ϴ� �κ�
        //1,2���� ����Ƽ�� ��ü ���� �ۼ��Ǿ� ������
        //3���� CG(���̴� ���� ���)�� �ۼ��Ǿ� ����
        CGPROGRAM

        //3-1�����κ�
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MainTex4;
        sampler2D _MainTex5;

        //3-2 ����ü �κ� - �������κ��� �޾ƿ;��� ������
        struct Input
        {
            float2 uv_MainTex;
            //float2 uv_MainTex2;
        };

       
        fixed4 _Color;
        

        //3-3 �Լ�����
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //�ؽ�ó ����(���/����/����) * �÷� ����
            
            //d�� ���� �����ϴ� ������ ���̽��� �Ǵ� C����
            //d�� UV�� Ȱ���ϱ� ����
            //fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y));
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex + d.r);

            //�����񸵿� ���ؼ� RGB(1,0,0) > GBR (0,0,1)
            //�������� �Ķ������� ����Ǵ���...
            //Albedo �� ��Ͽ� ������ �޴´ٰ� ����
            //Emission �� ��� ���� ���� ���� �״��
            //lerp �Լ��� 2���� �ؽ�ó�� ��ĥ �� ���
            //lerp(�̹��� 1, �̹��� 2,�ռ� ����)
            //�ռ� ���� 0~1, 
            //0�� ����� ���� �̹��� 1 ǥ��
            //1�� ����� ���� �̹��� 2 ǥ��
            //o.Emission = c.rgb;
            //�׷��� ������(�����ȯ)
            //o.Albedo = (c.r+c.g+c.b)/3;

            fixed4 maskC = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 baseC = tex2D(_MainTex2, IN.uv_MainTex);
            fixed4 c3 = tex2D(_MainTex3, IN.uv_MainTex);
            fixed4 c4 = tex2D(_MainTex4, IN.uv_MainTex);
            fixed4 c5 = tex2D(_MainTex5, IN.uv_MainTex);

            //Rä�� ����
            //Gä�� ����
            //Bä�� ����
            //RGB ä���� ������ ������(��������)
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
