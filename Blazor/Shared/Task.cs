using Blazor.Shared.ENUMS;

namespace Blazor.Shared;

public class Task
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DateTime { get; set; }

    public EProcess Process { get; set; }
}