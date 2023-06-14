namespace NetStore.Api.Configurations.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class SwaggerFileUploadButtonAttribute : Attribute
{
    public string? ParameterName { get; set; }
}
