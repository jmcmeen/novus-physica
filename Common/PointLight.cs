using OpenTK.Mathematics;
using System;

namespace Common
{
    public class PointLight
    {
        private static int globalIndex = 0;
        private int shaderIndex;
        public Vector3 position;
        public Vector3 ambient;
        public Vector3 diffuse;
        public Vector3 specular;

        public float constant;
        public float linear;
        public float quadratic;

        public PointLight(Vector3 position)
        {
            shaderIndex = globalIndex;
            globalIndex += 1;

            this.position = position;

            //for now lights default to these values
            ambient = new Vector3(0.0f, 0.0f, 0.0f);
            diffuse = new Vector3(1.0f, 1.0f, 1.0f);
            specular = new Vector3(1.0f, 1.0f, 1.0f);
            constant = 1.0f;
            linear = 0.9f;
            quadratic = 0.32f;
        }

        public void Draw(Shader shader)
        {
            shader.SetVector3($"pointLights[{shaderIndex}].position", position);
            shader.SetVector3($"pointLights[{shaderIndex}].ambient", ambient);
            shader.SetVector3($"pointLights[{shaderIndex}].diffuse", diffuse);
            shader.SetVector3($"pointLights[{shaderIndex}].specular", specular);
            shader.SetFloat($"pointLights[{shaderIndex}].constant", constant);
            shader.SetFloat($"pointLights[{shaderIndex}].linear", linear);
            shader.SetFloat($"pointLights[{shaderIndex}].quadratic", quadratic);
        }
    }
}
