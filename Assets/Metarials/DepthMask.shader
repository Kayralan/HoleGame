Shader "Custom/URPDepthMask" {
    SubShader {
        // URP'ye uygun etiketler ve çizim sırası (Zeminden hemen önce)
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" "Queue"="Geometry-1"}
        Pass {
            // Rengi kapat, sadece derinliği (Z-Buffer) yaz
            ZWrite On
            ColorMask 0
        }
    }
}