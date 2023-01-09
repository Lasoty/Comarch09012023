using Microsoft.AspNetCore.Components;

namespace ComarchZadania.Client.Components;

public partial class MyFirstComponent : ComponentBase
{
	[Parameter]
	public int CurrentCounterValue { get; set; }
}
