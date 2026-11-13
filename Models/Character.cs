using System.Text.Json;

namespace SearchNarutoAPI.Models;

public class CharacterPage
{
    public List<Character> Characters { get; set; } = [];
    public int Total { get; set; }
}

public class Character
{
    public string Name { get; set; } = "";
    public List<string> Images { get; set; } = [];
    public List<string> Jutsu { get; set; } = [];
    public JsonElement Personal { get; set; }
    public JsonElement Rank { get; set; }

    public static string Display(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.String => value.GetString() ?? "Não informado",
        JsonValueKind.Array => string.Join(", ", value.EnumerateArray().Select(Display)),
        JsonValueKind.Object => string.Join("; ", value.EnumerateObject().Select(p => $"{p.Name}: {Display(p.Value)}")),
        JsonValueKind.Undefined or JsonValueKind.Null => "Não informado",
        _ => value.ToString()
    };

    public static JsonElement Field(JsonElement value, string key) =>
        value.ValueKind == JsonValueKind.Object && value.TryGetProperty(key, out var field)
            ? field : default;
}
