namespace React.WebApi.Configs;

public class Cors
{
    public string Name { get; set; } = string.Empty;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public CorsAllowed Allowed { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}

public class CorsAllowed
{
    public string[] Origins { get; set; } = [];
    public string[] Methods { get; set; } = [];
    public string[] Headers { get; set; } = [];
}