using System.Text.Json.Serialization;

namespace GoTalentsCourse.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderType
    {
        MASCULINO,
        FEMININO,
        OUTROS
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {
        FACILITADOR,
        ALUNO
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Speciality
    {
        CSharp,
        DotNet,
        Python,
        Docker,
        NodeJs
    }
}
